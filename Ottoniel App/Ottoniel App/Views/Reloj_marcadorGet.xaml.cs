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
    public partial class Reloj_marcadorGet : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/reloj_marcador/";
        public Reloj_marcadorGet()
        {
            InitializeComponent();
            getReloj_marcador();
        }


        private async Task getReloj_marcador()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<Reloj_marcador> contenido = JsonConvert.DeserializeObject<List<Reloj_marcador>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "id_registro: " + contenido[i].id_registro + " id_tipo: " + contenido[i].id_tipo + " fecha: " + contenido[i].fecha + " hora: " + contenido[i].hora + " id_empleado: " + contenido[i].id_empleado + "\n\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Reloj_marcador";
                }




            }
        }
    }
}