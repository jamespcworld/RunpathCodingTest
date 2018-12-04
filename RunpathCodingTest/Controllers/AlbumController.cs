using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RunpathCodingTest.Models;
using RunpathCodingTest.Services;

namespace RunpathCodingTest.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IAlbumService _albumService;

        public AlbumController(
            IPhotoService photoService,
            IAlbumService albumService
            )
        {
            _photoService = photoService;
            _albumService = albumService;
        }


        public async Task<IActionResult> Index(int userId)
        {
            var albums = await _albumService.GetAlbumsByUserIdAsync(userId);

            var albumsViewModel = albums.Select(x =>  new AlbumViewModel {
                Id = x.Id,
                UserId = x.UserId,
                Title = x.Title,
                Photos = Task.Run(() => _photoService.GetPhotosByAlbumIdAsync(x.Id)).Result.ToList()
            });

            return View(albumsViewModel);
        }

    }
}
