using RunpathCodingTest.Contracts.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Services
{
     public interface IAlbumService
    {

        Task<IReadOnlyList<Album>> GetAlbumsByUserIdAsync(int userId);
        Task<IReadOnlyList<Album>> GetAllAlbumsAsync();
    }
}
