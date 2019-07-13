using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Global {
   public class Scene {
      Texture2D texture;

      Components.Transform[] transforms;
      Components.Body[] bodies;

      Systems.Physics physics;
      Systems.Renderer renderer;

      SpriteBatch spriteBatch;
      Game1 game;
   
      public Scene(Game1 g, SpriteBatch sb) {
         game = g;
         spriteBatch = sb;

         transforms = new Components.Transform[2];
         bodies = new Components.Body[2];

         physics = new Systems.Physics();
         renderer = new Systems.Renderer();

         int size = 50;
         texture = new Texture2D(game.GraphicsDevice, size, size);
         Color[] colorData = new Color[size * size];
         for (int i = 0; i < size*size; i++)
            colorData[i] = Color.DarkRed;
         texture.SetData<Color>(colorData);

         transforms[0].position.X = 100;
         transforms[0].position.Y = 200;
         transforms[1].position.X = 100;
         transforms[1].position.Y = 100;
         bodies[0].velocity.X = 0;
         bodies[0].velocity.Y = 0;
         bodies[1].velocity.X = 0;
         bodies[1].velocity.Y = 0;
      }

      public void Update(GameTime gameTime) {
         physics.Update(gameTime, transforms, bodies, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
      }

      public void Render(GameTime gameTime) {
         renderer.Draw(transforms, spriteBatch, texture);
      }
   }
}
