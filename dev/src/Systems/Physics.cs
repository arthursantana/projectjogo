using Microsoft.Xna.Framework;
using System;

namespace Systems {
   public class Physics {
      ECS.ComponentList<Components.Transform> transforms;
      ECS.ComponentList<Components.Body> bodies;

      int transformsPos;
      int bodiesPos;

      public Physics(ECS.ComponentList<Components.Transform> t, int tPos,
            ECS.ComponentList<Components.Body> b, int bPos) {
         transforms = t;
         bodies = b;

         transformsPos = tPos;
         bodiesPos = bPos;
      }

      public void Update(GameTime gameTime, int W, int H) {
         for (ushort i = 0; i < transforms.size; i++) {
            ECS.Entity entity = transforms.metadata[i].entity;
            int bodyIndex;

            if (entity.components[bodiesPos] == -1) continue;
            else bodyIndex = entity.components[bodiesPos];

            transforms.data[i].position.X += bodies.data[bodyIndex].velocity.X * (float) gameTime.ElapsedGameTime.TotalSeconds;
            transforms.data[i].position.Y += bodies.data[bodyIndex].velocity.Y * (float) gameTime.ElapsedGameTime.TotalSeconds;
            if (transforms.data[i].position.X > W)
               transforms.data[i].position.X = 0;
            if (transforms.data[i].position.Y > H)
               transforms.data[i].position.Y = 0;
            if (transforms.data[i].position.X < -32)
               transforms.data[i].position.X = W;
            if (transforms.data[i].position.Y < -32)
               transforms.data[i].position.Y = H;

            if (i != 0) {
               float distX = transforms.data[i].position.X - transforms.data[0].position.X;
               float distY = transforms.data[i].position.Y - transforms.data[0].position.Y;

               float epsilon = 8*32f;
               if (distX*distX + distY*distY < epsilon) {
                  entity.components[transformsPos] = -1;
               }
            }
         }
      }
   }
}
