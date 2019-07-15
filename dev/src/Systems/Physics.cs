using Microsoft.Xna.Framework;
using System;

namespace Systems {
   public class Physics {
      public ECS.ComponentList<Components.Transform> transforms;

      public Physics(ECS.ComponentList<Components.Transform> t) {
         transforms = t;
      }

      Random random = new Random();
      public void Update(GameTime gameTime, ECS.ComponentList<Components.Body> bodies, int W, int H) {
         int size = 50;
         for (int i = 0; i < transforms.size; i++) {
            bodies.data[i].velocity.X += size * (float) (random.NextDouble() - 0.5);
            bodies.data[i].velocity.Y += size * (float) (random.NextDouble() - 0.5);
            transforms.data[i].position.X += bodies.data[i].velocity.X * (float) gameTime.ElapsedGameTime.TotalSeconds;
            transforms.data[i].position.Y += bodies.data[i].velocity.Y * (float) gameTime.ElapsedGameTime.TotalSeconds;
            if (transforms.data[i].position.X > W)
               transforms.data[i].position.X = 0;
            if (transforms.data[i].position.Y > H)
               transforms.data[i].position.Y = 0;
            if (transforms.data[i].position.X < -size)
               transforms.data[i].position.X = W;
            if (transforms.data[i].position.Y < -size)
               transforms.data[i].position.Y = H;
         }
      }

   }
}
