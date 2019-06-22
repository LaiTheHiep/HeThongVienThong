using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CSMA_Demo
{
    public partial class CSMA : Form
    {

        #region List combox

        private List<string> MAC_Computers = new List<string>()
        {
            "00:1B:44:11:3A:B0",
            "00:1B:44:11:3A:B1",
            "00:1B:44:11:3A:B2",
            "00:1B:44:11:3A:B3",
            "00:1B:44:11:3A:B4",
            "00:1B:44:11:3A:B5",
            "00:1B:44:11:3A:B6",
            "00:1B:44:11:3A:B7",
            "00:1B:44:11:3A:B8",
            "00:1B:44:11:3A:B9",
        };

        private List<Computer> ListComputers = new List<Computer>();

        private List<string> MAC_ComputersR = new List<string>()
        {
            "00:1B:44:11:3A:B0",
            "00:1B:44:11:3A:B1",
            "00:1B:44:11:3A:B2",
            "00:1B:44:11:3A:B3",
            "00:1B:44:11:3A:B4",
            "00:1B:44:11:3A:B5",
            "00:1B:44:11:3A:B6",
            "00:1B:44:11:3A:B7",
            "00:1B:44:11:3A:B8",
            "00:1B:44:11:3A:B9",
        };

        private List<string> ListTypeCSMA = new List<string>()
        {
            "1 Persistent",
            "P Persistent",
            "None Persistent",
            "CSMA/CD",
            "CSMA/CA"
        };

        #endregion

        #region Setup

        public CSMA()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;



            dgvView.DataSource = null;
            dgvView.DataSource = ProcessSends;
            dgvView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SetupSystem();
            //UpdateListEven();
        }

        private void SetupSystem()
        {
            //Combox
            cbComputerSend.DataSource = MAC_Computers;
            cbComputerReceive.DataSource = MAC_ComputersR;
            cbTypeCSMA.DataSource = ListTypeCSMA;

            //List of Computers
            int com = 0;
            foreach (var item in MAC_Computers)
            {
                ListComputers.Add(new Computer(item));

                Button btn = new Button();
                btn.Name = "Computer" + com.ToString();
                btn.Text = com.ToString();
                btn.Size = new Size(ConstantFrame.SizeButton, ConstantFrame.SizeButton);
                if (com++ >= 5)
                {
                    btn.Location = new Point(600 + ConstantFrame.Distance * (com - 5), 250 + 2 * ConstantFrame.Distance);
                }
                else
                {
                    btn.Location = new Point(600 + ConstantFrame.Distance * com, 250);
                }
                this.Controls.Add(btn);

                ListComputers[com - 1].GetButton = btn;
            }
        }
        private void btnCreateChanel_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();

            ListComputers[0].GetPoint = ListComputers[5].GetPoint = PointCenterButton(ListComputers[0].GetButton, ListComputers[5].GetButton);
            ListComputers[1].GetPoint = ListComputers[6].GetPoint = PointCenterButton(ListComputers[1].GetButton, ListComputers[6].GetButton);
            ListComputers[2].GetPoint = ListComputers[7].GetPoint = PointCenterButton(ListComputers[2].GetButton, ListComputers[7].GetButton);
            ListComputers[3].GetPoint = ListComputers[8].GetPoint = PointCenterButton(ListComputers[3].GetButton, ListComputers[8].GetButton);
            ListComputers[4].GetPoint = ListComputers[9].GetPoint = PointCenterButton(ListComputers[4].GetButton, ListComputers[9].GetButton);

            for (int i = 0; i < ListComputers.Count; i++)
            {
                PaintLine(Pens.Black, ListComputers[i].GetPoint, ListComputers[i].GetButton);
            }

            PaintLine(Pens.Black, ListComputers[0].GetPoint, ListComputers[9].GetPoint);
        }

        private void PaintLine(Pen pen, Point p1, Button btn2)
        {
            Graphics g = CreateGraphics();
            g.DrawLine(pen, p1, new Point(btn2.Location.X + ConstantFrame.SizeButton / 2, btn2.Location.Y + ConstantFrame.SizeButton / 2));
        }

        private void PaintLine(Pen pen, Point p1, Point p2)
        {
            Graphics g = CreateGraphics();
            g.DrawLine(pen, p1, p2);
        }

        private Point PointCenterButton(Button btn1, Button btn2)
        {
            int x = 0;
            int y = 0;

            x = btn1.Location.X + btn1.Size.Width / 2;
            y = (btn1.Location.Y + btn1.Height + btn2.Location.Y) / 2;

            return new Point(x, y);
        }

        #endregion

        #region Data of Frame
        // Convert string MAC to byte MAC
        private byte[] ConvertMACtoByte(string mac)
        {
            string[] Sresult = mac.Split(':');
            byte[] result = new byte[6];

            for (int i = 0; i < 6; i++)
            {
                result[i] = (byte)Convert.ToInt32(Sresult[i], 16);
            }
            return result;
        }

        // Create Packet
        private int CountPacket(List<byte> Buffer, int size = ConstantFrame.SizePacket)
        {
            if (Buffer.Count < size)
                return 1;

            if (Buffer.Count % size != 0)
                return Buffer.Count / size + 1;
            else
                return Buffer.Count / size;
        }

        // Frame data send
        private List<byte> DataSend(List<byte> Data, string TypeDataSend, string ipSend, string ipReceive)
        {
            List<byte> result = new List<byte>();

            result.AddRange(Encoding.UTF8.GetBytes(ConstantFrame.StartFrame));
            result.AddRange(ConvertMACtoByte(ipReceive));
            result.AddRange(ConvertMACtoByte(ipSend));
            result.AddRange(Encoding.UTF8.GetBytes(TypeDataSend));
            if (TypeDataSend == "FF")
            {
                result.AddRange(Encoding.UTF8.GetBytes(txbData.Text));
                result.AddRange(Encoding.UTF8.GetBytes(ConstantFrame.StartFrame));
            }
            else
            {
                result.AddRange(Data);
            }

            result.AddRange(Encoding.UTF8.GetBytes(ConstantFrame.EndFrame));

            return result;
        }

        // Split IP Start End
        // Return data
        private byte[] SplitDataOfFrame(byte[] data)
        {
            int end = 0;
            for (int i = data.Length - 1; i > 0; i--)
            {
                if (data[i] != 0)
                {
                    end = i;
                    break;
                }
            }
            List<byte> data1 = data.ToList();
            return data1.GetRange(8 + 6 + 6 + 2, end - 6 + 1 - (8 + 6 + 6 + 2)).ToArray();
        }

        // Stop Receive
        private bool CheckEndData(List<byte> data)
        {
            string EndArray = ConstantFrame.EndData;
            for (int i = data.Count - 1; i > 0; i--)
            {
                if (data[i] == 0)
                {
                    continue;
                }
                if (Encoding.UTF8.GetString(data.GetRange(i + 1 - EndArray.Length, EndArray.Length).ToArray()) == EndArray)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        #endregion

        #region CSMA 

        List<byte> DataChannel = new List<byte>();

        FileData FileBuffer;

        private static bool TestChannel = true;

        List<ProcessSending> ProcessSends = new List<ProcessSending>();

        // true  : ok
        // fasle : waitting
        private bool CheckChannel()
        {
            //if (DataChannel.Count == 0 || DataChannel.Where(d => d != 0) == null)
            //    return true;

            //return false;
            if (!TestChannel)
                return false;
            else
                return true;
        }

        private void Receive(Computer Com_Receive, List<byte> data)
        {
            Com_Receive.Data.AddRange(data.GetRange(8 + 6 + 6 + 2, data.Count - 22 - 6));//bug???
            Com_Receive.TypeDataReceive = Encoding.UTF8.GetString(data.GetRange(20, 2).ToArray());
        }

        // Send to Com_Receive
        private void Send(List<byte> data, Computer Com_Receive)
        {
            Receive(Com_Receive, data);
            //Com_Receive.Data.AddRange(data);

            //RTT : round trip time
            Thread.Sleep(2 * ConstantFrame.RTT);
        }

        // Send frame
        private void Send(string TypeDataSend, string IPSource, string IPDest)
        {
            ProcessSending ps = ProcessSends.Find(p => p.IPSource == IPSource && p.IPDest == IPDest && p.Status == "Sending");
            Computer Com_Send = ListComputers.Find(c => c.MAC == IPSource);
            Computer Com_Receive = ListComputers.Find(c => c.MAC == IPDest);
            Com_Receive.RemoveData();

            PaintLine(Pens.Red, Com_Send.GetPoint, Com_Send.GetButton);
            PaintLine(Pens.Red, Com_Receive.GetPoint, Com_Receive.GetButton);
            PaintLine(Pens.Red, Com_Send.GetPoint, Com_Receive.GetPoint);
            Com_Send.GetButton.BackColor = Color.Red;
            Com_Receive.GetButton.BackColor = Color.Red;

            //if (TypeDataSend == "MM")
            //{
            //    Com_Send.Data = Encoding.UTF8.GetBytes(txbData.Text).ToList();
            //}
            //if(TypeDataSend == "FF")
            //{

            //}
            DataChannel = ps.Data;
            int length = CountPacket(DataChannel);
            int size = ConstantFrame.SizePacket;
            Soluong = length;
            // Create frames -> send
            for (int i = 0; i < length; i++)
            {
                if (i == length - 1)
                {
                    List<byte> dataEnd = new List<byte>();
                    dataEnd.AddRange(DataChannel.GetRange(i * size, DataChannel.Count - i * size));
                    dataEnd.AddRange(Encoding.UTF8.GetBytes(ConstantFrame.EndData));
                    Send(DataSend(dataEnd, TypeDataSend, IPSource, IPDest), Com_Receive);
                }
                else
                {
                    Send(DataSend(DataChannel.GetRange(i * size, size), TypeDataSend, IPSource, IPDest), Com_Receive);
                }
            }

            ProcessSends.Find(p => p.IPSource == IPSource && p.IPDest == IPDest).Status = "Complete";
            //UpdateDataGridView(dgvView);

            // Remove DataChannel
            PaintLine(Pens.Black, Com_Send.GetPoint, Com_Send.GetButton);
            PaintLine(Pens.Black, Com_Receive.GetPoint, Com_Receive.GetButton);
            PaintLine(Pens.Black, Com_Send.GetPoint, Com_Receive.GetPoint);
            Com_Send.GetButton.BackColor = Control.DefaultBackColor;
            Com_Receive.GetButton.BackColor = Control.DefaultBackColor;

            DataChannel.RemoveRange(0, DataChannel.Count);
            TestChannel = true;



            // Show
            ConverDataReceive(Com_Receive);
        }

        // Data receive convert
        // type == MM : AddMessage
        // type == FF : AddFile
        private void ConverDataReceive(Computer Com_Receive)
        {
            string type = Com_Receive.TypeDataReceive;
            List<byte> data = Com_Receive.Data.GetRange(0, Com_Receive.Data.Count - ConstantFrame.EndData.Length);
            if (type == "MM")
            {
                string message = Encoding.UTF8.GetString(data.ToArray());
                txbOutput.Text = message;
            }
            if (type == "FF")
            {
                int split = 0;
                for (int i = 0; i < data.Count - 1; i++)
                {
                    if (Encoding.UTF8.GetString(data.GetRange(i, ConstantFrame.StartFrame.Length).ToArray()) == ConstantFrame.StartFrame)
                    {
                        split = i + ConstantFrame.StartFrame.Length;
                        break;
                    }
                }
            }
        }

        private void CSMA_1Persistent(string TypeDataSend, string IPSource, string IPDest)
        {
            while (!CheckChannel())
            {
                ListComputers.Find(c => c.MAC == IPSource).G++;
                Thread.Sleep(1 * ConstantFrame.MiniSlot);//2
            }
            TestChannel = false;
            ProcessSends.Find(p => p.IPSource == IPSource && p.IPDest == IPDest && p.Status == "Waitting").Status = "Sending";
            //UpdateDataGridView(dgvView);
            ListComputers.Find(c => c.MAC == IPSource).S++;
            Send(TypeDataSend, IPSource, IPDest);
        }

        private void CSMA_1Persistent()
        {
            string type = btnTypeData.Text;
            string IPSource = cbComputerSend.Text;
            string IPDest = cbComputerReceive.Text;

            //UpdateDataGridView(dgvView);
            CSMA_1Persistent(type, IPSource, IPDest);
        }

        private void CSMA_pPersistent(string TypeDataSend, string IPSource, string IPDest)
        {
            while (!CheckChannel())
            {
                Thread.Sleep(2 * ConstantFrame.MiniSlot);
            }
            Random ran = new Random();
            int l = ran.Next(0, 100);
            if (l <= 10)
            {
                TestChannel = false;
                ProcessSends.Find(p => p.IPSource == IPSource && p.IPDest == IPDest && p.Status == "Waitting").Status = "Sending";
                Send(TypeDataSend, IPSource, IPDest);
            }
            else
            {
                Thread.Sleep(l * ConstantFrame.MiniSlot / 100);
                CSMA_pPersistent(TypeDataSend, IPSource, IPDest);
            }
        }

        private void CSMA_pPersistent()
        {
            string type = btnTypeData.Text;
            string IPSource = cbComputerSend.Text;
            string IPDest = cbComputerReceive.Text;
            //UpdateDataGridView(dgvView);
            CSMA_pPersistent(type, IPSource, IPDest);
        }

        private void CSMA_NonePersistent(string TypeDataSend, string IPSource, string IPDest)
        {
            Random ran = new Random();
            while (!CheckChannel())
            {
                int l = 0;
                l = ran.Next(0, 5);
                Thread.Sleep(l * ConstantFrame.MiniSlot);
            }
            TestChannel = false;
            ProcessSends.Find(p => p.IPSource == IPSource && p.IPDest == IPDest && p.Status == "Waitting").Status = "Sending";
            Send(TypeDataSend, IPSource, IPDest);
        }

        private void CSMA_NonePersistent()
        {
            string type = btnTypeData.Text;
            string IPSource = cbComputerSend.Text;
            string IPDest = cbComputerReceive.Text;

            CSMA_NonePersistent(type, IPSource, IPDest);
        }

        private void CSMA_CD()
        {
            string type = btnTypeData.Text;
            string IPSource = cbComputerSend.Text;
            string IPDest = cbComputerReceive.Text;

            CSMA_CD(type, IPSource, IPDest);
        }

        private double k_CD = 0;

        private void CSMA_CD(string type, string IPSource, string IPDest)
        {
            while (!CheckChannel() || Collision_CSMA_CD)
            {
                ListComputers.Find(c => c.MAC == IPSource).G++;
                Thread.Sleep(2 * ConstantFrame.MiniSlot);
                k_CD++;
            }
            TestChannel = false;
            ProcessSends.Find(p => p.IPSource == IPSource && p.IPDest == IPDest && p.Status == "Waitting").Status = "Sending";
            //UpdateDataGridView(dgvView);
            ListComputers.Find(c => c.MAC == IPSource).S++;
            Send_CSMA_CD(type, IPSource, IPDest);
        }

        private void Send_CSMA_CD(string TypeDataSend, string IPSource, string IPDest)
        {
            ProcessSending ps = ProcessSends.Find(p => p.IPSource == IPSource && p.IPDest == IPDest && p.Status == "Sending");
            Computer Com_Send = ListComputers.Find(c => c.MAC == IPSource);
            Computer Com_Receive = ListComputers.Find(c => c.MAC == IPDest);
            Com_Receive.RemoveData();

            PaintLine(Pens.Red, Com_Send.GetPoint, Com_Send.GetButton);
            PaintLine(Pens.Red, Com_Receive.GetPoint, Com_Receive.GetButton);
            PaintLine(Pens.Red, Com_Send.GetPoint, Com_Receive.GetPoint);
            Com_Send.GetButton.BackColor = Color.Red;
            Com_Receive.GetButton.BackColor = Color.Red;

            DataChannel = ps.Data;
            int length = CountPacket(DataChannel);
            int size = ConstantFrame.SizePacket;
            Soluong = length;

            bool CheckCollision = false;
            // Create frames -> send
            for (int i = 0; i < length; i++)
            {
                if (i == length - 1)
                {
                    List<byte> dataEnd = new List<byte>();
                    dataEnd.AddRange(DataChannel.GetRange(i * size, DataChannel.Count - i * size));
                    dataEnd.AddRange(Encoding.UTF8.GetBytes(ConstantFrame.EndData));
                    Send_CSMA_CD(DataSend(dataEnd, TypeDataSend, IPSource, IPDest), Com_Receive);
                }
                else
                {
                    Send_CSMA_CD(DataSend(DataChannel.GetRange(i * size, size), TypeDataSend, IPSource, IPDest), Com_Receive);
                }

                if (Collision_CSMA_CD)
                {
                    CheckCollision = true;
                    break;
                }
            }

            if (!CheckCollision)
            {
                ProcessSends.Find(p => p.IPSource == IPSource && p.IPDest == IPDest).Status = "Complete";
                //UpdateDataGridView(dgvView);

                // Remove DataChannel

                PaintLine(Pens.Black, Com_Send.GetPoint, Com_Send.GetButton);
                PaintLine(Pens.Black, Com_Receive.GetPoint, Com_Receive.GetButton);
                PaintLine(Pens.Black, Com_Send.GetPoint, Com_Receive.GetPoint);
                Com_Send.GetButton.BackColor = Control.DefaultBackColor;
                Com_Receive.GetButton.BackColor = Control.DefaultBackColor;

                DataChannel.RemoveRange(0, DataChannel.Count);
                TestChannel = true;

                // Show
                ConverDataReceive(Com_Receive);
            }
            else
            {
                PaintLine(Pens.Yellow, Com_Send.GetPoint, Com_Send.GetButton);
                PaintLine(Pens.Black, Com_Receive.GetPoint, Com_Receive.GetButton);
                PaintLine(Pens.Black, Com_Send.GetPoint, Com_Receive.GetPoint);
                Com_Send.GetButton.BackColor = Color.Yellow;
                Com_Receive.GetButton.BackColor = Control.DefaultBackColor;

                ProcessSends.Find(p => p.IPSource == IPSource && p.IPDest == IPDest && p.Status == "Sending").Status = "Waitting";
                TestChannel = true;

                if (Congestion_CSMA_CD == "Continue")
                {
                    Congestion_CSMA_CD = IPSource;
                    k_CD = Math.Pow(2,k_CD);
                    
                    Thread.Sleep((int)k_CD * 10/*ConstantFrame.MiniSlot*/);
                    CSMA_CD(TypeDataSend, IPSource, IPDest);
                }
                else // lbCongestion.Text != IPSource
                {
                    CSMA_CD(TypeDataSend, IPSource, IPDest);
                }
            }
        }

        private void Send_CSMA_CD(List<byte> data, Computer Com_Receive)
        {
            Receive(Com_Receive, data);

            //RTT : round trip time
            Thread.Sleep(2 * ConstantFrame.RTT);
        }

        private void btnCollision_Click(object sender, EventArgs e)
        {
            if (!Collision_CSMA_CD)
            {
                btnCollision.Text = "Warning Collionsion";
                Collision_CSMA_CD = true;
            }
            else
            {
                btnCollision.Text = "Create Collionsion";
                Collision_CSMA_CD = false;
            }
        }

        private void btnCollision_TextChanged(object sender, EventArgs e)
        {
            //if(btnCollision.Text == "Warning Collionsion")
            //{
            //    Collision_CSMA_CD = true;
            //}
            //else
            //{
            //    Collision_CSMA_CD = false;
            //}
        }

        //Collision
        private static bool Collision_CSMA_CD = false;
        private static string Congestion_CSMA_CD = "Continue";

        private void UpdateDataGridView(DataGridView view)
        {
            view.DataSource = null;
            view.DataSource = ProcessSends;
        }

        #endregion

        #region Button
        private void btnSend_Click(object sender, EventArgs e)
        {
            ProcessSending process = new ProcessSending(cbComputerSend.Text, cbComputerReceive.Text, btnTypeData.Text);

            if (btnTypeData.Text == "MM")
            {
                process.Data.AddRange(Encoding.UTF8.GetBytes(txbData.Text));
            }
            else //"FF"
            {
                process.Data.AddRange(Encoding.UTF8.GetBytes(txbData.Text));
                process.Data.AddRange(FileBuffer.DataFile);
            }

            ProcessSends.Add(process);

            Computer comSend = ListComputers.Find(c => c.MAC == process.IPSource);
            comSend.GetButton.BackColor = Color.Yellow;
            PaintLine(Pens.Yellow, comSend.GetPoint, comSend.GetButton);

            switch (cbTypeCSMA.Text)
            {
                case "1 Persistent":
                    Thread Thread_1Persistent = new Thread(CSMA_1Persistent);
                    Thread_1Persistent.Priority = ThreadPriority.Lowest;
                    Thread_1Persistent.IsBackground = true;
                    Thread_1Persistent.Start();

                    //CSMA_1Persistent();
                    break;
                case "P Persistent":
                    Thread Thread_pPersistent = new Thread(CSMA_pPersistent);
                    Thread_pPersistent.IsBackground = true;
                    Thread_pPersistent.Start();

                    //CSMA_pPersistent();
                    break;
                case "None Persistent":
                    Thread Thread_NonePersistent = new Thread(CSMA_NonePersistent);
                    Thread_NonePersistent.IsBackground = true;
                    Thread_NonePersistent.Start();
                    break;
                case "CSMA/CD":
                    Thread Thread_CSMACD = new Thread(CSMA_CD);
                    Thread_CSMACD.IsBackground = true;
                    Thread_CSMACD.Start();

                    //CSMA_CD();
                    break;
                case "CSMA/CA": break;
                default:
                    break;
            }

            btnViewProcess_Click(this, new EventArgs());
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = Ofd.FileName;
                txbData.Text = Ofd.SafeFileName;
                List<string> subType = fileName.Split('.').ToList();
                List<byte> Data = new List<byte>();

                FileBuffer = new FileData(fileName, File.ReadAllBytes(fileName).ToList());
                btnTypeData.Text = "FF";
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = $"{FileBuffer.TypeName} File (*.{FileBuffer.TypeName})|*.{FileBuffer.TypeName}|Text File (*.txt)|*.txt"; ;

            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(save.FileName, FileBuffer.DataFile.ToArray());
            }

        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            if (FileBuffer != null)
                FileBuffer.DataFile = new List<byte>();

            btnCreateChanel_Click(sender, e);

            ProcessSends = new List<ProcessSending>();
            txbData.Text = string.Empty;
            txbOutput.Text = string.Empty;

            foreach (var item in ListComputers)
            {
                item.G = 0;
                item.S = 0;
                item.RemoveData();
                item.GetButton.BackColor = Control.DefaultBackColor;
                PaintLine(Pens.Black, item.GetPoint, item.GetButton);
            }

            UpdateDataGridView(dgvView);
            MessageBox.Show("Data is removed");
        }

        private void btnViewProcess_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(dgvView);
        }

        private void lbTypeData_Click(object sender, EventArgs e)
        {

        }

        private void btnTypeData_Click(object sender, EventArgs e)
        {
            if (btnTypeData.Text == "MM")
                btnTypeData.Text = "FF";
            else
                btnTypeData.Text = "MM";
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            switch (cbTypeCSMA.Text)
            {
                case "1 Persistent":
                    ViewThrought();
                    break;
                default:
                    break;
            }

        }

        private static int Soluong = 0;
        private List<GandS> Experiment_CSMA = new List<GandS>();

        private void CaculatorThroughput_1per()
        {
            double s = 0, g = 0;
            foreach (var item in ListComputers)
            {
                s += item.S;
                g += item.G;
            }

            double G_CSMA = 0, S_CSMA = 0;

            G_CSMA = (g - s) * 1 / ((g - s) * 1 + s * Soluong * 4);
            S_CSMA = s * Soluong * 4 / ((g - s) * 1 + s * Soluong * 4);
            //MessageBox.Show(G_CSMA.ToString());
            //MessageBox.Show(S_CSMA.ToString());
            Experiment_CSMA.Add(new GandS(G_CSMA, S_CSMA));
        }

        private void ViewThrought()
        {
            CaculatorThroughput_1per();
            double g = 0, s = 0;
            for (int i = 0; i < Experiment_CSMA.Count; i++)
            {
                g += Experiment_CSMA[i].G;
                s += Experiment_CSMA[i].S;
            }

            g = g / Experiment_CSMA.Count;
            s = s / Experiment_CSMA.Count;

            ConstantFrame.G_Graph = g;
            ConstantFrame.S_Graph = s;
            //MessageBox.Show($"G = {g}\nS = {s}");
        }

        private void CSMA_Load(object sender, EventArgs e)
        {

        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            btnView_Click(sender, e);
            GraphTheory graph = new GraphTheory();
            graph.ShowDialog();
        }

        #endregion

    }

    public class GandS
    {
        public double G { get; set; }

        public double S { get; set; }

        public GandS(double g, double s)
        {
            this.G = g;
            this.S = s;
        }
    }
}
