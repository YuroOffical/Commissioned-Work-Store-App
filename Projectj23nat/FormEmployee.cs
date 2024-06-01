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
using System.Web.UI.Design;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Projectj23nat
{
    public partial class FormEmployee : Form
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

        int page;
        public FormEmployee()
        {
            InitializeComponent();
            GetSQLData();
            GenerateLabel();
        }
        public Form1 FormRef { get; set; }
        private void GenerateLabel()
        {
            Panel[] panelling = { panel2, panel4, panel6, panel8, panel10 };
            Label[] labelnama = { lbl_nama_1, lbl_nama_2, lbl_nama_3, lbl_nama_4, lbl_nama_5 };

            List<int> pagelist = new List<int>();

            foreach (Panel panel in panelling)
            {
                panel.Visible = false;
            }

            int TheLimitofPanel = dt.Rows.Count % panelling.Length;
            int theLimitofPage = dt.Rows.Count / panelling.Length;

            if (theLimitofPage == 0)
            {
                btn_back.Enabled = false;
                btn_next.Enabled = false;
            }
            else if (page == theLimitofPage)
            {
                btn_back.Enabled = true;
                btn_next.Enabled = false;
            }
            else if (page == 0)
            {
                btn_back.Enabled = false;
                btn_next.Enabled = true;
            }
            else
            {
                btn_back.Enabled = true;
                btn_next.Enabled = true;
            }

            for (int i = 0; i <= theLimitofPage; i++)
            {
                if (i == theLimitofPage)
                {
                    pagelist.Add(TheLimitofPanel);
                }
                else
                {
                    pagelist.Add(5);
                }
            }

            //MessageBox.Show(pagelist[page].ToString());

            for (int i = 0; i < pagelist[page]; i++)
            {
                panelling[i].Visible = true;
                labelnama[i].Text = dt.Rows[i + (page * 5)][2].ToString();
            }
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            FormAddEmployee form = new FormAddEmployee();
            form.ShowDialog();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            page--;
            GenerateLabel();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            page++;
            GenerateLabel();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //FormRef.GetEmployeDetails(0, page);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            //FormRef.GetEmployeDetails(1, page);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            //FormRef.GetEmployeDetails(2, page);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
           // FormRef.GetEmployeDetails(3, page);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            //FormRef.GetEmployeDetails(4, page);
        }

        private void rePictureBox1_Click(object sender, EventArgs e)
        {
            FormRef.GetEmployeDetails(0, page);
        }

        private void rePictureBox2_Click(object sender, EventArgs e)
        {
            FormRef.GetEmployeDetails(1, page);
        }

        private void rePictureBox3_Click(object sender, EventArgs e)
        {
            FormRef.GetEmployeDetails(2, page);
        }

        private void rePictureBox4_Click(object sender, EventArgs e)
        {
            FormRef.GetEmployeDetails(3, page);
        }

        private void rePictureBox5_Click(object sender, EventArgs e)
        {
            FormRef.GetEmployeDetails(4, page);
        }

        private void panel2_Paint(object sender, EventArgs e)
        {

        }
    }
}
