using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameData _gameData;

        public GameController(IGameData gameData)
        {
            _gameData = gameData;
        }

        [HttpGet]
        public ActionResult<List<GameModel>> GetGames()
        {
            return  _gameData.GetGames();
        }
    }
}
