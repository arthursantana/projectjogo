using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Systems {
   public class Renderer {
      ECS.ComponentList<Components.Transform> transforms;
      ECS.ComponentList<Components.Avatar> avatars;

      int transformsPos;

      public Renderer(ECS.ComponentList<Components.Avatar> a,
            ECS.ComponentList<Components.Transform> t, int tPos) {
         transforms = t;
         avatars = a;

         transformsPos = tPos;
      }

      public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
         for (ushort i = 0; i < avatars.size; i++) {
            ECS.Entity entity = avatars.metadata[i].entity;
            int transformIndex;

            if (entity.components[transformsPos] == -1) continue;
            else transformIndex = entity.components[transformsPos];

            Components.Animation animation = avatars.data[i].currentAnimation;

            animation.Run(gameTime);
            spriteBatch.Draw(animation.spriteSheet, transforms.data[transformIndex].position, animation.Rect(), Color.White);
         }
      }
   }
}
