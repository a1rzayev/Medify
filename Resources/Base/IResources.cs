using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Models;
using GameStore.Resources.Base;

namespace GameStore.Resources.Base
{
    public interface IResources
    {
        public IEnumerable<Game> GetGames();
        public Game? GetGameById(int id);
        public Game? GetGameByName(string name);
        public int AddGame(Game game);
        // public int DeleteGame(int id);
    }
}