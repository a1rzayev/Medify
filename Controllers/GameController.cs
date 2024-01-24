using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.Models;
using GameStore.Resources;


namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        private readonly GameResources resources = new GameResources();
        [HttpGet]
        public IActionResult GetGames()
        {
            var games = resources.GetGames();
            if(games is null)
                return NotFound("No games");
            return Ok(games);
        }
        [HttpGet]
        public IActionResult GetGameById(int id)
        {
            var game = resources.GetGameById(id);
            if(game is null){
                return NotFound($"Game(id={id}) not found");
            }
            return Ok(game);
        }
        [HttpGet]
        public IActionResult GetGameByName(string name)
        {
            var game = resources.GetGameByName(name);
            if(game is null){
                return NotFound($"Game(name={name}) not found");
            }
            return Ok(game);
        }
        [HttpPost]
        public IActionResult AddGame(Game game){
            try
            {
                resources.AddGame(game);
            }
            catch (System.Exception)
            {
                return StatusCode(505);
                throw;
            }
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteGame(int id){
            try
            {
                resources.DeleteGame(id);
            }
            catch (System.Exception)
            {
                return NotFound();
                throw;
            }
            return Ok();
        }
    }
}