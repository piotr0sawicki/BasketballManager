﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
        public int HomeScore { get; set; }
        public int GuestScore { get; set; }
        public int LocalizationId { get; set; }
        public DateTime Tipoff { get; set; }
    }
}
