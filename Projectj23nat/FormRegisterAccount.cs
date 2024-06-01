using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Projectj23nat
{
    public partial class FormRegisterAccount : Form
    {
        string mysqlquary;
        string mysqlconnection = "server=localhost;uid=root;database=afl2sem3";
        int saveslot;
        MySqlConnection myconnection;
        MySqlCommand mycommand;
        MySqlDataAdapter myadapter;
        MySqlDataReader myreader;
        DataTable dt = new DataTable();
        DataTable dtcart = new DataTable();

        string[] month = { "All", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        string[] type = { "COGS", "Operational Cost", "Other Cost" };
        int[] qty = { 0, 0, 0, 0, 0 };
        int totalitas = 0;

        string name,gender,  role,salary,  city, birthdate,  nik, shift, address;
        public FormRegisterAccount(string name, string gender , string role, string salary, string city, string birthdate, string nik, string shift, string address)
        {
            InitializeComponent();
            this.name = name;
            this.gender = gender;
            this.role = role;
            this.salary = salary;
            this.city = city;
            this.birthdate = birthdate;
            this.nik = nik;
            this.shift = shift;
            this.address = address;
            GetSQLData("Makanan");

        }
        private void GetSQLData(string type)
        {
            qty[0] = 0;
            qty[1] = 0;
            qty[2] = 0;
            qty[3] = 0;
            qty[4] = 0;
            dt = new DataTable();
            mysqlquary = $"select * from list_item where jenis_item = '{type}';";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
            dt.Columns.Add("qty");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][4] = 0;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {

            if (tbox_name.Text != "" && tbox_pass.Text != "")
            {
                myconnection.Open();
                mysqlquary = $"insert into KARYAWAN ( username, nama_lengkap, gender, peran, gaji_per_bulan, city, birthdate, nik,shift,address) value ( '{tbox_name.Text}', '{name}', '{gender}', '{role}', {salary},'{city}', '{birthdate}', '{nik}', '{shift}', '{address}');";
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myreader = mycommand.ExecuteReader();
                myconnection.Close();

                DataTable dtlaster = new DataTable();
                mysqlquary = $"call pAmbilIDTerakhirEmployee();";
                myconnection = new MySqlConnection(mysqlconnection);
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myadapter = new MySqlDataAdapter(mycommand);
                myadapter.Fill(dtlaster);

                myconnection.Open();
                mysqlquary = $"insert into USERDATA(username, pasword, id_karyawan)  value  ('{tbox_name.Text}', '{tbox_pass.Text}' , '{dtlaster.Rows[0][0].ToString()}');";
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myreader = mycommand.ExecuteReader();
                myconnection.Close();

                MessageBox.Show("New Employee Account has been Created");
                this.Close();
            }
            else
            {
                MessageBox.Show("Missing Data");
            }
        }
    }
}
