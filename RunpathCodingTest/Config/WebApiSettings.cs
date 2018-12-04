using System;
using System.Collections.Generic;
using System.Text;

namespace RunpathCodingTest.Config
{
    public class WebApiSettings
    {
        public string BaseWebApiUrl { get; set; }
        public int TimeoutInSeconds { get; set; }

        public PhotoEndpoints PhotoEndpoints { get; set; }
        public AlbumEndpoints AlbumEndpoints { get; set; }


    }

    public struct PhotoEndpoints
    {
        public string GetPhotosByAlbumId { get; set; }
        public string GetAllPhotos { get; set; }
    }

    public struct AlbumEndpoints
    {
        public string GetAlbumsByUserId { get; set; }
        public string GetAllAlbums { get; set; }

    }
}
