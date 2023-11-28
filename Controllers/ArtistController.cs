using MusicLibrary.Services;
using MusicLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MusicLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController: Controller
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet("Artists/Index")]
        public ActionResult Index()
        {
            var artists = _artistService.GetAll();
            return Ok(artists);
        }

        [HttpGet("Artists/Get-Artists")]
        public ActionResult GetArtist(int artistId)
        {
            try
            {
                var artist = _artistService.GetArtist(artistId);
                return Ok(artist);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Artist not found" + ex);
            }
        }

        [HttpPost("Artists/Add-Artist")]
       /* public ActionResult AddArtist(int artistId, string artistName, ICollection<Album> albums, ICollection<Song> songs)
        {
            try
            {
                _artistService.AddArtist(artistId, artistName, albums, songs);
                var artist = _artistService.GetArtist(artistId);
                return View(artist);
            }
            catch (InvalidOperationException ex)
            {
                return View("Artist not found" + ex);
            }
        }*/

        public ActionResult AddArtist(Artist model)
        {
            try
            {
                var artistEntity = new Artist
                {
                    ArtistId = model.ArtistId,
                    Name = model.Name,
                    Albums = model.Albums,
                    Songs = model.Songs,
                };
                _artistService.AddArtist(artistEntity);
                var artist = _artistService.GetArtist(model.ArtistId);
                return Ok(artist);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Artist not added" + ex);
            }
        }

        [HttpDelete("Artists/Delete")]
        public ActionResult DeleteArtist(int artistId)
        {
            try
            {
                _artistService.DeleteArtist(artistId);
                return Ok(artistId + " was deleted");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Album not found" + ex);
            }
        }

        [HttpPut("Artists/Update")]
        /* public ActionResult UpdateArtist(int artistId, string artistName, ICollection<Album> albums, ICollection<Song> songs)
         {
             try
             {
                 _artistService.UpdateArtist(artistId, artistName, albums, songs);
                 var artist = _artistService.GetArtist(artistId);
                 return View(artist);
             }
             catch (InvalidOperationException ex)
             {
                 return View("Artist not found" + ex);
             }
         }*/

        public ActionResult UpdateArtist(Artist model)
        {
            try
            {
                var artistEntity = new Artist
                {
                    ArtistId = model.ArtistId,
                    Name = model.Name,
                    Albums = model.Albums,
                    Songs = model.Songs,
                };
                _artistService.UpdateArtist(artistEntity);
                var artist = _artistService.GetArtist(model.ArtistId);
                return Ok(artist);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Artist not updated" + ex);
            }
        }
    }
}
