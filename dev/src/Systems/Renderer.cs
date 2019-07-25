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

            spriteBatch.Draw(avatars.data[i].texture, transforms.data[j].position, Color.White);
         }
      }
   }
}
