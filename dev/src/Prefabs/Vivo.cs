using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Prefabs {
   public static class Vivo {
      public static void Create(ECS.Scene scene,
            ECS.ComponentList<Components.Transform> transforms,
            ECS.ComponentList<Components.Body> bodies,
            ECS.ComponentList<Components.Behavior> behaviors,
            ECS.ComponentList<Components.Avatar> avatars) {
         ushort pos;

         ECS.Entity e = scene.NewEntity();

         pos = scene.AttachComponent<Components.Transform>(e, transforms);
         transforms.data[pos].position.X = 200;
         transforms.data[pos].position.Y = 200;

         pos = scene.AttachComponent<Components.Body>(e, bodies);
         bodies.data[pos].velocity.X = 0;
         bodies.data[pos].velocity.Y = 0;

         pos = scene.AttachComponent<Components.Behavior>(e, behaviors);
         behaviors.data[pos].isPlayerControlled = true;

         pos = scene.AttachComponent<Components.Avatar>(e, avatars);
         avatars.data[pos].animations = new Dictionary<string, Components.Animation>();

         Components.Animation parado = new Components.Animation(scene, "vivo_idle", 32, 32, new int[] {100, 100}, true);
         Components.Animation andando = new Components.Animation(scene, "vivo_walk", 32, 32, new int[] {100, 100}, true);
         avatars.data[pos].animations.Add("parado", parado);
         avatars.data[pos].animations.Add("andando", andando);
         avatars.data[pos].currentAnimation = parado;
      }
   }
}
