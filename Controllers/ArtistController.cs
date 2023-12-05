using MusicLibrary.Services;
using MusicLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;



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

        [HttpGet("Artists/Get-ArtistId/{name}")]
        public ActionResult GetArtistIdByName(string name)
        {
            try
            {
                var artist = _artistService.GetArtistIdByName(name);
                return Ok(artist);
            }catch (InvalidOperationException ex)
            {
                return BadRequest("Artist not found: " + ex);
            }
        }

        [HttpPost("Artists/Add-Artist")]
        public ActionResult AddArtist(Artist model)
        {
            try
            {
                var artistEntity = new Artist
                {
                    ArtistId = model.ArtistId,
                    Name = model.Name
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
    }
}
