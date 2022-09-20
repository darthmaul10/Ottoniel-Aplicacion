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
    public partial class PuestoPut : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/puesto";
        public PuestoPut()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarPuestoAsync();
        }

        private async Task actualizarPuestoAsync()
        {
            using (var httpClient = new HttpClient())
            {

                Puesto x = new Puesto()
                {
                    id_puesto = int.Parse(idForm.Text),
                    desc = nombreForm.Text,
                    id_departamento = int.Parse(idDepForm.Text),

                };
                url = url + "/" + x.id_puesto; // mandamos de parametro de url del id a modificar
                var body = x.ToJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Actulizacion Exitosa";
                }
                else
                {
                    resultado.Text = "Actulizacion Fallida";
                }

                idForm.Text = "";
                nombreForm.Text = "";
                idDepForm.Text = "";
            }
        }
    }
}