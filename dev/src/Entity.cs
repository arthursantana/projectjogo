namespace ECS {
   public class Entity {
      public ushort id;
      public ushort[] components;

      public Entity(ushort numComponents) {
         components = new ushort[numComponents];
      }
   }
}
