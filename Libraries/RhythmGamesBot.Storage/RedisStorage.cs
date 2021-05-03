namespace RhythmGamesBot.Storage
{
    using ServiceStack.Redis;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Redis connection class, should only exist as a singleton
    /// </summary>
    public class RedisStorage
    {
        private RedisManagerPool RedisManager { get; }

        public RedisStorage(string connectionString)
        {
            RedisManager = new RedisManagerPool(connectionString);
        }

        /// <summary>
        /// Returns a disposable Read/Write client
        /// </summary>
        /// <returns><see cref="IRedisClient"/></returns>
        public IRedisClient GetClient()
        {
            return RedisManager.GetClient();
        }

        /// <summary>
        /// Returns a disposable Read/Write async client
        /// </summary>
        /// <returns><see cref="IRedisClientAsync"/></returns>
        public async Task<IRedisClientAsync> GetClientAsync()
        {
            return await RedisManager.GetClientAsync();
        }

        /// <summary>
        /// Returns a disposable Read client
        /// </summary>
        /// <returns><see cref="IRedisClient"/></returns>
        public IRedisClient GetReadOnlyClient()
        {
            return RedisManager.GetReadOnlyClient();
        }

        /// <summary>
        /// Returns a disposable Read async client
        /// </summary>
        /// <returns><see cref="IRedisClientAsync"/></returns>
        public async Task<IRedisClientAsync> GetReadOnlyClientAsync()
        {
            return await RedisManager.GetReadOnlyClientAsync();
        }
    }
}
