using Client.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Core.Api
{
    public interface IGameEndpoint
    {
        Task<List<GameModel>> GetAll();
        Task<List<DetailModel>> GetGameDetailsById(int id);
    }
}