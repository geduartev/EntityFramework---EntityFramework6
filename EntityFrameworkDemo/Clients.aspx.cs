using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoEF.Backend.Business.Entities;
using DemoEF.Backend.Business.Logic;

namespace EntityFrameworkDemo
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewClients.DataSource = ClientsBL.GetInstance().SelectAll();
            GridViewClients.DataBind();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            var client = new EPM_Clients
            {
                Id = string.IsNullOrWhiteSpace(TextBoxIDClient.Text) ? 0 : int.Parse(TextBoxIDClient.Text),
                Phone = string.IsNullOrWhiteSpace(TextBoxPhone.Text) ? string.Empty : TextBoxPhone.Text,
                LastRead = string.IsNullOrWhiteSpace(TextBoxReadLast.Text) ? 0 : int.Parse(TextBoxReadLast.Text),
                Readed = CheckBoxReaded.Checked
            };

            ClientsBL.GetInstance().Insert(client);
            GridViewClients.DataSource = ClientsBL.GetInstance().SelectAll();
            GridViewClients.DataBind();
        }
    }
}