using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSMA_Demo
{
    public class Computer
    {
        public string MAC { get; set; }

        public string TypeDataReceive { get; set; }

        public int G { get; set; }

        public int S { get; set; }

        public Button GetButton { get; set; }

        public Point GetPoint { get; set; }

        // 0: no action
        // 1: sending
        // 2: receiving
        // 3: waitting
        public int Status { get; set; }

        public List<byte> Data { get; set; }

        public Computer(string mac)
        {
            MAC = mac;
            TypeDataReceive = string.Empty;
            G = 0;
            S = 0;
            Status = 0;
            Data = new List<byte>();
            GetButton = new Button();
            GetPoint = new Point();
        }

        public void RemoveData()
        {
            Data.RemoveRange(0, Data.Count);
        }

    }
}
