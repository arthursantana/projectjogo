using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace TopLevel {
   public class Scene {
      protected SpriteBatch spriteBatch;
      protected Game1 game;
      protected Dictionary<Type, ushort> componentIndices;
      protected ushort numComponents;

      public Scene(Game1 g, SpriteBatch sb) {
         game = g;
         spriteBatch = sb;

         componentIndices = new Dictionary<Type, ushort>();
         numComponents = 0;
      }

      public Util.Pool<T> RegisterComponentList<T>() {
         Util.Pool<T> list = new Util.Pool<T>();

         componentIndices.Add(typeof(T), numComponents);
         numComponents++;

         return list;
      }

      public void Update(GameTime gameTime) {}

      public void Draw(GameTime gameTime) {}
   }
}
