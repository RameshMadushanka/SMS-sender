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
using System.Data.OleDb;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Data;
using System.Windows.Forms;

using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Data.OleDb;
using System.Collections;



namespace Multi_Sms_Sender__By_Group_1_
{
    /// <summary>
    /// Interaction logic for multisms.xaml
    /// </summary>
    public partial class multisms : Window
    {
        ArrayList failnumber = new ArrayList();
        //SendMassge send = new SendMassge();
         ArrayList array;
       SerialPort []arrr = new SerialPort[100] ;
       ArrayList number = new ArrayList();
        SerialPort sp;
        SendMassge sendm = new SendMassge();
        public static bool connected = false;
        int faild = 0;

        string simcompany = "";

        DataGridView dg = new DataGridView();


        public multisms(SerialPort []arr)
        {
            InitializeComponent();
            dg.Name = "dg";
            for(int i=0 ;i<100;i++){
                this.arrr[i] = arr[i];
              //  MessageBox.Show(arr[i].PortName);
               

            }
        }
        public void getdata(string path)
        {

            


            string getdata = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";
            OleDbConnection conn = new OleDbConnection(getdata);
            OleDbDataAdapter oap = new OleDbDataAdapter("Select * from [Sheet1$]", conn);
            DataTable dt = new DataTable();
            //  DataGridCell = new DataGridCell()
            oap.Fill(dt);
            importtable.ItemsSource = dt.DefaultView;

            dg.DataSource = dt;

            // list.GetItemText = dt;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                //  path.Text = opf.FileName;
                getdata(opf.FileName);
            }

        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {



       
       
            DataTable dt = (DataTable)dg.DataSource;
           foreach (DataRow row in dt.Rows)
           {
            number.Add(row[0].ToString());
             //  Multimsgbox.AppendText(row[0].ToString()+"\r");
               

           }
         
            string masg = new TextRange(Multimsgbox.Document.ContentStart, Multimsgbox.Document.ContentEnd).Text; ;
            string s;
            int count = 0;
            
            totalnum.Content = number.Count;
            foreach(string i in number){


                s = "0"+i;

                if(s.Length != 10){
                    garbage.AppendText(s+"\r");
                faild++;
                this.fail.Content = faild;

              
               
                }else{
                count++;
                sendnum.Content = count;
                       sendmassege(s,masg);

                }

            
                
                Thread.Sleep(1000);
                
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
                        sendm.sendmsg(arrr[71], msg, number);
                    }
                    else
                    {

                        garbage.AppendText(number + "\r");
                        faild++;
                        this.fail.Content = faild;

                    }

                }
                else if (s == 75)
                {
                    if (string.Compare(arrr[75].PortName, "COM1") != 0)
                    {
                        insert(number, msg);
                        sendm.sendmsg(arrr[75], msg, number);
                    }
                    else
                    {

                        garbage.AppendText(number + "\r");
                        faild++;
                        this.fail.Content = faild;

                    }

                    // portnum = ht.;
                }
                else if (s == 72)
                {

                    if (string.Compare(arrr[72].PortName, "COM1") != 0)
                    {
                        insert(number, msg);
                        sendm.sendmsg(arrr[72], msg, number);
                    }
                    else
                    {

                        garbage.AppendText(number + "\r");
                        faild++;
                        this.fail.Content = faild;

                    }

                }
                else if (s == 78)
                {



                    if (string.Compare(arrr[78].PortName, "COM1") != 0)
                    {
                        //   MessageBox.Show(msg);
                        // MessageBox.Show(number);
                        insert(number, msg);
                        sendm.sendmsg(arrr[78], msg, number);
                    }
                    else
                    {

                        garbage.AppendText(number + "\r");
                        faild++;
                        this.fail.Content = faild;

                    }


                }
                else if ((s == 77))
                {
                    if (string.Compare(arrr[77].PortName, "COM1") != 0)
                    {
                        insert(number, msg);
                        sendm.sendmsg(arrr[77], msg, number);
                    }
                    else
                    {

                        garbage.AppendText(number + "\r");
                        faild++;
                        this.fail.Content = faild;

                    }

                }
                else if ((s == 76))
                {


                    if (string.Compare(arrr[76].PortName, "COM1") != 0)
                    {
                        insert(number, msg);
                        sendm.sendmsg(arrr[76], msg, number);
                    }
                    else
                    {

                        garbage.AppendText(number + "\r");
                        faild++;
                        this.fail.Content = faild;

                    }

                }
                else
                {

                    garbage.AppendText(number + "\r");
                    faild++;
                    this.fail.Content = faild;

                }
            }catch(Exception){

            }
        }

        public void insert(string number, string massages)
        {

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
            }
            catch (Exception)
            {

            }
        }

    }
}
