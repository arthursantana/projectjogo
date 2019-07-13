using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Systems {
   public class Renderer {

      public void Draw(Components.Transform[] transforms, SpriteBatch spriteBatch, Texture2D texture) {
         foreach (Components.Transform t in transforms) {
            spriteBatch.Draw(texture, t.position);
         }
      }

   }
}
