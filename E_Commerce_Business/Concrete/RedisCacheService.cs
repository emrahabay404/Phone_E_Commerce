using E_Commerce_Business.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace E_Commerce_Business.Concrete
{
   public class RedisCacheService : ICacheService
   {
      private readonly IConnectionMultiplexer _redisCon;
      private readonly IDatabase _cache;
      private TimeSpan ExpireTime => TimeSpan.FromMinutes(30);
      public RedisCacheService(IConnectionMultiplexer redisCon)
      {
         _redisCon = redisCon;
         _cache = redisCon.GetDatabase();
      }

      public async Task Clear(string key)
      {
         await _cache.KeyDeleteAsync(key);
      }

      public void ClearAll()
      {
         var endpoints = _redisCon.GetEndPoints(true);
         foreach (var endpoint in endpoints)
         {
            var server = _redisCon.GetServer(endpoint);
            server.FlushAllDatabases();
         }
      }
 
      public T GetData<T>(string key)
      {
         var value = _cache.StringGet(key);
         if (!string.IsNullOrEmpty(value))
         {
            return JsonConvert.DeserializeObject<T>(value);
         }
         return default;
      }

      public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
      {
         TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
         var isSet = _cache.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
         return isSet;
      }

      public object RemoveData(string key)
      {
         bool _isKeyExist = _cache.KeyExists(key);
         if (_isKeyExist == true)
         {
            return _cache.KeyDelete(key);
         }
         return false;
      }

   }
}
