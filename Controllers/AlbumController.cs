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

        [HttpGet("Album/Get-Albums/{artistId}")]
        public ActionResult GetAlbum(int artistId)
        {
            try
            {
                var album = _albumService.GetAlbum(artistId);
                return Ok(album);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Albums not found" + ex);
            }
        }

       /* [HttpPost("Album/Add")]
        public ActionResult AddAlbum(Album model)
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
                    Year = model.Year
                };
                _albumService.AddAlbum(albumEntity);
                var album = _albumService.GetAlbum(model.ArtistId, model.AName);
                return Ok(album);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Album not added" + ex);
            }
        }*/

        /*[HttpDelete("Album/Delete")]
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
        }*/
    }
}
