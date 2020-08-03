using Newtonsoft.Json;
using RGiesecke.DllExport;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SolariUtils.DistanciaMapa
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("E8D53EED-3B2F-45A8-BB29-CC111BB426D1")]
    public class MapDistance
    {
        [DllExport]
        public static double GetDistancia(string origem, string destino, string apiKey)
        {
            try
            {
                double distanciaMetros = 0;
                var task = Task.Run(async () =>
                {
                    string sdsUrl = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + origem + "&destinations=" + destino + "&departure_time=now&key=" + apiKey;

                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(sdsUrl);
                        var json = await response.Content.ReadAsStringAsync();

                        var retornoGmap = (RetornoGmapModel)JsonConvert.DeserializeObject(json, typeof(RetornoGmapModel));

                        distanciaMetros = retornoGmap.rows[0].elements[0].distance.value;
                    }
                });

                task.Wait();
                return distanciaMetros;
            }
            catch(Exception e)
            {
                return -1;
            }
        }
    }
}
