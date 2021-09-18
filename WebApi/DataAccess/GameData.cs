using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Library.DataAccess;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public class GameData : IGameData
    {
        private readonly ISqlDataAccess _sql;
        private readonly IConfiguration _config;

        public GameData(ISqlDataAccess sql, IConfiguration config)
        {
            _sql = sql;
            _config = config;
        }

        public List<GameModel> GetGames()
        {
            var output = _sql.LoadData<GameModel, dynamic>("dbo.spGame_GetAll", new { }, "DataConnection");

            return output;
        }
        
          public List<DetailModel> GetGameDetails(int id)
        {
            var output = _sql.LoadData<DetailModel, dynamic>("dbo.spGame_GetDetailsById", new {  Id = id }, "DataConnection");

            return output;
        }
    }
}
