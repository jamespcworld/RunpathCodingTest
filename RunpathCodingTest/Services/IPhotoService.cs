using RunpathCodingTest.Contracts.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Services
{
    public interface IPhotoService
    {
        Task<IReadOnlyList<Photo>> GetPhotosByAlbumIdAsync(int albumId);
    }
}
