using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TopLevel {
   public class Scene {
      Texture2D texture;

      ECS.ComponentList<Components.Transform> transforms;
      ECS.ComponentList<Components.Body> bodies;

      Systems.Physics physics;
      Systems.Renderer renderer;

      SpriteBatch spriteBatch;
      Game1 game;
   
      public Scene(Game1 g, SpriteBatch sb) {
         game = g;
         spriteBatch = sb;

         transforms = new ECS.ComponentList<Components.Transform>();
         bodies = new ECS.ComponentList<Components.Body>();

         physics = new Systems.Physics(transforms);
         renderer = new Systems.Renderer();

         int size = 50;
         texture = new Texture2D(game.GraphicsDevice, size, size);
         Color[] colorData = new Color[size * size];
         for (int i = 0; i < size*size; i++)
            colorData[i] = Color.DarkRed;
         texture.SetData<Color>(colorData);

         transforms.data[0].position.X = 100;
         transforms.data[0].position.Y = 200;
         transforms.data[1].position.X = 100;
         transforms.data[1].position.Y = 100;
         transforms.size = 2;
         bodies.data[0].velocity.X = 0;
         bodies.data[0].velocity.Y = 0;
         bodies.data[1].velocity.X = 0;
         bodies.data[1].velocity.Y = 0;
         bodies.size = 2;
      }

      public void Update(GameTime gameTime) {
         physics.Update(gameTime, bodies, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
      }

      public void Draw(GameTime gameTime) {
         renderer.Draw(transforms, spriteBatch, texture);
      }
   }
}
