using System;

namespace api_management_redis.Services
{
    public class RedisService
    {

        #region Readonly Fields
        private readonly string _serviceUri;
        private readonly string _usernmame;
        private readonly string _password;
        #endregion

        public RedisService(string serviceUri, string username, string password)
        {
            _serviceUri = serviceUri;
            _usernmame = username;
            _password = password;
        }

        public bool Connect()
        {
            return true;
        }
    }
}