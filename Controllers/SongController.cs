using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;
using MusicLibrary.Services;
using System;
using MusicLibrary.Services;
using MusicLibrary.Models;

namespace MusicLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : Controller
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet("Song/Index")]
        public ActionResult Index()
        {
            var songs = _songService.GetAll();
            return Ok(songs);
        }

        [HttpGet("Song/Get-Song/{albumName}/{name}")]
        public ActionResult GetSongByName(string albumName, string name) {
            var song = _songService.GetSongByName(albumName, name);

            if (song == null)
            {
                return NotFound(); // or return a suitable response
            }

            return Ok(song);
        }

        [HttpPost("Song/Add")]
        public ActionResult AddSong(Song newSong)
        {
            try
            {
                _songService.AddSong(newSong);
                var song = _songService.GetSongByName(newSong.AName, newSong.Name);
                return Ok(song);
            }
            catch (Exception ex)
            {
                return BadRequest("Error on adding song controller" + ex);
            }

        }

        [HttpDelete("Song/Delete")]
        public ActionResult DeleteSong(string albumName, string songName)
        {
            try
            {
                _songService.DeleteSong(albumName, songName);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error on deleting song controller" + ex);
            }
        }

        [HttpPut("Song/Update")]
        public ActionResult UpdateSong(string albumName, string songName, string genre, string featured, int length)
        {
            try
            {
                _songService.UpdateSong(albumName, songName, genre, featured, length);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error on updating on song controller" + ex);
            }
        }

        [HttpGet("Song/GetSongsFromArtist/{artistName}")]
        public IActionResult GetSongsFromArtist(string artistName)
        {
            var songs = _songService.GetSongsFromArtist(artistName);

            if (songs.Count == 0)
            {
                return NotFound("No songs found for the specified artist.");
            }

            return Ok(songs);
        }

        [HttpGet("Song/GetSongsFromAlbum/{albumName}")]
        public IActionResult GetSongsFromAlbum(string albumName)
        {
            var songs = _songService.GetSongsFromAlbum(albumName);

            if (songs.Count == 0)
            {
                return NotFound("No songs found for the specified album.");
            }

            return Ok(songs);
        }
    }
}
