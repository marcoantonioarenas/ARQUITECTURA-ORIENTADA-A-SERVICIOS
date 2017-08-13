using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace PortalWeb
{
    class Servicio
    {
        private string url { get; set; }

        private HttpWebRequest httpRequest { get; set; }

        private HttpWebResponse httpResponse { get; set; }

        private StreamWriter streamWriter { get; set; }

        private StreamReader streamReader { get; set; }

        private string body { get; set; }

        private string results { get; set; }

        public Servicio()
        {
            url = "http://localhost:8080/webService/";
            //url = "http://localhost:80/webService/";
            httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            streamWriter = new StreamWriter(httpRequest.GetRequestStream());
        }

        public string llamarServicio(string parametros)
        {
            //peticion al servivio
            body = parametros;
            streamWriter.InitializeLifetimeService();
            streamWriter.Write(body);
            streamWriter.Flush();
            //respuesta de web service
            httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                results = streamReader.ReadToEnd();
            }

            return results;
        }
    }
}
