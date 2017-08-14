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

namespace MapsV2
{
    class ObtenerGuias
    {
        public string action { get; set; }

        public ObtenerGuias()
        {
            action = "DatosG";
        }
    }
}