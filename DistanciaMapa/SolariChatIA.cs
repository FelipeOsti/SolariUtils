using com.valgut.libs.bots.Wit;
using com.valgut.libs.bots.Wit.Models;
using Newtonsoft.Json;
using RGiesecke.DllExport;
using SolariUtils.WitAI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SolariUtils.WitAI
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("995c16f0-881a-4427-ae38-02f51f88ad73")]
    public class SolariWitIA
    {
        const string TOKEN_WIT_AI = "425QJMVEJYDZX3UMNIDLFSXTIK3ZJ4WX";

        [DllExport]
        public static void getWitAi(string sdsMensagem, out string retorno)
        {
            try
            {
                WitClient client = new WitClient(TOKEN_WIT_AI);
                Message message = client.GetMessage(sdsMensagem);
                retorno = JsonConvert.SerializeObject(ResponseWitAI.MessageSimplify(message));
            }
            catch (Exception ex)
            {
                File.WriteAllText(System.IO.Path.Combine(@"C:\log\", "log.txt"), "getWitAi - " + sdsMensagem + " | " + ex.Message + " - " + ex.StackTrace);
                retorno = "ERRO";
            }
        }
    }
}
