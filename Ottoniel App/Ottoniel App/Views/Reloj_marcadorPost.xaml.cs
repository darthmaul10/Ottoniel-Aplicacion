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
    public partial class Reloj_marcadorPost : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/reloj_marcador/";
        public Reloj_marcadorPost()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearMarcacionAsync();
        }

        private async Task crearMarcacionAsync()
        {
            using (var httpClient = new HttpClient())
            {
                Reloj_marcador dep = new Reloj_marcador()
                {
                    id_tipo = int.Parse(idtipoForm.Text),
                    id_empleado = int.Parse(idempleadoForm.Text)
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

                idtipoForm.Text = "";
                idempleadoForm.Text = "";
            }
        }
    }
}