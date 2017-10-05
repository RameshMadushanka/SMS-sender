using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Data.OleDb;
using System.Collections;


namespace Multi_Sms_Sender__By_Group_1_
{
    /// <summary>
    /// Interaction logic for singlesms.xaml
    /// </summary>
    public partial class singlesms : Window
    {

        ArrayList array;
       SerialPort []arrr = new SerialPort[100] ;
        SerialPort sp;
        SendMassge send = new SendMassge();
        public static bool connected = false;

        string simcompany = "";



        public singlesms(SerialPort []arr)
        {
            InitializeComponent();
            for(int i=0 ;i<100;i++){
                this.arrr[i] = arr[i];
              //  MessageBox.Show(arr[i].PortName);
               

            }

           

            
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void singlesend_Click(object sender, RoutedEventArgs e)
        {
            string num = this.number.Text;
            if(num != null){
            string masg = new TextRange(msg.Document.ContentStart, msg.Document.ContentEnd).Text; ;


            sendmassege(num, masg);
            number.Text = "";
            //msg.set;
            }else{
                MessageBox.Show("Enter Phone Number");
            }
        }


        void sendmassege(string number, string msg)
        {
            try
            {


                int s = Int32.Parse(number.Substring(1, 2));
                //  MessageBox.Show(s.ToString());
                string portnum;
                //Hashtable hashtable = GetHashtable();

                if (s == 71)
                {

                    if (string.Compare(arrr[71].PortName, "COM1") != 0)
                    {
                        insert(number, msg);
                        send.sendmsg(arrr[71], msg, number);
                    }
                    else
                    {

                        MessageBox.Show("Cannot Send Massege . ");
                    }

                }
                if (s == 75)
                {
                    if (string.Compare(arrr[75].PortName, "COM1") != 0)
                    {
                        insert(number, msg);
                        send.sendmsg(arrr[75], msg, number);
                    }
                    else
                    {

                        MessageBox.Show("Cannot Send Massege . ");
                    }

                    // portnum = ht.;
                }
                if (s == 72)
                {

                    if (string.Compare(arrr[72].PortName, "COM1") != 0)
                    {
                        insert(number, msg);
                        send.sendmsg(arrr[72], msg, number);
                    }
                    else
                    {

                        MessageBox.Show("Cannot Send Massege . ");
                    }

                }
                if (s == 78)
                {



                    if (string.Compare(arrr[78].PortName, "COM1") != 0)
                    {

                        insert(number, msg);

                        send.sendmsg(arrr[78], msg, number);
                    }
                    else
                    {

                        MessageBox.Show("Cannot Send Massege . ");
                    }


                }
                if ((s == 77))
                {
                    if (string.Compare(arrr[77].PortName, "COM1") != 0)
                    {
                        insert(number, msg);
                        send.sendmsg(arrr[77], msg, number);
                    }
                    else
                    {

                        MessageBox.Show("Cannot Send Massege . ");
                    }

                }
                if ((s == 76))
                {


                    if (string.Compare(arrr[76].PortName, "COM1") != 0)
                    {
                        insert(number, msg);
                        send.sendmsg(arrr[76], msg, number);
                    }
                    else
                    {

                        MessageBox.Show("Cannot Send Massege . ");
                    }

                }
            }catch(Exception){


            }

        }


        public void insert( string number , string massages){

            try
            {
                //DateTime now = DateTime.Now;
                //now.ToString("h:mm:ss tt");
                DateTime date = DateTime.Now;
                date.ToString("M/d/yyyy");
                //    MessageBox.Show(date.ToString());

                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                string sql = null;
                MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\smssender\\data.xls;Extended Properties=Excel 8.0");
                MyConnection.Open();
                myCommand.Connection = MyConnection;
                sql = "Insert into [Sheet1$] (Send_Date,Phone_Number,Massege) values('" + date.ToString() + "','" + number + "','" + massages + "')";
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
                MyConnection.Close();
            }catch(Exception){

            }
    }
    }
}
