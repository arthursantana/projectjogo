using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Systems {
   public class Renderer {
      ECS.ComponentList<Components.Transform> transforms;
      ECS.ComponentList<Components.Avatar> avatars;

      public Renderer(ECS.ComponentList<Components.Transform> t, ECS.ComponentList<Components.Avatar> a) {
         transforms = t;
         avatars = a;
      }

      public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
         for (ushort i = 0; i < transforms.size; i++) {
            spriteBatch.Draw(avatars.data[i].texture, transforms.data[i].position, Color.White);
         }
      }

   }
}
