namespace ECS {
   public class Entity {
      public ushort id;
      public int[] components;

      public Entity(ushort ident, ushort numComponents) {
         id = ident;
         components = new int[numComponents];

         for (ushort i = 0; i < numComponents; i++)
            components[i] = -1;
      }
   }
}
