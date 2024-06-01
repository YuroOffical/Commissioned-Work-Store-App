using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Projectj23nat
{
    public partial class FormEmployeeDetail : Form
    {
        string mysqlquary;
        string mysqlconnection = "server=localhost;uid=root;database=afl2sem3";
        int saveslot;
        MySqlConnection myconnection;
        MySqlCommand mycommand;
        MySqlDataAdapter myadapter;
        MySqlDataReader myreader;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        string[] month = { "All", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        string[] type = { "COGS", "Operational Cost", "Other Cost" };

        int page, ID, PageID;
        public Form1 FormRef { get; set; }
        public FormEmployeeDetail(int ID, int Page)
        {
            InitializeComponent();
            this.ID = ID;
            this.page = Page;
            this.PageID = ID + (Page * 5);
            GetSQLData();
            GenerateData();
        }
        private void GetSQLData()
        {
            dt.Clear();
            mysqlquary = $"select * from karyawan";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
        }

        private void lbl_role_Click(object sender, EventArgs e)
        {
            if (lbl_role.Text == "Waitress")
            {
                lbl_role.Text = "Kasir";
            }
            else if (lbl_role.Text == "Kasir")
            {
                lbl_role.Text = "Manager";
            }
            else if (lbl_role.Text == "Manager")
            {
                lbl_role.Text = "Staff";
            }
            else if (lbl_role.Text == "Staff")
            {
                lbl_role.Text = "Waitress";
            }
        }

        private void lbl_gender_Click(object sender, EventArgs e)
        {
            if (lbl_gender.Text == "Female")
            {
                lbl_gender.Text = "Male";
            }
            else if (lbl_gender.Text == "Male")
            {
                lbl_gender.Text = "Female";
            }
        }

        private void lbl_shift_Click(object sender, EventArgs e)
        {
            if (lbl_shift.Text == "Morning Shift")
            {
                lbl_shift.Text = "Evening Shift";
            }
            else if (lbl_shift.Text == "Evening Shift")
            {
                lbl_shift.Text = "Morning Shift";
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            FormRef.GetEmployeTab();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string shift = lbl_shift.Text.ToString().Substring(0, lbl_shift.Text.Length - 6);
            string gender = "";
            if (lbl_gender.Text == "Male")
            {
                gender = "L";
            }
            else
            {
                gender = "P";
            }
            string role = lbl_role.Text;
            string name = tbox_name.Text;
            string salary = tbox_salary.Text;
            string birthdate = dtp.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string city = tbox_city.Text;
            string address = tbox_address.Text;
            string nik = tbox_nik.Text;
            string[] dataset1 = { "","",name, gender, role, salary, city, birthdate, nik, shift, address };
            string[] dataset2 = { "","","nama_lengkap", "gender", "peran", "gaji_per_bulan", "city", "birthdate", "nik", "shift", "address"};
            
            for(int i = 2; i < 10; i++)
            {
                //MessageBox.Show($"update karyawan set {dataset2[i]} = '{dataset1[i]}' where id_karyawan = '{dt.Rows[PageID][0].ToString()}';");
                myconnection.Open();
                mysqlquary = $"update karyawan set {dataset2[i]} = '{dataset1[i]}' where id_karyawan = '{dt.Rows[PageID][0].ToString()}';";
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myreader = mycommand.ExecuteReader();
                myconnection.Close();
            }
            FormRef.GetEmployeTab();
            
        }

        private void GenerateData()
        {
            tbox_name.Text = dt.Rows[PageID][2].ToString();
            if (dt.Rows[PageID][3].ToString() == "L")
            {
                lbl_gender.Text = "Male";
            }
            else
            {
                lbl_gender.Text = "Female";
            }
            lbl_role.Text = dt.Rows[PageID][4].ToString();
            tbox_salary.Text = dt.Rows[PageID][5].ToString();
            tbox_city.Text = dt.Rows[PageID][6].ToString();

            string[]dataraw = dt.Rows[PageID][7].ToString().Split(' ');
            string[] data = dataraw[0].Split('/');
            //MessageBox.Show(data[0] + " " + data[1] + " " + data[2]);
            dtp.Value = new DateTime(int.Parse(data[2]), int.Parse(data[1]), int.Parse(data[0]));

            tbox_nik.Text = dt.Rows[PageID][8].ToString();
            lbl_shift.Text = dt.Rows[PageID][9].ToString() + " Shift";
            tbox_address.Text = dt.Rows[PageID][10].ToString();
        }
    }
}
