using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Systems {
   public class Renderer {
      ECS.ComponentList<Components.Transform> transforms;
      ECS.ComponentList<Components.Avatar> avatars;

      int transformsPos;

      public Renderer(ECS.ComponentList<Components.Transform> t, int tPos, ECS.ComponentList<Components.Avatar> a, int aPos) {
         transforms = t;
         avatars = a;

         transformsPos = tPos;
      }

      public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
         for (ushort i = 0; i < avatars.size; i++) {
            ECS.Entity entity = avatars.metadata[i].entity;
            int j; // entity transform index

            if (entity.components[transformsPos] == -1) continue;
            else j = entity.components[transformsPos];

            if (avatars.data[i].isSpriteSheet)
               spriteBatch.Draw(avatars.data[i].texture, transforms.data[j].position, new Rectangle(32*(((int) gameTime.TotalGameTime.TotalMilliseconds / 100 + avatars.data[i].timeOffset) % 13), 0, 32, 32), Color.White);
            else
               spriteBatch.Draw(avatars.data[i].texture, transforms.data[j].position, Color.White);
         }
      }
   }
}
