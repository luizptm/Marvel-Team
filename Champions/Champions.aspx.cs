using Champions.Database;
using Marvel.Api.Model.DomainObjects;
using MebApplication.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Champions
{
    public partial class Champions : System.Web.UI.Page
    {
        ApiMarvel api = new ApiMarvel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Character> result = new List<Character>();
                List<Character> resultDatalist = new List<Character>();
                while (ListBox1.Items.Count < 10)
                {
                    result = api.GetCharacters();
                    foreach (Character c in result)
                    {
                        if (ListBox1.Items.Count < 10)
                        {
                            ListBox1.Items.Add(new ListItem(c.Name, c.Id.ToString()));
                            resultDatalist.Add(c);
                        }
                    }
                }
                dlTeam1.DataSource = resultDatalist;
                dlTeam1.DataBind();

                resultDatalist = new List<Character>();
                int offset = 90;
                while (ListBox2.Items.Count < 10)
                {
                    offset = offset + 10;
                    result = api.GetCharacters(offset);
                    foreach (Character c in result)
                    {
                        if (ListBox2.Items.Count < 10)
                        {
                            ListBox2.Items.Add(new ListItem(c.Name, c.Id.ToString()));
                            resultDatalist.Add(c);
                        }
                    }
                }
                dlTeam2.DataSource = resultDatalist;
                dlTeam2.DataBind();
            }
        }

        protected void btnExibir_Click(object sender, EventArgs e)
        {
            ListItemCollection list1Selecionados = new ListItemCollection();
            foreach (ListItem li in ListBox1.Items)
            {
                if (li.Selected == true)
                    list1Selecionados.Add(li);
            }
            ListItemCollection list2Selecionados = new ListItemCollection();
            foreach (ListItem li in ListBox2.Items)
            {
                if (li.Selected == true)
                    list2Selecionados.Add(li);
            }
            if (list1Selecionados.Count > 3 || list1Selecionados.Count > 3)
            {
                lblMsg.Text = "Selecione, no máximo, 3 integrantes de cada time.";
                return;
            }
            Business b = new Business();
            int team = b.VerifyWinnerTeam(list1Selecionados, list2Selecionados);
            List<Character> result = new List<Character>();
            if (team == 1)
            {
                lblTime.Text = "1";
                int GroupId1 = b.Salvar(list1Selecionados);
                foreach (ListItem li in list1Selecionados)
                {
                    Character c = api.FindCharacter(li.Value);
                    result.Add(c);
                }
            }
            else
            {
                lblTime.Text = "2";
                int GroupId2 = b.Salvar(list2Selecionados);
                foreach (ListItem li in list2Selecionados)
                {
                    Character c = api.FindCharacter(li.Value);
                    result.Add(c);
                }
            }

            dlWinners.DataSource = result;
            dlWinners.DataBind();
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}