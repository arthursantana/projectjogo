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

         physics = new Systems.Physics(
               transforms, componentListIndices[typeof(Components.Transform)],
               bodies, componentListIndices[typeof(Components.Body)]
               );
         renderer = new Systems.Renderer(
               transforms, componentListIndices[typeof(Components.Transform)],
               avatars, componentListIndices[typeof(Components.Avatar)]
               );

         Random random = new Random();
         for (ushort i = 0; i < 10000; i++) {
            Prefabs.Bolinha.Create(this, transforms, bodies, avatars, random);
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
