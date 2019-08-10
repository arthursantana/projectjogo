using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Prefabs {
   public static class Kirk {
      public static void Create(ECS.Scene scene,
            ECS.ComponentList<Components.Transform> transforms,
            ECS.ComponentList<Components.Body> bodies,
            ECS.ComponentList<Components.Behavior> behaviors,
            ECS.ComponentList<Components.Avatar> avatars,
            Random random, int W, int H) {
         ushort pos;

         ECS.Entity e = scene.NewEntity();

         pos = scene.AttachComponent<Components.Transform>(e, transforms);
         transforms.data[pos].position.X = (float) random.NextDouble() * W;
         transforms.data[pos].position.Y = (float) random.NextDouble() * H;

         pos = scene.AttachComponent<Components.Body>(e, bodies);
         bodies.data[pos].velocity.X = 0;
         bodies.data[pos].velocity.Y = 0;

         pos = scene.AttachComponent<Components.Behavior>(e, behaviors);
         behaviors.data[pos].isPlayerControlled = false;

         pos = scene.AttachComponent<Components.Avatar>(e, avatars);
         avatars.data[pos].animations = new Dictionary<string, Components.Animation>();

         Components.Animation parado = new Components.Animation(scene, "kirk_idle", 14, 21, new int[] {140, 140}, true);
         Components.Animation andando = new Components.Animation(scene, "kirk_walk", 14, 21, new int[] {140, 140}, true);
         avatars.data[pos].animations.Add("parado", parado);
         avatars.data[pos].animations.Add("andando", andando);
         avatars.data[pos].currentAnimation = andando;
      }
   }
}
