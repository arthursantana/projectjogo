using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Prefabs {
   public static class TestSquare {
      public static void Create(ECS.Scene scene,
            ECS.ComponentList<Components.Transform> transforms,
            ECS.ComponentList<Components.Body> bodies,
            ECS.ComponentList<Components.Avatar> avatars,
            Random random) {
         ushort pos; int size; Color[] colorData; Color c;

         Color[] colors = new Color[5];
         colors[0] = Color.DarkRed * 0.5f;
         colors[1] = Color.Red * 0.5f;
         colors[2] = Color.Orange * 0.5f;
         colors[3] = Color.Yellow * 0.5f;
         colors[4] = Color.Pink * 0.5f;

         ECS.Entity e = scene.NewEntity();

         pos = scene.AttachComponent<Components.Transform>(e, transforms);
         transforms.data[pos].position.X = 200;
         transforms.data[pos].position.Y = 200;

         pos = scene.AttachComponent<Components.Body>(e, bodies);
         bodies.data[pos].velocity.X = 0;
         bodies.data[pos].velocity.Y = 0;

         pos = scene.AttachComponent<Components.Avatar>(e, avatars);
         size = (int) (8.0 * random.NextDouble() + 1);
         avatars.data[pos].texture = new Texture2D(scene.game.GraphicsDevice, size, size);
         colorData = new Color[size * size];
         c = colors[random.Next() % 5];
         for (int i = 0; i < size*size; i++)
            colorData[i] = c;
         avatars.data[pos].texture.SetData<Color>(colorData);
      }
   }
}
