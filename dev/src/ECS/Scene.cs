using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ECS {
   public class Scene {
      public TopLevel.Game1 game;
      protected SpriteBatch spriteBatch;

      protected Dictionary<Type, ushort> componentListIndices;
      protected ushort numComponents;

      protected ushort lastEntity;

      public Scene(TopLevel.Game1 g, SpriteBatch sb) {
         game = g;
         spriteBatch = sb;

         componentListIndices = new Dictionary<Type, ushort>();
         numComponents = 0;

         lastEntity = 0;
      }

      public void Update(GameTime gameTime) {}

      public void Draw(GameTime gameTime) {}

      public ECS.ComponentList<T> RegisterComponentList<T>() {
         ECS.ComponentList<T> list = new ECS.ComponentList<T>();

         componentListIndices.Add(typeof(T), numComponents);
         numComponents++;

         return list;
      }

      public ushort AttachComponent<T>(ECS.Entity e, ComponentList<T> list) {
         ushort posComponent = componentListIndices[typeof(T)];

         e.components[posComponent] = list.NewItem(e);

         return (ushort) e.components[posComponent];
      }

      public ECS.Entity NewEntity() {
            ECS.Entity e = new ECS.Entity(lastEntity++, (ushort) componentListIndices.Count);

            return e;
      }
   }
}
