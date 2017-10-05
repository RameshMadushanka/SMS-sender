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
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Runtime.InteropServices;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel; 
using System.Data.SqlClient; 
using System.Configuration;
using System.Data.OleDb;



namespace Multi_Sms_Sender__By_Group_1_
{
    /// <summary>
    /// Interaction logic for history.xaml
    /// </summary>
    public partial class history : Window
    {
        public history()
        {
            InitializeComponent();
            inpoerdata();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        void inpoerdata()
        {
            try
            {
                string getdata = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\smssender\\data.xls;Extended Properties=\"Excel 8.0;HDR=Yes;\";";
                OleDbConnection conn = new OleDbConnection(getdata);
                OleDbDataAdapter oap = new OleDbDataAdapter("Select * from [Sheet1$]", conn);
                DataTable dt = new DataTable();
                //  DataGridCell = new DataGridCell()
                oap.Fill(dt);
                historytable.ItemsSource = dt.DefaultView;


            }catch(Exception){

            }
        }


    }
}
