namespace E_Commerce_Business.Abstract
{
   public interface ICacheService
   {
      T GetData<T>(string key);

      bool SetData<T>(string key, T value, DateTimeOffset expirationTime);
      object RemoveData(string key);


      Task Clear(string key);
      void ClearAll();
   }
}
