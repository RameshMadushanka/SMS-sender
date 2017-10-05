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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Data.OleDb;
using System.Collections;


namespace Multi_Sms_Sender__By_Group_1_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SerialPort []arr = new SerialPort[100];

        port p = new port();

        ArrayList array;
        Hashtable ht = new Hashtable();
        SerialPort sp;
        SerialPort sp1 = new SerialPort();
        public static bool connected = false;

        string simcompany = "";


        public MainWindow()
        {
            
           //
            InitializeComponent();
            for (int i = 0; i < 100;i++ )
            {

                arr[i] = sp1;
            }
            getImpormation();

            //InitializeComponent();
            
        }

        void getImpormation()
        {
            ht.Clear();
            //  array.Clear();
           
            p.getAllComPort();

            array = p.getArray();
            int numport = array.Count;
           // aa.Content = numport.ToString();

            Connectionlabel.Content = "";
            simcompany = "";

            foreach (SerialPort i in array)
            {

                identyfly(i);
            }
            Connectionlabel.Content = simcompany;
           // 
        }

        void identyfly(SerialPort sp)
        {
            try
            {
                string t = "";
                int timeout = 10000;


                if (!sp.IsOpen)
                {

                    sp.Open();
                }

                if (sp.IsOpen)
                {



                    connected = true;


                    sp.WriteLine("AT");
                    sp.WriteLine("AT+CSCA?");


                   System.Threading.Thread.Sleep(200);


                    while (!((t = sp.ReadExisting()).Contains("OK")) && timeout > 0)
                    {

                        timeout--;
                    }

                    if (!(t.Equals("")) && !(t.Equals(null)))
                    {

                        char[] z = new char[2];
                        z[0] = '\r';
                        z[1] = '\n';
                        string[] f = new string[100];
                        string[] c = t.Split(z);
                        int m = 0;

                        for (int i = 0; i < c.Length; i++)
                        {
                            if (!(c[i].Equals("")))
                            {
                                f[m] = c[i];
                                m++;
                            }
                        }



                        for (int i = 0; i < m; i++)
                        {
                            if ((f[i].Equals("AT+CSCA?")))
                            {
                                networkprovider(f[i + 1], sp); // Manufacturer
                            }


                        }

                        sp.BaseStream.Flush();


                    }
                }

            }
            catch (Exception)
            {

            }

        }



        void networkprovider(string servicenumber, SerialPort sp)
        {


            string provider = servicenumber.Substring(11, 2);

            int number = Int32.Parse(provider);


            if (number == 71)
            {

                simcompany = simcompany + "Mobitel ";
                arr[71] = sp;


            }
            if (number == 75)
            {

                simcompany = simcompany + "AirTel ";
                arr[75] = sp;
            }
            if (number == 72)
            {

                simcompany = simcompany + "Etisalat ";
                arr[72] = sp;
            }
            if (number == 78)
            {

                simcompany = simcompany + simcompany + "Hutch ";
                arr[78] = sp;
            }
            if ((number == 77))
            {
                simcompany = simcompany + "Dialog ";
                arr[77] = sp;

            }
            if ((number == 76))
            {

                simcompany = simcompany + "Dialog ";
                arr[76] = sp;

            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            singlesms sm = new singlesms(arr);
            sm.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            multisms ms = new multisms(arr);
            ms.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            history h = new history();
            h.ShowDialog();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void about_click(object sender, RoutedEventArgs e)
        {
            AboutUs h = new AboutUs();
            h.ShowDialog();
        }
    }






}
