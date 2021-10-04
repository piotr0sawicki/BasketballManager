using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Models
{
    public class GameDetailsParams
    {
        public GameDetailsParams(GameModel game)
        {
            GameId = game.Id;
            GuestTeam = game.GuestTeam;
            HomeTeam = game.HomeTeam;
            HomeTeamId = game.HomeTeamId;
            GuestTeamId = game.GuestTeamId;
        }

        public int GameId { get; set; }
        public int GuestTeamId { get; set; }
        public int HomeTeamId { get; set; }
        public string HomeTeam { get; set; }
        public string GuestTeam { get; set; }

    }
}
