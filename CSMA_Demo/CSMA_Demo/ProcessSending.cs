using System.Collections.Generic;

namespace CSMA_Demo
{
    public class ProcessSending
    {
        public string IPSource { get; set; }

        public string IPDest { get; set; }

        public List<byte> Data { get; set; }

        public string TypeData { get; set; }

        public string Status { get; set; }

        public ProcessSending(string ipSource, string ipDest, string typeData, List<byte> data)
        {
            IPSource = ipSource;
            IPDest = ipDest;
            Data = data;
            TypeData = typeData;
            Status = "Waitting";
        }

        public ProcessSending()
        {
            IPSource = "";
            IPDest = "";
            Data = new List<byte>();
            TypeData = "";
            Status = "Waitting";
        }

        public ProcessSending(string ipSource, string ipDest, string typeData)
        {
            IPSource = ipSource;
            IPDest = ipDest;
            TypeData = typeData;
            Data = new List<byte>();
            Status = "Waitting";
        }
    }
}
