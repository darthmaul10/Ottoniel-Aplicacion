using Ottoniel_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ottoniel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepartamentoPost : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/departamento/";
        public DepartamentoPost()
        {
            InitializeComponent();
        }

        private async Task crearDepartamentoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                Departamento dep = new Departamento()
                {
                    nombre = nombreForm.Text
                };

                var body = dep.ToJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Insercion Exitosa";
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nombreForm.Text = "";
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearDepartamentoAsync();
        }
    }
}