using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System;
using Practica1;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mapa
{
    [Activity(Label = "Mapa", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        EditText edtinsertar;
        Button btnBuscar;
        TextView tvEstado;

        GoogleMap GMap;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Main);
            btnBuscar = FindViewById<Button>(Resource.Id.btnbusca);
            edtinsertar = FindViewById<EditText>(Resource.Id.edtInsert);
            tvEstado = FindViewById<TextView>(Resource.Id.twcambiar);
            SetUpMap();
            btnBuscar.Click += delegate
            {
                //SetUpMap();

                servicios Service = new servicios();
                ConsultarPedidos parametros = new ConsultarPedidos(edtinsertar.Text);
                string body = JsonConvert.SerializeObject(parametros);

                string Resultados = Service.llamarServicio(body);
                
                var Ids = JsonConvert.DeserializeObject<List<ObtenerDatos>>(Resultados);

                tvEstado.Text = Ids[0].Fecha;
                LatLng latlng = new LatLng(Convert.ToDouble(Ids[0].Latitud), Convert.ToDouble(Ids[0].Longitud));
                CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
                
                GMap.MoveCamera(camera);

                MarkerOptions option = new MarkerOptions().SetPosition(latlng).SetTitle("paquete");

                GMap.AddMarker(option);

            };

            // btnBuscar.Click += BtnBuscar_Click;

            //show.Click += delegate { GMap.UiSettings.ZoomControlsEnabled = true;
            //    LatLng latlng = new LatLng(Convert.ToDouble(13.0291), Convert.ToDouble(80.2083));
            //    CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            //    GMap.MoveCamera(camera);

            //    MarkerOptions option = new MarkerOptions().SetPosition(latlng).SetTitle("Angie");

            //    GMap.AddMarker(option);
            //};
           
        }

        //private void BtnBuscar_Click(object sender, EventArgs e)
        //{
        //    // throw new NotImplementedException();
        //    SetUpMap();

        //    servicios Service = new servicios();
        //    ConsultarPedidos parametros = new ConsultarPedidos(edtinsertar.Text);
        //    string body = JsonConvert.SerializeObject(parametros);

        //    string Resultados = Service.llamarServicio(body);

        //    var Ids = JsonConvert.DeserializeObject<List<ObtenerDatos>>(Resultados);

        //    tvEstado.Text = Ids[0].Fecha;
        //    LatLng latlng = new LatLng(Convert.ToDouble(Ids[0].Latitud), Convert.ToDouble(Ids[0].Longitud));
        //    CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
        //    GMap.MoveCamera(camera);

        //    MarkerOptions option = new MarkerOptions().SetPosition(latlng).SetTitle("Paquete");

        //    GMap.AddMarker(option);
        //}

        private void SetUpMap()
        {
            if (GMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            this.GMap = googleMap;
        }
    }
}

