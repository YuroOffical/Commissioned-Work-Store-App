using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MySql.Data.MySqlClient;

namespace Projectj23nat
{
    public partial class Form1 : Form
    {
        Thread thread;
        string state;

        
        string mysqlquary;
        string mysqlconnection = "server=localhost;uid=root;database=afl2sem3";
        int saveslot;
        MySqlConnection myconnection;
        MySqlCommand mycommand;
        MySqlDataAdapter myadapter;
        MySqlDataReader myreader;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public Form1(string state)
        {
            InitializeComponent();
            InitialLogo();
            lbl_menu_5.Font = new Font("Inter", 16, FontStyle.Regular);
            lbl_menu_4.Font = new Font("Inter", 16, FontStyle.Regular);
            lbl_menu_3.Font = new Font("Inter", 16, FontStyle.Regular);
            lbl_menu_2.Font = new Font("Inter", 16, FontStyle.Regular);
            lbl_menu_1.Font = new Font("Inter", 16, FontStyle.Regular);
            this.state = state;

        }
        private void openmenu(object obj)
        {
            Application.Run(new FormLogin());
        }
        public void GenerateLoginScreen()
        {
            this.Close();
            thread = new Thread(openmenu);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void InitialLogo()
        {
            FormLogo formlogo = new FormLogo();
            formlogo.TopLevel = false;
            formlogo.Dock = DockStyle.Fill;
            pnlmain.Controls.Add(formlogo);
            formlogo.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_menu_5_Click(object sender, EventArgs e)
        {
            if (lbl_role.Text == "Manager")
            {
                lbl_menu_5.Font = new Font("Inter", 16, FontStyle.Bold);
                lbl_menu_4.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_3.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_2.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_1.Font = new Font("Inter", 16, FontStyle.Regular);

                pnlmain.Controls.Clear();
                FormExpense form = new FormExpense();
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                pnlmain.Controls.Add(form);
                form.Show();
            }
            else
            {
                MessageBox.Show("Access Denied");
            }


            
        }
        public void ViewBillTab()
        {
            pnlmain.Controls.Clear();
            FormBillTap form = new FormBillTap();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            pnlmain.Controls.Add(form);
            form.FormRef = this;
            form.Show();
        }
        private void lbl_menu_4_Click(object sender, EventArgs e)
        {


            lbl_menu_5.Font = new Font("Inter", 16, FontStyle.Regular);
            lbl_menu_4.Font = new Font("Inter", 16, FontStyle.Bold);
            lbl_menu_3.Font = new Font("Inter", 16, FontStyle.Regular);
            lbl_menu_2.Font = new Font("Inter", 16, FontStyle.Regular);
            lbl_menu_1.Font = new Font("Inter", 16, FontStyle.Regular);

            pnlmain.Controls.Clear();
            FormSOP form = new FormSOP();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormRef = this;
            pnlmain.Controls.Add(form);
            form.Show();
        }

        private void lbl_menu_3_Click(object sender, EventArgs e)
        {
            if (lbl_role.Text == "Manager")
            {
                lbl_menu_5.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_4.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_3.Font = new Font("Inter", 16, FontStyle.Bold);
                lbl_menu_2.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_1.Font = new Font("Inter", 16, FontStyle.Regular);
                GetBack();
            }
            else if (lbl_role.Text == "Kasir")
            {
                lbl_menu_5.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_4.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_3.Font = new Font("Inter", 16, FontStyle.Bold);
                lbl_menu_2.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_1.Font = new Font("Inter", 16, FontStyle.Regular);
                GetBack();
            }
            else
            {
                MessageBox.Show("Access Denied");
            }

            


        }
        public void GetBill(string id)
        {
            pnlmain.Controls.Clear();
            FormBill form = new FormBill(id);
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormRef = this;
            pnlmain.Controls.Add(form);
            form.Show();
        }
        public void GetBack()
        {
            pnlmain.Controls.Clear();
            FormReportHistory form = new FormReportHistory();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormRef = this;
            pnlmain.Controls.Add(form);
            form.Show();
        }

        private void lbl_menu_2_Click(object sender, EventArgs e)
        {
            if (lbl_role.Text == "Manager")
            {
                lbl_menu_5.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_4.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_3.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_2.Font = new Font("Inter", 16, FontStyle.Bold);
                lbl_menu_1.Font = new Font("Inter", 16, FontStyle.Regular);

                pnlmain.Controls.Clear();
                FormItemMaster form = new FormItemMaster();
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                pnlmain.Controls.Add(form);
                form.FormRef = this;
                form.Show();
            }
            else
            {
                MessageBox.Show("Access Denied");
            }

            
        }
        public void GetBilLTab()
        {

        }
        public void GetEmployeTab()
        {
            pnlmain.Controls.Clear();
            FormEmployee form = new FormEmployee();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormRef = this;
            pnlmain.Controls.Add(form);
            form.Show();
        }

        public void GetEmployeDetails(int ID, int page)
        {
            pnlmain.Controls.Clear();
            FormEmployeeDetail form = new FormEmployeeDetail(ID, page);
            form.TopLevel = false;
            form.FormRef = this;
            form.Dock = DockStyle.Fill;
            pnlmain.Controls.Add(form);
            form.Show();
        }
        public void GetItemMaster()
        {
            pnlmain.Controls.Clear();
            FormItemMastery form = new FormItemMastery();
            form.TopLevel = false;
            form.FormRef = this;
            form.Dock = DockStyle.Fill;
            pnlmain.Controls.Add(form);
            form.Show();
        }
        public void StatsRep()
        {
            

            pnlmain.Controls.Clear();
            FormStatistic form = new FormStatistic();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            pnlmain.Controls.Add(form);
            form.Show();
        }
        public void YearRep()
        {
            pnlmain.Controls.Clear();
            FormYearly form = new FormYearly();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            pnlmain.Controls.Add(form);
            form.Show();
        }

        private void lbl_menu_1_Click(object sender, EventArgs e)
        {
            if (lbl_role.Text == "Manager")
            {
                lbl_menu_5.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_4.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_3.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_2.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_1.Font = new Font("Inter", 16, FontStyle.Bold);

                pnlmain.Controls.Clear();
                FormSales form = new FormSales();
                form.TopLevel = false;
                form.FormRef = this;
                form.Dock = DockStyle.Fill;
                pnlmain.Controls.Add(form);
                form.Show();
            }
            else if (lbl_role.Text == "Kasir")
            {
                lbl_menu_5.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_4.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_3.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_2.Font = new Font("Inter", 16, FontStyle.Regular);
                lbl_menu_1.Font = new Font("Inter", 16, FontStyle.Bold);

                pnlmain.Controls.Clear();
                FormSales form = new FormSales();
                form.TopLevel = false;
                form.FormRef = this;
                form.Dock = DockStyle.Fill;
                pnlmain.Controls.Add(form);
                form.Show();
            }
            else
            {
                MessageBox.Show("Access Denied");
            }

            
        }

        public void MainSOP()
        {
            pnlmain.Controls.Clear();
            FormSOP form = new FormSOP();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            pnlmain.Controls.Add(form);
            form.FormRef = this;
            form.Show();
        }
        public void SOPII()
        {
            pnlmain.Controls.Clear();
            FormSOPII form = new FormSOPII();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            pnlmain.Controls.Add(form);
            form.FormRef = this;
            form.Show();
        }
        public void SOPIII()
        {
            pnlmain.Controls.Clear();
            FormSOPIII form = new FormSOPIII();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormRef = this;
            pnlmain.Controls.Add(form);
            form.Show();
        }
        public void SOPIV()
        {
            pnlmain.Controls.Clear();
            FormSOPIV form = new FormSOPIV();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormRef = this;
            pnlmain.Controls.Add(form);
            form.Show();
        }
        public void SOPV()
        {
            pnlmain.Controls.Clear();
            FormSOPV form = new FormSOPV();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormRef = this;
            pnlmain.Controls.Add(form);
            form.Show();
        }
        public void SOPVI()
        {
            pnlmain.Controls.Clear();
            FormSOPVI form = new FormSOPVI();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormRef = this;
            pnlmain.Controls.Add(form);
            form.Show();
        }
        public void SOPVII()
        {
            pnlmain.Controls.Clear();
            FormSOPVII form = new FormSOPVII();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormRef = this;
            pnlmain.Controls.Add(form);
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (state == "start")
            {
                GenerateLoginScreen();
            }
            else
            {
                string[] datausername = state.Split(',');

                dt = new DataTable();
                dt.Clear();
                mysqlquary = $"select id_karyawan from userdata where username = '{datausername[0]}' and pasword = '{datausername[1]}';";
                myconnection = new MySqlConnection(mysqlconnection);
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myadapter = new MySqlDataAdapter(mycommand);
                myadapter.Fill(dt);

                DataTable dta = new DataTable();
                dta.Clear();
                mysqlquary = $"select * from karyawan where id_karyawan = '{dt.Rows[0][0].ToString()}'";
                myconnection = new MySqlConnection(mysqlconnection);
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myadapter = new MySqlDataAdapter(mycommand);
                myadapter.Fill(dta);

                lbl_name.Text = dta.Rows[0][2].ToString();
                lbl_role.Text = dta.Rows[0][4].ToString();
            }
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            GenerateLoginScreen();
        }
    }
}

