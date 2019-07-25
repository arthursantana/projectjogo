namespace ECS {
   public struct Metadata {
      public ECS.Entity entity;
      public bool alive;
   }

   public class ComponentList<T> {
      static ushort MAXENTITIES = 32000; // 32000 (tamanho de um short)? dinâmico (provavelmente sim no futuro)?

      public T[] data;
      public Metadata[] metadata;
      public ushort size;

      public ComponentList() {
         data = new T[MAXENTITIES];
         metadata = new Metadata[MAXENTITIES];
         size = 0;
      }

      public ushort NewItem(ECS.Entity e) {
         metadata[size].entity = e;;
         metadata[size].alive = true;

         return size++;
      }
   }
}
