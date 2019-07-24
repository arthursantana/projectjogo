using Microsoft.Xna.Framework;
using System;

namespace Systems {
   public class Physics {
      ECS.ComponentList<Components.Transform> transforms;
      ECS.ComponentList<Components.Body> bodies;

      public Physics(ECS.ComponentList<Components.Transform> t, ECS.ComponentList<Components.Body> b) {
         transforms = t;
         bodies = b;
      }

      Random random = new Random();

      public void Update(GameTime gameTime, int W, int H) {
         int temperature = 5;

         for (ushort i = 0; i < transforms.size; i++) {
            bodies.data[i].velocity.X += temperature * (float) (random.NextDouble() - 0.5);
            bodies.data[i].velocity.Y += temperature * (float) (random.NextDouble() - 0.5);
            transforms.data[i].position.X += bodies.data[i].velocity.X * (float) gameTime.ElapsedGameTime.TotalSeconds;
            transforms.data[i].position.Y += bodies.data[i].velocity.Y * (float) gameTime.ElapsedGameTime.TotalSeconds;
            if (transforms.data[i].position.X > W)
               transforms.data[i].position.X = 0;
            if (transforms.data[i].position.Y > H)
               transforms.data[i].position.Y = 0;
            if (transforms.data[i].position.X < -100)
               transforms.data[i].position.X = W;
            if (transforms.data[i].position.Y < -100)
               transforms.data[i].position.Y = H;
         }
      }

   }
}
