using Newtonsoft.Json;
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
    public partial class tipo_entradaGet : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/tipo_entrada/";
        public tipo_entradaGet()
        {
            InitializeComponent();
            getTipo_entrada();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getTipo_entrada();
        }

        private async Task getTipo_entrada()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<Tipo_entrada> contenido = JsonConvert.DeserializeObject<List<Tipo_entrada>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "id_tipo: " + contenido[i].id_tipo + " descripcion: " + contenido[i].descripcion + "\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Tipo Entrada";
                }




            }
        }

    }
}