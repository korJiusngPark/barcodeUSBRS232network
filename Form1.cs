using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;  //시리얼통신을 위해 추가해줘야 함
using System.IO;

namespace barcodeUSBRS232network
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Serial_connect()
        {
                string port = "COM6";
                serialPort1.PortName = port;  //콤보박스의 선택된 COM포트명을 시리얼포트명으로 지정
                serialPort1.BaudRate = 9600;  //보레이트 변경이 필요하면 숫자 변경하기
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.Handshake = Handshake.None;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); //이것이 꼭 필요하다

                serialPort1.Open();  //시리얼포트 열기
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           // string folderPath = "C:/airLeak/Result";
            DirectoryInfo di = new DirectoryInfo(folderPath);

            if(di.Exists == false)
            {
                di.Create();
            }
            // Serial_connect();
        }

        private void save_csv(string s)
        {
            string resultFolderPath = folderPath + DateTime.Now.ToString("yyMMdd");
            DirectoryInfo di = new DirectoryInfo(resultFolderPath);

            if (di.Exists == false)
            {
                di.Create();
            }

            string fileNmae = resultFolderPath+"/"+ DateTime.Now.ToString("yyMMdd") + ".csv";

            string[] temps = s.Split('\t');
            List<string> word = new List<string>();
            word.Add(barcode);

            foreach (string temp in temps)
            {
                if (temp != "")
                    word.Add(temp); //6개 바코드 추가하면 7개
            }

            FileStream file = new FileStream(fileNmae, FileMode.Append, FileAccess.Write);

            StreamWriter sw = new StreamWriter(file, Encoding.UTF8);

            //if (file.Length == 0)

            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6]", word[0], word[1], word[2], word[3], word[4], word[5],word[6]);
            // using (System.IO.StreamReader file = new System.IO.StreamReader())


            sw.Flush();
            sw.Close();
            file.Close();
        }


        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)  //수신 이벤트가 발생하면 이 부분이 실행된다.
        {
            this.Invoke(new EventHandler(MySerialReceived));  //메인 쓰레드와 수신 쓰레드의 충돌 방지를 위해 Invoke 사용. MySerialReceived로 이동하여 추가 작업 실행.
        }

        private void MySerialReceived(object s, EventArgs e)  //여기에서 수신 데이타를 사용자의 용도에 따라 처리한다.
        {
            string rcvData_byte_format = string.Empty;
            string rcvData_ascii_format = string.Empty;

            while (serialPort1.BytesToRead != 0)
            {
                var num = 0;
                int[] arr_rcvData_bytes = new int[7];
                char[] arr_rcvData_char = new char[7];
                while (num < 7)
                {
                    arr_rcvData_bytes[num] = serialPort1.ReadByte();
                    arr_rcvData_char[num] = Convert.ToChar(arr_rcvData_bytes[num]);

                    rcvData_byte_format += arr_rcvData_bytes[num].ToString("X2");
                    rcvData_ascii_format += arr_rcvData_char[num];

                    num++;
                }
            }
            save_csv(rcvData_ascii_format);
            textBoxBarcode.Clear();
            textBoxBarcode.Focus();
            //richTextBox_received.AppendText("Ascii Format : " + rcvData_ascii_format + "\r\n");
        }

    }
}
