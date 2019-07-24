namespace ECS {
   public struct Metadata {
      public ushort entityId;
      public bool alive;
   }

   public class ComponentList<T> {
      static ushort MAXENTITIES = 2000; // 32000 (tamanho de um short)? dinâmico (provavelmente sim no futuro)?

      public T[] data;
      public Metadata[] metadata;
      public ushort size;

      public ComponentList() {
         data = new T[MAXENTITIES];
         metadata = new Metadata[MAXENTITIES];
         size = 0;
      }

      public ushort newItem(ushort eId) {
         metadata[size].entityId = eId;
         metadata[size].alive = true;

         return size++;
      }
   }
}
