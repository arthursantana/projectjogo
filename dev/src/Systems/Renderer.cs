using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Systems {
   public class Renderer {

      public void Draw(ECS.ComponentList<Components.Transform> transforms, SpriteBatch spriteBatch, Texture2D texture) {
         for (int i = 0; i < transforms.size; i++) {
            spriteBatch.Draw(texture, transforms.data[i].position);
         }
      }

   }
}
