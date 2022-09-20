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
    public partial class EspecialGet : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/departamento/1";

        

        public EspecialGet()
        {
            InitializeComponent();
            getEspecial();
        }


        private async Task getEspecial()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<Especial> contenido = JsonConvert.DeserializeObject<List<Especial>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {
                        tempRes = "Hola";
                        //tempRes = tempRes + "id_telefono: " + contenido[i].id_telefono + " idempleado: " + contenido[i].idempleado + " telefono: " + contenido[i].telefono + "\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Telefono";
                }




            }
        }


    }
}