using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Scenes {
   public class TestScene : TopLevel.Scene {
      Util.Pool<Components.Transform> transforms;
      Util.Pool<Components.Body> bodies;
      Util.Pool<Components.Avatar> avatars;

      Systems.Physics physics;
      Systems.Renderer renderer;
      
      public TestScene(TopLevel.Game1 g, SpriteBatch sb) : base(g, sb) {
         transforms = RegisterComponentList<Components.Transform>();
         bodies = RegisterComponentList<Components.Body>();
         avatars = RegisterComponentList<Components.Avatar>();

         physics = new Systems.Physics(transforms);
         renderer = new Systems.Renderer();

         Random random = new Random();
         ushort id; int size; Color[] colorData; Color c;

         Color[] colors = new Color[5];
         colors[0] = Color.DarkRed * 0.5f;
         colors[1] = Color.DarkGreen * 0.5f;
         colors[2] = Color.DarkBlue * 0.5f;
         colors[3] = Color.Black * 0.5f;
         colors[4] = Color.DarkGray * 0.5f;
         for (int iter = 0; iter < 2500; iter++) {
            id = transforms.newItem();
            transforms.data[id].position.X = 200;
            transforms.data[id].position.Y = 200;

            id = bodies.newItem();
            bodies.data[id].velocity.X = 0;
            bodies.data[id].velocity.Y = 0;

            id = avatars.newItem();
            size = (int) (15.0 * random.NextDouble() + 1);
            avatars.data[id].texture = new Texture2D(game.GraphicsDevice, size, size);
            colorData = new Color[size * size];
            c = colors[random.Next() % 5];
            for (int i = 0; i < size*size; i++)
               colorData[i] = c;
            avatars.data[id].texture.SetData<Color>(colorData);
         }
      }

      public new void Update(GameTime gameTime) {
         physics.Update(gameTime, bodies, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
      }

      public new void Draw(GameTime gameTime) {
         renderer.Draw(gameTime, spriteBatch, transforms, avatars);
      }
   }
}
