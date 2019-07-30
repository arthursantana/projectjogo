using Microsoft.Xna.Framework;
using System;

namespace Systems {
   public class Physics {
      ECS.ComponentList<Components.Transform> transforms;
      ECS.ComponentList<Components.Body> bodies;

      int bodiesPos;

      public Physics(ECS.ComponentList<Components.Transform> t, int tPos, ECS.ComponentList<Components.Body> b, int bPos) {
         transforms = t;
         bodies = b;

         bodiesPos = bPos;
      }

      Random random = new Random();

      public void Update(GameTime gameTime, int W, int H) {
         int temperature = 2;

         for (ushort i = 0; i < transforms.size; i++) {
            ECS.Entity entity = transforms.metadata[i].entity;
            int j; // entity body index

            if (entity.components[bodiesPos] == -1) continue;
            else j = entity.components[bodiesPos];

            bodies.data[j].velocity.X += temperature * (float) (random.NextDouble() - 0.5);
            bodies.data[j].velocity.Y += temperature * (float) (random.NextDouble() - 0.5);
            transforms.data[i].position.X += bodies.data[j].velocity.X * (float) gameTime.ElapsedGameTime.TotalSeconds;
            transforms.data[i].position.Y += bodies.data[j].velocity.Y * (float) gameTime.ElapsedGameTime.TotalSeconds;
            if (transforms.data[i].position.X > W)
               transforms.data[i].position.X = 0;
            if (transforms.data[i].position.Y > H)
               transforms.data[i].position.Y = 0;
            if (transforms.data[i].position.X < -32)
               transforms.data[i].position.X = W;
            if (transforms.data[i].position.Y < -32)
               transforms.data[i].position.Y = H;
         }
      }
   }
}
