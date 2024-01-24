using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.Models;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult GetGames(){

        }
        [HttpGet]
        public IActionResult GetGameById(int id){

        }
        [HttpGet]
        public IActionResult GetGameByName(string name){

        }
        [HttpPost]
        public IActionResult AddGame(Game game){

        }
        [HttpDelete]
        public IActionResult DeleteGame(int id){

        }
    }
}