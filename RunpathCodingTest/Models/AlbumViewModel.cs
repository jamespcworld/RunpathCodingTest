using RunpathCodingTest.Contracts.V1;
using System;
using System.Collections.Generic;

namespace RunpathCodingTest.Models
{
    public class AlbumViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }

        public List<Photo> Photos { get; set; }
    }
}