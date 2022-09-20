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
    public partial class PuestoGet : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/puesto/";
        public PuestoGet()
        {
            InitializeComponent();
            getPuesto();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getPuesto();
        }

        private async Task getPuesto()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<Puesto> contenido = JsonConvert.DeserializeObject<List<Puesto>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {
                        tempRes = tempRes + "id_puesto: " + contenido[i].id_puesto + " desc: " + contenido[i].desc + " id_departamento: " + contenido[i].id_departamento + "\n";
                    }
                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Puesto";
                }
            }
        }
    }
}