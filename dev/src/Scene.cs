using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ECS {
   public class Scene {
      protected TopLevel.Game1 game;
      protected SpriteBatch spriteBatch;

      protected Dictionary<Type, ushort> componentListIndices;
      protected ushort numComponents;

      public Scene(TopLevel.Game1 g, SpriteBatch sb) {
         game = g;
         spriteBatch = sb;

         componentListIndices = new Dictionary<Type, ushort>();
         numComponents = 0;
      }

      public void Update(GameTime gameTime) {}

      public void Draw(GameTime gameTime) {}

      public ECS.ComponentList<T> RegisterComponentList<T>() {
         ECS.ComponentList<T> list = new ECS.ComponentList<T>();

         componentListIndices.Add(typeof(T), numComponents);
         numComponents++;

         return list;
      }
   }
}
