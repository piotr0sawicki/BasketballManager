using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Library.DataAccess;

namespace WebApi.DataAccess
{
    public class GameData
    {
        private readonly ISqlDataAccess _sql;

        public GameData(ISqlDataAccess sql)
        {
            _sql = sql;
        }


    }
}
