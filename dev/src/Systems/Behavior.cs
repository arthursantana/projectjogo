using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Systems {
   public class Behavior {
      ECS.ComponentList<Components.Behavior> behaviors;
      ECS.ComponentList<Components.Body> bodies;
      ECS.ComponentList<Components.Avatar> avatars;

      int bodiesPos;
      int avatarsPos;

      public Behavior(ECS.ComponentList<Components.Behavior> beh,
            ECS.ComponentList<Components.Body> bod, int bPos,
            ECS.ComponentList<Components.Avatar> ava, int aPos) {
         behaviors = beh;
         bodies = bod;
         avatars = ava;

         bodiesPos = bPos;
         avatarsPos = aPos;
      }

      Random random = new Random();

      public void Update(GameTime gameTime) {
         int temperature = 2;
         for (ushort i = 0; i < behaviors.size; i++) {
            ECS.Entity entity = behaviors.metadata[i].entity;
            int bodyIndex;
            int avatarIndex;

            if (entity.components[bodiesPos] == -1) continue;
            else bodyIndex = entity.components[bodiesPos];

            avatarIndex = entity.components[avatarsPos];

            if (behaviors.data[i].isPlayerControlled) {
               GamePadState gamepad = GamePad.GetState(PlayerIndex.One);
               Vector2 thumbSticks = new Vector2(0, 0);

               if (gamepad.DPad.Up == ButtonState.Pressed ||
                     gamepad.DPad.Right == ButtonState.Pressed ||
                     gamepad.DPad.Down == ButtonState.Pressed ||
                     gamepad.DPad.Left == ButtonState.Pressed ||
                     Keyboard.GetState().IsKeyDown(Keys.W) ||
                     Keyboard.GetState().IsKeyDown(Keys.D) ||
                     Keyboard.GetState().IsKeyDown(Keys.S) ||
                     Keyboard.GetState().IsKeyDown(Keys.A)) {
                  if (gamepad.DPad.Up == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
                     thumbSticks.Y = 1;
                  else if (gamepad.DPad.Down == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.S))
                     thumbSticks.Y = -1;

                  if (gamepad.DPad.Right == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D))
                     thumbSticks.X = 1;
                  else if (gamepad.DPad.Left == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A))
                     thumbSticks.X = -1;
               } else {
                  thumbSticks.X = gamepad.ThumbSticks.Left.X;
                  thumbSticks.Y = gamepad.ThumbSticks.Left.Y;
               }

               float normSquared = thumbSticks.X*thumbSticks.X + thumbSticks.Y + thumbSticks.Y;
               if (normSquared > 1) {
                  thumbSticks.X /= (float) Math.Sqrt(normSquared);
                  thumbSticks.Y /= (float) Math.Sqrt(normSquared);
               }

               float epsilon = 0.1f;
               float speed = 200;
               if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || gamepad.Triggers.Right > epsilon) {
                  speed *= 1.5f;
               }
               bodies.data[bodyIndex].velocity.X = thumbSticks.X * speed;
               bodies.data[bodyIndex].velocity.Y = thumbSticks.Y * speed * -1;

               if (avatarIndex != -1) {
                  normSquared = bodies.data[bodyIndex].velocity.X*bodies.data[bodyIndex].velocity.X + bodies.data[bodyIndex].velocity.Y*bodies.data[bodyIndex].velocity.Y;
                  if (normSquared > epsilon) {
                     Components.Animation anim = avatars.data[avatarIndex].animations["andando"];

                     if (avatars.data[avatarIndex].currentAnimation != anim) {
                        avatars.data[avatarIndex].currentAnimation = anim;
                        anim.currentFrame = 0;
                     }
                  }
                  else {
                     Components.Animation anim = avatars.data[avatarIndex].animations["parado"];

                     if (avatars.data[avatarIndex].currentAnimation != anim) {
                        avatars.data[avatarIndex].currentAnimation = anim;
                        anim.currentFrame = 0;
                     }
                  }
               }
            }
            else {
               bodies.data[bodyIndex].velocity.X += temperature * (float) (random.NextDouble() - 0.5);
               bodies.data[bodyIndex].velocity.Y += temperature * (float) (random.NextDouble() - 0.5);
            }
         }
      }
   }
}
