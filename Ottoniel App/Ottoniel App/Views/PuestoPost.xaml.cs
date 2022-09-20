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
    public partial class PuestoPost : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/puesto/";
        public PuestoPost()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearPuestoAsync();
        }

        private async Task crearPuestoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                Puesto dep = new Puesto()
                {
                    desc = nombreForm.Text,
                    id_departamento = int.Parse(idForm.Text)
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
    }
}