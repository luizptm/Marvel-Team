using MebApplication.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Champions.Database
{
    public class Business
    {
        Database db = new Database();

        ApiMarvel api = new ApiMarvel();

        private Team SaveTeam(string name)
        {
            Team g = new Team();
            g.name = name;
            db.SaveTeam(g);
            return g;
        }

        private bool SaveAttendant(int ID, string name, int power, Team g)
        {
            Attendant a = new Attendant();
            a.ID = ID;
            a.name = name;
            a.power = power;
            a.Team = g;
            return db.SaveAttendant(a);
        }

        private int VerifyPowerTeam(ListItemCollection list)
        {
            int sum = 0;
            foreach (ListItem li in list)
            {
                string id = li.Value;
                int power = api.CharacterPower(id);
                sum += power;
            }
            return sum;
        }

        private bool SaveWinner(Team g)
        {
            Winner winner = new Winner();
            winner.id = g.id;
            return db.SaveWinner(winner);
        }

        public int VerifyWinnerTeam(ListItemCollection list1, ListItemCollection list2)
        {
            int sum1 = VerifyPowerTeam(list1);
            int sum2 = VerifyPowerTeam(list2);
            if (sum1 > sum2)
                return 1;
            return 2;
        }

        public int Salvar(ListItemCollection list)
        {
            Business bi = new Business();
            Team g = bi.SaveTeam("");
            foreach (ListItem li in list)
            {
                int ID = Int32.Parse(li.Value);
                string name = li.Text;
                int power = api.CharacterPower(ID.ToString());
                bi.SaveAttendant(ID, name, power, g);
            }
            SaveWinner(g);
            return 0;
        }


    }
}
