using com.valgut.libs.bots.Wit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolariUtils.WitAI.Models
{
    public class ResponseWitAI
    {
        public static WitAiSimple MessageSimplify(Message message)
        {
            try
            {
                //var lstSimple = new List<WitAiSimple>();
                var simple = new WitAiSimple();

                foreach (var dict in message.entities)
                {
                    var lstEntities = dict.Value;
                    foreach (var entitie in lstEntities)
                    {
                        if (dict.Key == "intent")
                        {
                            simple.intent = entitie.value.ToString();
                        }
                        else if (dict.Key == "Produto")
                        {
                            simple.lstProduto.Add(
                                new Produto()
                                {
                                    value = entitie.value.ToString()
                                }
                            );
                        }
                        else if (dict.Key == "Sabor")
                        {
                            simple.lstSabor.Add(
                                new Sabor()
                                {
                                    value = entitie.value.ToString()
                                }
                            );
                        }
                        else if (dict.Key == "Adicional")
                        {
                            simple.lstAdicional.Add(
                                new Adicional()
                                {
                                    value = entitie.value.ToString()
                                }
                            );
                        }
                        else if (dict.Key == "Tamanho")
                        {
                            simple.tamanho = entitie.value.ToString();
                        }
                        else if(dict.Key == "meio-meio")
                        {
                            simple.bboMeioMeio = true;
                        }
                        else if (dict.Key == "outro_produto")
                        {
                            /*lstSimple.Add(simple);
                            simple = new WitAiSimple();
                            simple.tamanho = lstSimple[lstSimple.Count - 1].tamanho;*/
                        }
                    }
                }
                return simple;
            }
            catch
            {
                throw;
            }
        }
    }

    public class WitAiSimple
    {
        public WitAiSimple()
        {
            lstSabor = new List<Sabor>();
            lstProduto = new List<Produto>();
            lstAdicional = new List<Adicional>();
            bboMeioMeio = false;
        }

        public string intent { get; set; }
        public List<Sabor> lstSabor { get; set; }
        public List<Produto> lstProduto { get; set; }
        public List<Adicional> lstAdicional { get; set; }
        public string tamanho { get; set; }
        public bool bboMeioMeio { get; set; }
    }

    public class Sabor
    {
        public string value { get; set; }
    }
    public class Adicional
    {
        public string value { get; set; }
    }

    public class Produto
    {
        public string value { get; set; }
    }
}
