using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Scenes {
   public class TestScene : ECS.Scene {
      ECS.ComponentList<Components.Transform> transforms;
      ECS.ComponentList<Components.Body> bodies;
      ECS.ComponentList<Components.Avatar> avatars;

      Systems.Physics physics;
      Systems.Renderer renderer;

      public TestScene(TopLevel.Game1 g, SpriteBatch sb) : base(g, sb) {
         transforms = RegisterComponentList<Components.Transform>();
         bodies = RegisterComponentList<Components.Body>();
         avatars = RegisterComponentList<Components.Avatar>();

         physics = new Systems.Physics(transforms, bodies);
         renderer = new Systems.Renderer(transforms, avatars);

         Random random = new Random();
         ushort pos; int size; Color[] colorData; Color c;

         Color[] colors = new Color[5];
         colors[0] = Color.DarkRed * 0.5f;
         colors[1] = Color.DarkGreen * 0.5f;
         colors[2] = Color.DarkBlue * 0.5f;
         colors[3] = Color.Black * 0.5f;
         colors[4] = Color.DarkGray * 0.5f;
         for (ushort entityId = 0; entityId < 10; entityId++) {
            /*
            ECS.Entity e = newEntity();

            pos = attachComponent<Component.Transform>(e, transforms);
            transforms.data[pos].position.X = 200;
            transforms.data[pos].position.Y = 200;

            pos = attachComponent<Component.Body>(e, bodies);
            bodies.data[pos].velocity.X = 0;
            bodies.data[pos].velocity.Y = 0;

            pos = attachComponent<Component.Avatar>(e, avatars);
            size = (int) (75.0 * random.NextDouble() + 1);
            avatars.data[pos].texture = new Texture2D(game.GraphicsDevice, size, size);
            colorData = new Color[size * size];
            c = colors[random.Next() % 5];
            for (int i = 0; i < size*size; i++)
               colorData[i] = c;
            avatars.data[pos].texture.SetData<Color>(colorData);

            */
            pos = transforms.newItem(entityId);
            transforms.data[pos].position.X = 200;
            transforms.data[pos].position.Y = 200;

            pos = bodies.newItem(entityId);
            bodies.data[pos].velocity.X = 0;
            bodies.data[pos].velocity.Y = 0;

            pos = avatars.newItem(entityId);
            size = (int) (75.0 * random.NextDouble() + 1);
            avatars.data[pos].texture = new Texture2D(game.GraphicsDevice, size, size);
            colorData = new Color[size * size];
            c = colors[random.Next() % 5];
            for (int i = 0; i < size*size; i++)
               colorData[i] = c;
            avatars.data[pos].texture.SetData<Color>(colorData);
         }
      }

      public new void Update(GameTime gameTime) {
         physics.Update(gameTime, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
      }

      public new void Draw(GameTime gameTime) {
         renderer.Draw(gameTime, spriteBatch);
      }
   }
}
