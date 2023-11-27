using System;
using MusicLibrary.Services;
using MusicLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace MusicLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet("Album/Index")]
        public ActionResult Index()
        {
            var albums = _albumService.GetAll();
            return Ok(albums);
        }

        [HttpGet("Album/Get-Albums")]
        public ActionResult GetAlbum(string albumName)
        {
            try
            {
                var album = _albumService.GetAlbum(albumName);
                return Ok(album);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("User not found" + ex);
            }
        }

        [HttpPost("Album/Add")]
        public ActionResult AddAlbum([FromBody] Album model)
        {
            try
            {
                var albumEntity = new Album
                {
                    ArtistId = model.ArtistId,
                    AName = model.AName,
                    Label = model.Label,
                    ALength = model.ALength,
                    AGenre = model.AGenre,
                    Numofsongs = model.Numofsongs,
                    Year = model.Year,
                    Songs = model.Songs,
                    Artist = model.Artist
                };
                _albumService.AddAlbum(albumEntity);
                var album = _albumService.GetAlbum(model.AName);
                return Ok(album);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Album not found" + ex);
            }
        }

        /*[HttpPut]
        public ActionResult UpdateAlbum(int artistId, string albumName, string label, string  albumLength, string albumGenre, int numOfSongs, int year, ICollection<Song> albumSongs, Artist artist)
        {
            try
            {
                _albumService.UpdateAlbum(artistId, albumName, label, albumLength, albumGenre, numOfSongs, year, albumSongs, artist);
                var album = _albumService.GetAlbum(albumName);
                return View(album);
            }
            catch (InvalidOperationException ex)
            {
                return View("Album not found" + ex);
            }
        }*/

        [HttpPut("Album/Update")]
        public ActionResult UpdateAlbum([FromBody] Album model)
        {
            try
            {
                
                    var albumEntity = new Album
                    {
                        ArtistId = model.ArtistId,
                        AName = model.AName,
                        Label = model.Label,
                        ALength = model.ALength,
                        AGenre = model.AGenre,
                        Numofsongs = model.Numofsongs,
                        Year = model.Year,
                        Songs = model.Songs,
                        Artist = model.Artist
                    };

                    _albumService.UpdateAlbum(albumEntity);

                    var updatedAlbum = _albumService.GetAlbum(model.AName);
                    return Ok(updatedAlbum);
                
             
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex);
            }
        }


        [HttpDelete("Album/Delete")]
        public ActionResult DeleteAlbum(int artistId, string albumName)
        {
            try
            {
                _albumService.DeleteAlbum(artistId, albumName);
                return Ok(albumName  + " by " + artistId + " was deleted");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Album not found" + ex);
            }
        }
    }
}
