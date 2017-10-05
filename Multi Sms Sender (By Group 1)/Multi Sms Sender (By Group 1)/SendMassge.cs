using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
namespace Multi_Sms_Sender__By_Group_1_
{
    class SendMassge
    {
        public void sendmsg(SerialPort sp, string msg ,string num)
        {


            try
            {
                if(!sp.IsOpen){

                    sp.Open();
                }

                if (sp.IsOpen)
                {

                

                    sp.BaseStream.Flush();

                    sp.WriteLine("AT");
                    sp.WriteLine("AT+CMGF=1\r");
                    sp.WriteLine("AT+CMGS=\"" + num+ "\"\r\n");
                    sp.WriteLine(msg + "\x1A");
                    sp.WriteLine("AT+CGSN");
                    System.Threading.Thread.Sleep(200);

                    sp.BaseStream.Flush();

                }
                else
                {
                    MessageBox.Show("Can not send msg");
                }



            }
            catch (Exception)
            {


            }
        }

    }
}
