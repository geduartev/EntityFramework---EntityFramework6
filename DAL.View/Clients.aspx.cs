using System;
using IngenieriaGD.IGDDemo.Library.DAL.Data;
using IngenieriaGD.IGDDemo.Library.DAL.Entities;

namespace IngenieriaGD.IGDDemo.Library.DAL.View
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewClients.DataSource = ClientsRepository.GetInstance().SelectAll();
            GridViewClients.DataBind();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            var client = new ClientInfo
            {
                Id = string.IsNullOrWhiteSpace(TextBoxIDClient.Text) ? 0 : int.Parse(TextBoxIDClient.Text),
                Phone = string.IsNullOrWhiteSpace(TextBoxPhone.Text) ? string.Empty : TextBoxPhone.Text,
                LastReading = string.IsNullOrWhiteSpace(TextBoxReadLast.Text) ? 0 : int.Parse(TextBoxReadLast.Text),
                Readed = CheckBoxReaded.Checked
            };

            ClientsRepository.GetInstance().Insert(client);
            GridViewClients.DataSource = ClientsRepository.GetInstance().SelectAll();
            GridViewClients.DataBind();
        }
    }
}