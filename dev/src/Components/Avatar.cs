using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Components {
   public class Animation {
      public Texture2D spriteSheet;
      public int width;
      public int height;
      public int[] frames;
      public int numberOfFrames;
      public bool isALoop;
      public int currentFrame;
      public double timeLeftInFrame;

      public Animation(ECS.Scene scene, string sS, int w, int h, int[] f, bool iAL) {
         spriteSheet = scene.game.Content.Load<Texture2D>(sS);
         width = w;
         height = h;
         frames = f;
         numberOfFrames = f.Length;
         isALoop = iAL;
         currentFrame = 0;
         timeLeftInFrame = f[0]; // in milliseconds
      }

      public void Run(GameTime gameTime) {
         double timeSpent = gameTime.ElapsedGameTime.TotalMilliseconds;

         while (timeSpent > 0) {
            if (!isALoop && currentFrame == numberOfFrames) return;

            if (timeSpent > timeLeftInFrame) {
               timeSpent -= timeLeftInFrame;
               currentFrame = (currentFrame + 1) % numberOfFrames;
               timeLeftInFrame = frames[currentFrame];
            } else {
               timeLeftInFrame -= timeSpent;
               timeSpent = 0;
            }
         }
      }

      public Rectangle Rect() {
         return new Rectangle(currentFrame * width, 0, width, height);
      }
   }

   public struct Avatar {
      public Animation currentAnimation;
      public Dictionary<string, Animation> animations;
   }
}
