using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace TopLevel {
   public class Scene {
      SpriteBatch spriteBatch;
      Game1 game;
      Dictionary<Type, ushort> componentIndices;
      ushort numComponents;


      // the rest of the attributes are a specialization, won't be in the base class
      Texture2D texture;

      Util.Pool<Components.Transform> transforms;
      Util.Pool<Components.Body> bodies;

      Systems.Physics physics;
      Systems.Renderer renderer;

      public Util.Pool<T> RegisterComponentList<T>() {
         Util.Pool<T> list = new Util.Pool<T>();

         componentIndices.Add(typeof(T), numComponents);
         numComponents++;

         return list;
      }
   
      public Scene(Game1 g, SpriteBatch sb) {
         game = g;
         spriteBatch = sb;

         componentIndices = new Dictionary<Type, ushort>();
         numComponents = 0;

         // same as above
         transforms = RegisterComponentList<Components.Transform>();
         bodies = RegisterComponentList<Components.Body>();

         Console.WriteLine(componentIndices[typeof(Components.Transform)]);
         Console.WriteLine(componentIndices[typeof(Components.Body)]);

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
