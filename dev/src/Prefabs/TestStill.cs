using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Prefabs {
   public static class TestStill {
      public static void Create(ECS.Scene scene,
            ECS.ComponentList<Components.Transform> transforms,
            ECS.ComponentList<Components.Avatar> avatars,
            Random random) {
         ushort pos; int size; Color[] colorData; Color c;

         Color[] colors = new Color[5];
         colors[0] = Color.Blue * 0.5f;
         colors[1] = Color.DarkGreen * 0.5f;
         colors[2] = Color.DarkBlue * 0.5f;
         colors[3] = Color.Black * 0.5f;
         colors[4] = Color.Green * 0.5f;

         ECS.Entity e = scene.NewEntity();

         pos = scene.AttachComponent<Components.Transform>(e, transforms);
         transforms.data[pos].position.X = (float) random.NextDouble() * 1366;
         transforms.data[pos].position.Y = (float) random.NextDouble() * 768;

         pos = scene.AttachComponent<Components.Avatar>(e, avatars);
         size = (int) (4.0 * random.NextDouble() + 1);
         avatars.data[pos].texture = new Texture2D(scene.game.GraphicsDevice, size, size);
         colorData = new Color[size * size];
         c = colors[random.Next() % 5];
         for (int i = 0; i < size*size; i++)
            colorData[i] = c;
         avatars.data[pos].texture.SetData<Color>(colorData);
      }
   }
}
