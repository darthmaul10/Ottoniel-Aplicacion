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
    public partial class EmpleadoGet : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/empleado/";
        public EmpleadoGet()
        {
            InitializeComponent();
            getEmpleado();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getEmpleado();
        }


        private async Task getEmpleado()
        {
            using (var httpClient = new HttpClient())
            {

                
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    
                    var content = await response.Content.ReadAsStringAsync();
                    List<Empleado> contenido = JsonConvert.DeserializeObject<List<Empleado>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {
                        
                        tempRes = tempRes + "id_empleado: " + contenido[i].id_empleado + " nombre: " + contenido[i].nombre + "fecha_nacimiento: " + contenido[i].fecha_nacimiento + " id_puesto: " + contenido[i].id_puesto + " nacionalidad: " + contenido[i].nacionalidad + "\n\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Empleados";
                }




            }
        }
    }
}