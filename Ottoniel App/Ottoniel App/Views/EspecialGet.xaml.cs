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
        private string url = "https://desfrlopez.me/nosorio/api/departamento/";
        

        public EspecialGet()
        {
            InitializeComponent();
        }

        

        private async Task getEspecial()
        {
            using (var httpClient = new HttpClient())
            {
                string id = idForm.Text;

                

                var response = await httpClient.GetAsync(url+id);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<Especial> contenido = JsonConvert.DeserializeObject<List<Especial>>(content);

                    string tempRes = "";
                    

                    for (int i = 0; i < contenido.Count; i++)
                    {
                        
                       // tempRes = "Hola";
                        tempRes = tempRes + "id_departamento: " + contenido[i].id_departamento + " nombreDepto: " + contenido[i].nombreDepto + " id_empleado: " + contenido[i].id_empleado + " nombre: " + contenido[i].nombre + " nombrePuesto: " + contenido[i].nombrePuesto + " id_tipo: " + contenido[i].id_tipo + " tipoMarcador: " + contenido[i].tipoMarcador + " fecha: " + contenido[i].fecha + " hora: " + contenido[i].hora + "\n\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Telefono";
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            getEspecial();
        }
    }
}