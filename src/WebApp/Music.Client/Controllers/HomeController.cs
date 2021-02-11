using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Client.ApiCollection.Interface;
using Music.Client.Models;
using Music.Client.Models.Music;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArtistApi _artistApi;
        private readonly IMusicApi _musicApi;

        public HomeController(ILogger<HomeController> logger, IArtistApi artistApi, IMusicApi musicApi)
        {
            _logger = logger;
            _artistApi = artistApi;
            _musicApi = musicApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Artists = await _artistApi.GetAllArtistsAsync();
            var Musics = await _musicApi.GetAllMusicAsync();
            ViewBag.Artists = Artists;
            ViewBag.Musics = Musics;
            return View();
        }

      
       
       
       
        [HttpGet]
        public async Task<IActionResult> SingleProduct(int id)
        {
            
            var Music = await _musicApi.FindMusicById(id);
            ViewBag.Music = Music;
           
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ArtistsProduct(string userName)
        {
            
            var Musics = await _musicApi.GetMusicByArtistName(userName);

            if (Musics != null) 
            {
                ViewBag.userName = userName;
            }
            ViewBag.Musics = Musics;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
