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
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.VisualStyles.VisualStyleElement.ComboBox;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace Projectj23nat
{
    public partial class FormReportHistory : Form
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
        public Form1 FormRef { get; set; }
        public FormReportHistory()
        {
            InitializeComponent();
            page = 0;
            GetSQLData();
            GenerateLabel();
            GenerateAllData();

            Panel[] panelling = { panel10, panel9, panel8, panel7 };
            foreach (Panel panel in panelling)
            {
                panel.Visible = false;
            }
        }
        private void GenerateAllData()
        {
            
            dt2.Clear();
            mysqlquary = $"select harga_total, 'Profit',tanggal_transaksi from htrans where status_del = 'F' and tanggal_transaksi <= str_to_date('{mc_end.SelectionRange.Start.ToShortDateString().Replace('/', '-')}','%d-%m-%Y') and tanggal_transaksi >= str_to_date('{mc_start.SelectionRange.Start.ToShortDateString().Replace('/','-')}','%d-%m-%Y')union all select total_pengeluaran, jenis_pengeluaran, tanggal_pengeluaran from expense where status_del = 'F' and tanggal_pengeluaran <= str_to_date('{mc_end.SelectionRange.Start.ToShortDateString().Replace('/', '-')}','%d-%m-%Y') and tanggal_pengeluaran >= str_to_date('{mc_start.SelectionRange.Start.ToShortDateString().Replace('/', '-')}','%d-%m-%Y') order by 3;";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt2);

            int COGs = 0;
            int Operate = 0;
            int Other = 0;
            int Total = 0;
            int Profit = 0;
            int Revenue = 0;

            
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                
                if (dt2.Rows[i][1].ToString() == "Profit")
                {
                    Profit += Convert.ToInt32(dt2.Rows[i][0].ToString());
                    Revenue += Convert.ToInt32(dt2.Rows[i][0].ToString());
                }
                if (dt2.Rows[i][1].ToString() == "COGS")
                {
                    COGs += Convert.ToInt32(dt2.Rows[i][0].ToString());
                    Total += Convert.ToInt32(dt2.Rows[i][0].ToString());
                    Profit -= Convert.ToInt32(dt2.Rows[i][0].ToString());
                }
                if (dt2.Rows[i][1].ToString() == "Operational Cost")
                {
                    Operate += Convert.ToInt32(dt2.Rows[i][0].ToString());
                    Total += Convert.ToInt32(dt2.Rows[i][0].ToString());
                    Profit -= Convert.ToInt32(dt2.Rows[i][0].ToString());
                }
                if (dt2.Rows[i][1].ToString() == "Other Cost")
                {
                    Other += Convert.ToInt32(dt2.Rows[i][0].ToString());
                    Total += Convert.ToInt32(dt2.Rows[i][0].ToString());
                    Profit -= Convert.ToInt32(dt2.Rows[i][0].ToString());
                }

                lbl_cog.Text = String.Format(new CultureInfo("id-ID"), "{0:C0},00",COGs);
                lbl_oc.Text = String.Format(new CultureInfo("id-ID"), "{0:C0},00", Operate);
                lbl_ooc.Text = String.Format(new CultureInfo("id-ID"), "{0:C0},00", Other);
                lbl_total_cost.Text = String.Format(new CultureInfo("id-ID"), "{0:C0},00", Total);
                lbl_total_profit.Text = String.Format(new CultureInfo("id-ID"), "{0:C0},00", Profit);
                lbl_rev.Text = String.Format(new CultureInfo("id-ID"), "{0:C0},00", Revenue);
            }
        }
        private void GetSQLDataDate(string datepick)
        {
            dt.Clear();
            mysqlquary = $" select * from htrans where tanggal_transaksi = '{datepick}';";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
        }
        private void GetSQLData()
        {
            dt.Clear();
            mysqlquary = $"select id_nota, harga_total, 'Profit', 'Profit From Sales', tanggal_transaksi from htrans where status_del = 'F' union all select id_pengeluaran, total_pengeluaran, jenis_pengeluaran, nama_pengeluaran ,tanggal_pengeluaran from expense where status_del = 'F' order by 4;";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
        }
        private void GetSQLDataSpecific()
        {
            dt.Clear();
            mysqlquary = $"select id_nota, harga_total, 'Profit', 'Profit From Sales',tanggal_transaksi from htrans where status_del = 'F' and month(tanggal_transaksi) = '{cbox_month.SelectedIndex}' union all select id_pengeluaran, total_pengeluaran, jenis_pengeluaran, nama_pengeluaran ,tanggal_pengeluaran from expense where status_del = 'F' and month(tanggal_pengeluaran) = '{cbox_month.SelectedIndex}' order by 4;";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
        }
        private void GenerateLabel()
        {
            Panel[] panelling = { panel10, panel9, panel8, panel7 };
            Label[] labelcost = { lbl_cost_1, lbl_cost_2, lbl_cost_3, lbl_cost_4 };
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
                labelcost[i].Text = String.Format("Rp.{0:C},00", dt.Rows[i + (page * 4)][1].ToString());
                labeldtl[i].Text = dt.Rows[i + (page * 4)][2].ToString();
                labeldesc[i].Text = dt.Rows[i + (page * 4)][3].ToString();
                labeltgl[i].Text = dt.Rows[i + (page * 4)][4].ToString();
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

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            page--;
            GenerateLabel();
        }

        private void btn_next_Click_1(object sender, EventArgs e)
        {
            page++;
            GenerateLabel();
        }

        private void mc_start_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void mc_end_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            GenerateAllData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetSQLDataDate(dateTimePicker1.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            GenerateLabel();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormRef.GetBill(dt.Rows[0 + (page * 4)][0].ToString());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormRef.GetBill(dt.Rows[1 + (page * 4)][0].ToString());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FormRef.GetBill(dt.Rows[2 + (page * 4)][0].ToString());
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormRef.GetBill(dt.Rows[3 + (page * 4)][0].ToString());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormRef.YearRep();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormRef.StatsRep();
        }
    }
}


// 