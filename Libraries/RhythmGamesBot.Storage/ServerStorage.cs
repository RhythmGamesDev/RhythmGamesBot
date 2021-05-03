namespace RhythmGamesBot.Storage
{
    using RhythmGamesBot.Models;
    using RhythmGamesBot.Storage.Mappers;
    using RhythmGamesBot.Storage.Models;
    using ServiceStack.Redis;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ServerStorage
    {
        private RedisStorage redisStorage { get; }

        public ServerStorage(RedisStorage redis)
        {
            redisStorage = redis;
        }

        public async Task<Server> GetServerAsync(ulong Id)
        {
            await using var client = await redisStorage.GetClientAsync();
            var servers = client.As<ServerDTO>();

            var server = await servers.GetByIdAsync(Id);

            return new ServerDTOMapper().MapTo(server);
        }

        public async Task<List<Server>> GetAllServersAsync()
        {
            await using var client = await redisStorage.GetClientAsync();
            var servers = client.As<ServerDTO>();

            var allServer = await servers.GetAllAsync();
            var mapper = new ServerDTOMapper();

            return allServer.Select(x => mapper.MapTo(x)).ToList();
        }

        public async Task<Server> AddServerAsync(string name, ulong id, string prefix)
        {
            await using var client = await redisStorage.GetClientAsync();
            var servers = client.As<ServerDTO>();
            var mapper = new ServerDTOMapper();

            var server = await servers.StoreAsync(mapper.MapFrom(new Server
            {
                Id = id,
                Name = name,
                CustomPrefix = prefix
            }));

            return mapper.MapTo(server);
        }

        public async Task<Server> UpdateServerAsync(string name, ulong id, string prefix)
        {
            return await AddServerAsync(name, id, prefix);
        }
        
    }
}
