using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.Models;
using GameStore.Resources;
using GameStore.Resources.Base;

namespace GameStore.Controllers
{
    public class GameController : BaseController
    {
        private readonly IResources resources;
        public GameController(IResources resources){
            this.resources = resources;
        }       
        [HttpGet]
        public IActionResult GetGames(){
            var games = resources.GetGames();
            if(games is null){
                return NotFound("Nothing Found");
            }
            return View(games);
        }
        [HttpGet]
        public IActionResult GetGameById(int id){
            var game = resources.GetGameById(id);
            if(game is null){
                return NotFound($"Game({id}) not found");
            }
            return View(game);
        }
        [HttpGet]
        public IActionResult GetGameByName(string name){
            var game = resources.GetGameByName(name);
            if(game is null){
                return NotFound($"({name}) not found");
            }
            return View(game);
        }
        [HttpPost]
        public IActionResult AddGame(Game game){
            var count = resources.AddGame(game);
            if(count == 0)
                return StatusCode(505);
            return View();
        }
        // public IActionResult DeleteGame(int id){
        //     var count = resources.DeleteGame(id);
        //     if(count==0)
        //         return NotFound();
        //     return View();
        // }
    }
}