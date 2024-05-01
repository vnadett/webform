using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Threading.Tasks;
using webformproba.Models;
using Newtonsoft.Json;
using System.Text;


namespace webformproba
{
    public partial class Peoduct : System.Web.UI.Page
    {
        private readonly HttpClient _client = new HttpClient();
        protected async void Page_Load(object sender, EventArgs e)
        {
            grid.DataSource = await GetProds();
            grid.DataBind();
        }

        private async Task<List<ProductModel>> GetProds()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.ProductEndpoint + "GetAllProduct");

            HttpResponseMessage response = await _client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var res = JsonConvert.DeserializeObject<BaseResponseModel<List<ProductModel>>>(content);
                if (res != null && res.Success && res.Result != null)
                {
                    return res.Result;
                }
            }
            return null;
        }

        protected void ctl01_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            panelNewFields.Visible = true;
        }

        protected async void Unnamed2_Click(object sender, EventArgs e)
        {
            var product = new ProductModel
            {
                Name = txtFieldProd.Text,
                Manufacturer = txtFieldManu.Text,
                Price = int.Parse(txtFieldPrice.Text)
            };

            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.ProductEndpoint + "CreateNewProduct");
            request.Content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<BaseResponseModel<bool>>(content);
            if (res != null && res.Success)
            {
                grid.DataSource = await GetProds();
                grid.DataBind();
                txtFieldManu.Text = string.Empty;
                txtFieldPrice.Text = string.Empty;
                txtFieldProd.Text = string.Empty;
                panelNewFields.Visible = false;

            }

        }
        protected void grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grid.SelectedIndex != -1)
            {
                btnEdit.Visible = true;
                btnDelete.Visible = true;

                GridViewRow selectedRow = grid.SelectedRow;

                TextBoxId.Text = selectedRow.Cells[1].Text;
                TextBox1.Text = selectedRow.Cells[2].Text;
                TextBox2.Text = selectedRow.Cells[3].Text;
                TextBox3.Text = selectedRow.Cells[4].Text;
            }
            else
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            paneledit.Visible = true;
        }

        protected async void btnDelete_Click(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, Endpoints.ProductEndpoint + "DeleteProduct/" + int.Parse(TextBoxId.Text));

            HttpResponseMessage response = await _client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<BaseResponseModel<bool>>(content);

            if (res != null && res.Success)
            {
                TextBoxId.Text = string.Empty;
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                TextBox3.Text = string.Empty;
                grid.DataSource = await GetProds();
                grid.DataBind();
            }
        }

        protected async void Edit_Click(object sender, EventArgs e)
        {
            var product = new ProductModel
            {
                Id = int.Parse(TextBoxId.Text),
                Name = TextBox1.Text,
                Manufacturer = TextBox2.Text,
                Price = decimal.Parse(TextBox3.Text)

            };
            var request = new HttpRequestMessage(HttpMethod.Put, Endpoints.ProductEndpoint + "UpdateProduct");
            request.Content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();

            var res = JsonConvert.DeserializeObject<BaseResponseModel<bool>>(content);

            if (res != null && res.Success)
            {
                paneledit.Visible = false;
                TextBoxId.Text = string.Empty;
                TextBox1.Text = string.Empty;
                TextBox2.Text = string.Empty;
                TextBox3.Text = string.Empty;
                grid.DataSource = await GetProds();
                grid.DataBind();
            }
        }
    }
}