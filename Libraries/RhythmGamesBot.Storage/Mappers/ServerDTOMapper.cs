namespace RhythmGamesBot.Storage.Mappers
{
    using RhythmGamesBot.Models;
    using RhythmGamesBot.Storage.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ServerDTOMapper : IMapperBase<ServerDTO, Server>
    {
        public ServerDTO MapFrom(Server input)
        {
            return new ServerDTO
            {
                Id = input.Id,
                Name = input.Name,
                CustomPrefix = input.CustomPrefix
            };
        }

        public Server MapTo(ServerDTO input)
        {
            return new Server
            {
                Id = input.Id,
                Name = input.Name,
                CustomPrefix = input.CustomPrefix
            };
        }
    }
}
