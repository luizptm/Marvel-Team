using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Champions.Database
{
    public class Database
    {
        ChampionsEntities context = new ChampionsEntities();

        public int SaveTeam(Team item)
        {
            context.Team.Add(item);
            context.SaveChanges();
            int id = context.Entry(item).Property<Int32>("id").CurrentValue;
            return id;
        }

        public bool SaveAttendant(Attendant item)
        {
            context.Attendant.Add(item);
            context.SaveChanges();
            return true;
        }

        public bool SaveWinner(Winner item)
        {
            context.Winner.Add(item);
            context.SaveChanges();
            return true;
        }
    }
}
