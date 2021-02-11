using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Client.ApiCollection.Interface;
using Music.Client.Models.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Client.Controllers
{
    public class MusicController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArtistApi _artistApi;
        private readonly IMusicApi _musicApi;

        public MusicController(ILogger<HomeController> logger, IArtistApi artistApi, IMusicApi musicApi)
        {
            _logger = logger;
            _artistApi = artistApi;
            _musicApi = musicApi;
        }
        public async Task<IActionResult> Index()
        {
            var Musics = await _musicApi.GetAllMusicAsync();
            ViewBag.Musics = Musics;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateMusic()
        {
            var Artists = await _artistApi.GetAllArtistsAsync();
            ViewBag.Artists = Artists;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMusic(CreateMusicModel model)
        {
            if (model != null)
            {
                var Musics = await _musicApi.AddMusic(model);
                ViewBag.Musics = Musics;
            }


            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditMusic(int id)
        {
            var Artists = await _artistApi.GetAllArtistsAsync();
            var music = await _musicApi.FindMusicById(id);
            ViewBag.Artists = Artists;
            ViewBag.Music = music;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditMusic(UpdateMusicModel model)
        {
            if (model != null)
            {

                await _musicApi.UpdateMusicAsync(model);


            }


            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteMusic(int id)
        {

            var music = await _musicApi.FindMusicById(id);


            ViewBag.Music = music;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMusic(DeleteMusicModel model)
        {
            if (model != null)
            {

                await _musicApi.DeleteMusicAsync(model);


            }


            return RedirectToAction("Index");
        }
    }
}
