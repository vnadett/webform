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
            }

        }
    }
}