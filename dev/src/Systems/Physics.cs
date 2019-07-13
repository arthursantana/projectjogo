using Microsoft.Xna.Framework;
using System;

namespace Systems {
   public class Physics {

      Random random = new Random();

      public void Update(GameTime gameTime, Components.Transform[] transforms, Components.Body[] bodies, int W, int H) {
         int size = 50;
         for (int i = 0; i < 2; i++) {
            bodies[i].velocity.X += size * (float) (random.NextDouble() - 0.5);
            bodies[i].velocity.Y += size * (float) (random.NextDouble() - 0.5);
            transforms[i].position.X += bodies[i].velocity.X * (float) gameTime.ElapsedGameTime.TotalSeconds;
            transforms[i].position.Y += bodies[i].velocity.Y * (float) gameTime.ElapsedGameTime.TotalSeconds;
            if (transforms[i].position.X > W)
               transforms[i].position.X = 0;
            if (transforms[i].position.Y > H)
               transforms[i].position.Y = 0;
            if (transforms[i].position.X < -size)
               transforms[i].position.X = W;
            if (transforms[i].position.Y < -size)
               transforms[i].position.Y = H;
         }
      }

   }
}
