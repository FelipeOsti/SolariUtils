using System.Collections.Generic;

namespace SolariUtils.DistanciaMapa
{
    internal class RetornoGmapModel
    {
        public List<string> destination_addresses { get; set; }
        public List<string> origin_addresses { get; set; }
        public List<rowsModel> rows { get; set; }
        public string status { get; set; }
    }

    public class rowsModel
    {
        public List<elementsModels> elements { get; set; }
    }

    public class elementsModels
    {
        public distanceModel distance { get; set; }
        public durationModel duration { get; set; }
        public durationInTrafficModel duration_in_traffic { get; set; }
        public string status { get; set; }
    }

    public class durationInTrafficModel
    {
        public string text { get; set; }
        public long value { get; set; }
    }

    public class durationModel
    {
        public string text { get; set; }
        public long value { get; set; }
    }

    public class distanceModel
    {
        public string text { get; set; }
        public long value { get; set; }
    }
}