using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Client.ApiCollection.Interface;
using Music.Client.Models.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Client.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArtistApi _artistApi;
        private readonly IMusicApi _musicApi;

        public ArtistController(ILogger<HomeController> logger, IArtistApi artistApi, IMusicApi musicApi)
        {
            _logger = logger;
            _artistApi = artistApi;
            _musicApi = musicApi;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Artists = await _artistApi.GetAllArtistsAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateArtist()
        {
            var Artists = await _artistApi.GetAllArtistsAsync();
            ViewBag.Artists = Artists;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArtist(CreateArtistModel model)
        {
            if (model != null)
            {
                var artist = await _artistApi.AddArtist(model);
                ViewBag.Artist = artist;
            }


            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditArtist(int id)
        {
           
            var artist = await _artistApi.FindArtistByIdAsync(id);
           
            ViewBag.Artist = artist;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditArtist(UpdateArtistModel model)
        {
            if (model != null)
            {

                var result = await _artistApi.UpdateArtistAsync(model);

                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteArtist(int id)
        {

            var artist = await _artistApi.FindArtistByIdAsync(id);


            ViewBag.Artist = artist;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteArtist(DeleteArtistModel model)
        {
            if (model != null)
            {

                await _artistApi.DeleteArtistAsync(model);


            }


            return RedirectToAction("Index");
        }
    }
}
