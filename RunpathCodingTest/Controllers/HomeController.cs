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
    public class HomeController : Controller
    {
        private readonly IAlbumService _albumService;

        public HomeController(
            IAlbumService albumService
            )
        {
            _albumService = albumService;
        }

        public async Task<IActionResult> Index()
        {
            var albums = await _albumService.GetAllAlbumsAsync();

            var userList = albums.Select(x => x.UserId).Distinct();
            return View(userList);
        }
        

    }
}
