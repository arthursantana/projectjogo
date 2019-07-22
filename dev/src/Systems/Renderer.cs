using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Systems {
   public class Renderer {

      public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Util.Pool<Components.Transform> transforms, Util.Pool<Components.Avatar> avatars) {
         for (ushort i = 0; i < transforms.size; i++) {
            spriteBatch.Draw(avatars.data[i].texture, transforms.data[i].position, Color.White);
         }
      }

   }
}
