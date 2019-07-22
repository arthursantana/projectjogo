namespace Util {
   public class Pool<T> {
      public static int MAXENTITIES = 10; // 32000 (tamanho de um short)? dinâmico (provavelmente sim no futuro)?

      public T[] data;
      public ushort size;

      public Pool() {
         data = new T[MAXENTITIES];
         size = 0;
      }
   }
}
