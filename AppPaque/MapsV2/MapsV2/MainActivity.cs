using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using System;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.Runtime;
using Android.Content;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;

namespace MapsV2
{
    class MostrarIdEmpleados
    {
        public string idEmpleado { get; set; }
        public string name { get; set; }
    }

    class MostrarGuiasP
    {
        public string idGuia { get; set; }
    }

    class InsertarUbiPaquete
    {
        public string action { get; set; }
        public string idGuia { get; set; }
        public string Fecha { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string idEmpleado { get; set; }

        public InsertarUbiPaquete(string idguia,string fecha,string latitud,string longitud,string idempledo)
        {
            action = "InsertarDatosR";
            idGuia = idguia;
            Fecha = fecha;
            Latitud = latitud;
            Longitud = longitud;
            idEmpleado = idempledo;

        }
    }

    class InsertarUbiPaqueteEntregado
    {
        public string action { get; set; }
        public string idGuia { get; set; }
        public string Fecha { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string idEmpleado { get; set; }

        public InsertarUbiPaqueteEntregado(string idguia, string fecha, string latitud, string longitud, string idempledo)
        {
            action = "InsertarD";
            idGuia = idguia;
            Fecha = fecha;
            Latitud = latitud;
            Longitud = longitud;
            idEmpleado = idempledo;
        }
    }

    [Activity(Label = "MapsV2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback, ILocationListener
    {
        public GoogleMap Gmap;

        Button btnVer;
        Button InserEntr;
        ArrayList Empleado = new ArrayList();
        //string[] Empleado;// = {"A1","A2","33","35" };
        ArrayList Guias = new ArrayList();

        MultiAutoCompleteTextView actxtEmpelado;
        MultiAutoCompleteTextView actxtGuias;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ObtenerIDEmpleados();
            ObtenerGuiasP();
            btnVer = FindViewById<Button>(Resource.Id.btnVer);
            InserEntr = FindViewById<Button>(Resource.Id.btnActualizarE);

            actxtEmpelado = FindViewById<MultiAutoCompleteTextView>(Resource.Id.actxtIdEmpleado);
            ArrayAdapter adaptadorIds = new ArrayAdapter(this, Android.Resource.Layout.SimpleExpandableListItem1, Empleado);
            actxtEmpelado.Adapter = adaptadorIds;
            actxtEmpelado.Threshold = 1;
            actxtEmpelado.SetTokenizer(new MultiAutoCompleteTextView.CommaTokenizer());
            //
            actxtGuias = FindViewById<MultiAutoCompleteTextView>(Resource.Id.actxtGuias);
            ArrayAdapter adaptadorG = new ArrayAdapter(this, Android.Resource.Layout.SimpleExpandableListItem1, Guias);
            actxtGuias.Adapter = adaptadorG;
            actxtGuias.Threshold = 1;
            actxtGuias.SetTokenizer(new MultiAutoCompleteTextView.CommaTokenizer());
            //AutoComplete
            //SetUpMap();
            //
            btnVer.Click += delegate {
                //SetUpMap();
                Servicio NuevoSer = new Servicio();

                string guia = "";
                string idEm = "";
                int i = 0;
                while(char.ToString(actxtGuias.Text[i]) != ",")
                {
                    guia += actxtGuias.Text[i];
                    i++;
                }

                i = 0;
                while (char.ToString(actxtEmpelado.Text[i]) != " ")
                {
                    idEm += actxtEmpelado.Text[i];
                    i++;
                }

                DateTime dt = DateTime.Today;
                string Fecha = dt.ToString();
                //btnVer.Text = LongitudO;
                InsertarUbiPaquete parametros = new InsertarUbiPaquete(guia, Fecha,LatitudO,LongitudO.ToString(),idEm);

                string body = JsonConvert.SerializeObject(parametros);

                string Resultados = NuevoSer.llamarServicio(body);
            };
            //

            InserEntr.Click += delegate {
                //SetUpMap();
                Servicio NuevoSer = new Servicio();

                string guia = "";
                string idEm = "";
                int i = 0;
                while (char.ToString(actxtGuias.Text[i]) != ",")
                {
                    guia += actxtGuias.Text[i];
                    i++;
                }

                i = 0;
                while (char.ToString(actxtEmpelado.Text[i]) != " ")
                {
                    idEm += actxtEmpelado.Text[i];
                    i++;
                }

                DateTime dt = DateTime.Today;
                string Fecha = dt.ToString();
                //btnVer.Text = LongitudO;

                InsertarUbiPaqueteEntregado parametros = new InsertarUbiPaqueteEntregado(guia, Fecha, LatitudO, LongitudO.ToString(), idEm);

                string body = JsonConvert.SerializeObject(parametros);

                string Resultados = NuevoSer.llamarServicio(body);
            };
        }

        //ObtenerGuiasP
        public void ObtenerGuiasP()
        {
            Servicio Service = new Servicio();

            ObtenerGuias parametros = new ObtenerGuias();
            string body = JsonConvert.SerializeObject(parametros);

            string Resultados = Service.llamarServicio(body);

            var Ids = JsonConvert.DeserializeObject<List<MostrarGuiasP>>(Resultados);

            int i = 0;

            while (i < Ids.Count)
            {
                Guias.Add(Ids[i].idGuia);

                i++;
            }

        }

        //ObtenerIds
        public void ObtenerIDEmpleados()
        {
            Servicio Service = new Servicio();

            ObtenerIdEmpleados parametros = new ObtenerIdEmpleados();
            string body = JsonConvert.SerializeObject(parametros);

            string Resultados = Service.llamarServicio(body);

            var Ids = JsonConvert.DeserializeObject<List<MostrarIdEmpleados>>(Resultados);

            int i = 0;

            while (i < Ids.Count)
            {
                Empleado.Add(Ids[i].idEmpleado + "  " + Ids[i].name);
                
                i++;
            }

        }
        //

        public void SetUpMap()
        {
            if(Gmap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);

            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            //throw new NotImplementedException();
            this.Gmap = googleMap;
            LatLng latlng = new LatLng(Convert.ToDouble(LatitudO), Convert.ToDouble(LongitudO));
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            Gmap.MoveCamera(camera);
            MarkerOptions options = new MarkerOptions().SetPosition(latlng).SetTitle("Paquete");
           
            Gmap.AddMarker(options);
        }

        LocationManager locMr;
        protected override void OnResume()
        {

            base.OnResume();
            //Log.Debug(tag, "OnResume Called");

            locMr = GetSystemService(Context.LocationService) as LocationManager;

            if (locMr.AllProviders.Contains(LocationManager.NetworkProvider) && locMr.IsProviderEnabled(LocationManager.NetworkProvider))
            {
                locMr.RequestLocationUpdates(LocationManager.NetworkProvider, 2000, 1, this);
            }
            else
            {
                Toast.MakeText(this, "Localizando", ToastLength.Long).Show();
            }
        }
        string LatitudO;
        string LongitudO;
        public void OnLocationChanged(Location location)
        {
            //Log.Debug(tag, "Cambiando Localización");
            LatitudO = location.Latitude.ToString();
            LongitudO = location.Longitude.ToString();
            SetUpMap();

        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }
    }
}

