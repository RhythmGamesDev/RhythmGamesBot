namespace RhythmGamesBot.Storage.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IMapperBase<From, Too>
    {
        /// <summary>
        /// Map <see cref="From"/> to <see cref="Too"/>
        /// </summary>
        /// <param name="input">The <see cref="From"/> to map</param>
        /// <returns>The mapped <see cref="Too"/></returns>
        Too MapTo(From input);

        /// <summary>
        /// Map from <see cref="Too"/> to <see cref="From"/>
        /// </summary>
        /// <param name="input">The <see cref="Too"/> to map</param>
        /// <returns>The mapped <see cref="From"/></returns>
        From MapFrom(Too input);
    }
}
