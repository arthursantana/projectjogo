public static class Const {
   public static int MAXENTITIES = 10;
}

namespace ECS {
   public class ComponentList<T> {
      public T[] data;
      public int size;

      public ComponentList() {
         data = new T[Const.MAXENTITIES];
         size = 0;
      }
   }
}
