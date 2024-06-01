using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectj23nat
{
    public partial class FormExpense : Form
    {
        string mysqlquary;
        string mysqlconnection = "server=localhost;uid=root;database=afl2sem3";
        int saveslot;
        MySqlConnection myconnection;
        MySqlCommand mycommand;
        MySqlDataAdapter myadapter;
        MySqlDataReader myreader;
        DataTable dt = new DataTable();

        string[] month = {"All","January", "February", "March","April", "May", "June","July", "August", "September","October", "November", "December"};
        string[] type = { "COGS", "Operational Cost", "Other Cost" };

        int page;
        public FormExpense()
        {
            InitializeComponent();
            page = 0;
            GetSQLData();

            Panel[] panelling = { panel1, panel2, panel3, panel4 };
            foreach (Panel panel in panelling)
            {
                panel.Visible = false;
            }
        }
        private void GetSQLData()
        {
            dt.Clear();
            mysqlquary = $"select * from expense where status_del = 'F' order by tanggal_pengeluaran;";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
        }
        private void GetSQLDataSpecific()
        {
            dt.Clear();
            mysqlquary = $"select * from expense where MONTH(tanggal_pengeluaran) = '{cbox_month.SelectedIndex}' and status_del = 'F' order by tanggal_pengeluaran;";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
        }
        private void GenerateLabel()
        {
            Panel[] panelling = { panel1,panel2,panel3,panel4};
            Label[] labelcost = { lbl_cost_1,lbl_cost_2,lbl_cost_3,lbl_cost_4 };
            Label[] labeldtl = { lbl_dtl_1, lbl_dtl_2, lbl_dtl_3, lbl_dtl_4 };
            Label[] labeldesc = { lbl_desc_1, lbl_desc_2, lbl_desc_3, lbl_desc_4 };
            Label[] labeltgl = { lbl_tgl_1, lbl_tgl_2, lbl_tgl_3, lbl_tgl_4 };

            List<int> pagelist = new List<int>();

            foreach (Panel panel in panelling)
            {
                panel.Visible = false;
            }

            int TheLimitofPanel = dt.Rows.Count % panelling.Length;
            int theLimitofPage = dt.Rows.Count / panelling.Length;

            if (page == 0)
            {
                btn_back.Enabled = false;
                btn_next.Enabled = true;
            }
            else if (page == theLimitofPage)
            {
                btn_back.Enabled = true;
                btn_next.Enabled = false;
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
                    pagelist.Add(4);
                }
            }

            //MessageBox.Show(pagelist[page].ToString());

            for (int i = 0; i < pagelist[page]; i++)
            {
                    panelling[i].Visible = true;
                    labelcost[i].Text = String.Format("Rp.{0:C},00", dt.Rows[i+(page*4)][4].ToString());
                    labeldtl[i].Text = dt.Rows[i + (page * 4)][2].ToString();
                    labeldesc[i].Text = dt.Rows[i + (page * 4)][1].ToString();
                    labeltgl[i].Text = dt.Rows[i + (page * 4)][3].ToString();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            page--;
            GenerateLabel();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            page++;
            GenerateLabel();
        }

        private void cbox_month_SelectionChangeCommitted(object sender, EventArgs e)
        {
            page = 0;
            lbl_month.Text = month[cbox_month.SelectedIndex];
            if (cbox_month.SelectedIndex == 0)
            {
                GetSQLData();
            }
            else
            {
                GetSQLDataSpecific();
            }
            GenerateLabel();
        }

        private void cbox_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
           
            if (tbox_name.Text != "" && tbox_cost.Text != "" && cbox_type.SelectedIndex != -1)
            {
                myconnection.Open();
                mysqlquary = $"insert into EXPENSE ( nama_pengeluaran, jenis_pengeluaran, tanggal_pengeluaran, total_pengeluaran, status_del) value ('{tbox_name.Text}', '{type[cbox_type.SelectedIndex]}', str_to_date('{dtp.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}','%d-%m-%Y'), '{tbox_cost.Text}', 'F');";
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myreader = mycommand.ExecuteReader();
                myconnection.Close();

                tbox_name.Text = "";
                tbox_cost.Text = "";
                cbox_type.SelectedIndex = -1;
            }
            
        }

        private void tbox_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}




/*
string mysqlquary;
        string mysqlconnection = "server=localhost;uid=root;database=db_sad";
        int saveslot;
        MySqlConnection myconnection;
        MySqlCommand mycommand;
        MySqlDataAdapter myadapter;
        MySqlDataReader myreader;
        DataTable dt = new DataTable();

myconnection.Open();
            mysqlquary = $"insert into Penjualan (tgl_penjualan,harga_penjualan,promo,merk_mobil,plat_mobil,service_id,status_del) values ( str_to_date('{Data[3]}','%d-%m-%Y'), '{hargaint}', '{promodoubleval}','{Data[0]}','{Data[1]}', '{Data[6]}','F');";
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myreader = mycommand.ExecuteReader();
            myconnection.Close();


mysqlquary = $"select promo_id, promo_discount from promo where status_del = 'F' and if(curdate()<promo_end and curdate()>promo_start  ,\"true\",\"false\") = \"true\" limit 1;";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);


 */
