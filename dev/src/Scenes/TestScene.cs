using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Scenes {
   public class TestScene : ECS.Scene {
      ECS.ComponentList<Components.Transform> transforms;
      ECS.ComponentList<Components.Body> bodies;
      ECS.ComponentList<Components.Behavior> behaviors;
      ECS.ComponentList<Components.Avatar> avatars;

      Systems.Behavior behavior;
      Systems.Physics physics;
      Systems.Renderer renderer;

      int W = /*640;// */GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
      int H = /*420;// */GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

      public TestScene(TopLevel.Game1 g, SpriteBatch sb) : base(g, sb) {
         transforms = RegisterComponentList<Components.Transform>();
         bodies = RegisterComponentList<Components.Body>();
         behaviors = RegisterComponentList<Components.Behavior>();
         avatars = RegisterComponentList<Components.Avatar>();

         behavior = new Systems.Behavior(
               behaviors,
               bodies, componentListIndices[typeof(Components.Body)],
               avatars, componentListIndices[typeof(Components.Avatar)]);
         physics = new Systems.Physics(
               transforms, componentListIndices[typeof(Components.Transform)],
               bodies, componentListIndices[typeof(Components.Body)]);
         renderer = new Systems.Renderer(
               avatars,
               transforms, componentListIndices[typeof(Components.Transform)]);

         Prefabs.Vivo.Create(this, transforms, bodies, behaviors, avatars);
         Random random = new Random();
         for (ushort i = 0; i < 500; i++) {
            if (random.NextDouble() > 0.5)
               Prefabs.Kirk.Create(this, transforms, bodies, behaviors, avatars, random, W, H);
            else
               Prefabs.Bolinha.Create(this, transforms, bodies, behaviors, avatars, random, W, H);
         }
      }

      public new void Update(GameTime gameTime) {
         behavior.Update(gameTime);
         physics.Update(gameTime, W, H);
      }

      public new void Draw(GameTime gameTime) {
         renderer.Draw(gameTime, spriteBatch);
      }
   }
}
