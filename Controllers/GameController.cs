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
        private readonly GameResources gameResources = new GameResources();
        [HttpGet]
        public IActionResult GetGames(){
            var games = gameResources.GetGames();
            if(games is null){
                return NotFound("Nothing Found");
            }
            return View(games);
        }
        [HttpGet]
        public IActionResult GetGameById(int id){
            var game = gameResources.GetGameById(id);
            if(game is null){
                return NotFound($"Game({id}) not found");
            }
            return View(game);
        }
        [HttpGet]
        public IActionResult GetGameByName(string name){
            var game = gameResources.GetGameByName(name);
            if(game is null){
                return NotFound($"({name}) not found");
            }
            return View(game);
        }
        [HttpPost]
        public IActionResult AddGame(Game game){
            var count = gameResources.AddGame(game);
            if(count == 0)
                return StatusCode(505);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteGame(int id){
            var count = gameResources.DeleteGame(id);
            if(count==0)
                return NotFound();
            return Ok();
        }
    }
}