using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Management;
using System.IO;
using System.IO.Ports;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace Multi_Sms_Sender__By_Group_1_
{


    class port
    {
       
      
 
        SerialPort sp;
        string servicenumber;
        ArrayList array = new ArrayList();
      
        
     
        public void getAllComPort()
        {



            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_POTSModem ");
            try
            {

                foreach (ManagementObject queryObj1 in searcher1.Get())
                {
                    if ((string)queryObj1["Status"] == "OK")
                    {
                        getInformation(queryObj1["AttachedTo"] + " - " + System.Convert.ToString(queryObj1["Description"]));
                       

                    }
                }

               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }



        private void getInformation(string s)
        {



            string t = "";
            string portname = s;
            int timeout = 10000; //t: response msg
            sp = new SerialPort();
            sp.NewLine = "\r\n";
            sp.BaudRate = 9600;
            sp.Parity = Parity.None;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.Handshake = Handshake.None;
            sp.DtrEnable = true;
            sp.WriteBufferSize = 1024;



            if (s != null)
            {

                try
                {
                    sp.PortName = s;
                    int v = sp.PortName.IndexOf("COM", 0, sp.PortName.Length);
                    sp.PortName = sp.PortName.Substring(v, 5);
                    string port = sp.PortName;


                    char[] port1 = new char[1];
                    port1[0] = ')';

                    if (port.Contains(")"))
                    {
                        port = port.TrimEnd(port1);
                    }

                    if (port.Length >= 5)
                    {
                        port = port.Trim();
                    }

                    sp.PortName = port;


                    array.Add(sp);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }

            }
           


        }

        public ArrayList getArray()
        {

            return array;
        }
        
        




    }
}
