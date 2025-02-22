using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Prefabs {
   public static class Bolinha {
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

         Components.Animation andando = new Components.Animation(scene, "bolinha", 32, 32, new int[] {500, 300, 200, 100, 100, 100, 100, 100, 100, 100, 100, 200, 300}, true);
         Components.Animation parada = new Components.Animation(scene, "bolinha", 32, 32, new int[] {1}, false);
         avatars.data[pos].animations.Add("parada", parada);
         avatars.data[pos].animations.Add("andando", andando);
         avatars.data[pos].currentAnimation = andando;
      }
   }
}
