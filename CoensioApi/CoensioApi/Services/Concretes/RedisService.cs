using CoensioApi.Services.Abstracts;
using StackExchange.Redis;
using System.Text.Json;

namespace CoensioAPI.Services.Concretes
{
    public class RedisService : ICacheService
    {
        private IDatabase _cacheDB;
        private readonly IConfiguration _configuration;
        public RedisService(IConfiguration configuration)
        {
            _configuration = configuration;
            Console.WriteLine(_configuration["Redis"]);
            var redis = ConnectionMultiplexer.Connect(_configuration["Redis"]);
            _cacheDB = redis.GetDatabase();
        }
        public T GetData<T>(string key)
        {
            var value = _cacheDB.StringGet(key);
            if (!string.IsNullOrEmpty(value))
                return JsonSerializer.Deserialize<T>(value);

            return default;
        }

        public object RemoveData(string key)
        {
            var _exist = _cacheDB.KeyExists(key);
            if(_exist) 
                return _cacheDB.KeyDelete(key);

            return false;
        }

        public bool SetData<T>(string key, T value)
        {
            var isSet = _cacheDB.StringSet(key, JsonSerializer.Serialize(value));
            return isSet;
        }
    }
}
