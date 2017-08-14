using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace Mapa
{
    class ConsultarPedidos
    {
        public string action { get; set; }
        public string idguia { get; set; }

        public ConsultarPedidos( string IdGuia )
        {
            action = "ConsultarP";
            idguia = IdGuia;
        }
    }
}