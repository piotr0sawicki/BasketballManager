using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.DataAccess
{
    public interface IGameData
    {
        List<DetailModel> GetGameDetails(int id);
        List<GameModel> GetGames();
    }
}