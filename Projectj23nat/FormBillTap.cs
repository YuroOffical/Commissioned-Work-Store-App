using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace Projectj23nat
{
    public partial class FormBillTap : Form
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

        string emp, cust, table, idemp, currentthing;

        int page;

        private void updatestatus(string updateinto, string id)
        {
            myconnection.Open();
            mysqlquary = $" update htrans set status_Del = '{updateinto}' where id_nota = '{id}' ";
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myreader = mycommand.ExecuteReader();
            myconnection.Close();

            GetSQLData();
            GenerateLabel("all");
        }

        private void btn_del_1_Click(object sender, EventArgs e)
        {
            updatestatus("T", dt.Rows[0+(page * 5)][0].ToString());
        }

        private void btn_del_2_Click(object sender, EventArgs e)
        {
            updatestatus("T", dt.Rows[1 + (page * 5)][0].ToString());
        }

        private void btn_del_3_Click(object sender, EventArgs e)
        {
            updatestatus("T", dt.Rows[2 + (page * 5)][0].ToString());
        }

        private void btn_del_4_Click(object sender, EventArgs e)
        {
            updatestatus("T", dt.Rows[3 + (page * 5)][0].ToString());
        }

        private void btn_del_5_Click(object sender, EventArgs e)
        {
            updatestatus("T", dt.Rows[4 + (page * 5)][0].ToString());
        }

        private void lbl_done_1_Click(object sender, EventArgs e)
        {
            updatestatus("F", dt.Rows[0 + (page * 5)][0].ToString());
        }

        private void lbl_done_2_Click(object sender, EventArgs e)
        {
            updatestatus("F", dt.Rows[1 + (page * 5)][0].ToString());
        }

        private void lbl_done_3_Click(object sender, EventArgs e)
        {
            updatestatus("F", dt.Rows[2 + (page * 5)][0].ToString());
        }

        private void lbl_done_4_Click(object sender, EventArgs e)
        {
            updatestatus("F", dt.Rows[3 + (page * 5)][0].ToString());
        }

        private void lbl_done_5_Click(object sender, EventArgs e)
        {
            updatestatus("F", dt.Rows[4 + (page * 5)][0].ToString());
        }

        public Form1 FormRef { get; set; }
        public FormBillTap()
        {
            InitializeComponent();
            page = 0;
            currentthing = "";
            GetSQLData();
            GenerateLabel("all");
        }
        private void GetSQLData()
        {
            qty[0] = 0;
            qty[1] = 0;
            qty[2] = 0;
            qty[3] = 0;
            qty[4] = 0;

            dt = new DataTable();
            dt.Clear();
            mysqlquary = $"select * from htrans where status_del = 'P'";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
        }
        private void GenerateLabel(string check)
        {
            Panel[] panelling = { panel1, panel2, panel3, panel4, panel5 };
            Label[] labelnama = { lbl_cost_1, lbl_cost_2, lbl_cost_3 , lbl_cost_4 , lbl_cost_5 };
            Label[] lblmakan = { lbl_dtl_1, lbl_dtl_2, lbl_dtl_3, lbl_dtl_4, lbl_dtl_5 };
            Label[] lblminum = { lbl_desc_1, lbl_desc_2, lbl_desc_3, lbl_desc_4, lbl_desc_5 };
            Label[] lblsnack = { lbl_snk_1, lbl_snk_2, lbl_snk_3, lbl_snk_4, lbl_snk_5};
            Label[] lbltgl = { lbl_tgl_1, lbl_tgl_2, lbl_tgl_3, lbl_tgl_4, lbl_tgl_5 };

            
             
            


            List<int> pagelist = new List<int>();

            if (check == "just")
            {

            }
            else
            {
                foreach (Panel panel in panelling)
                {
                    panel.Visible = false;
                }
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
                    pagelist.Add(5);
                }
            }

            //MessageBox.Show(pagelist[page].ToString());

            for (int i = 0; i < pagelist[page]; i++)
            {
                panelling[i].Visible = true;
                labelnama[i].Text = $"Table {dt.Rows[i][5].ToString()} - {dt.Rows[i][3].ToString()}";
                lbltgl[i].Text = dt.Rows[i][2].ToString();

                lblmakan[i].Text = "";
                lblminum[i].Text = "";
                lblsnack[i].Text = "";

                DataTable dtdorder = new DataTable();
                dtdorder.Clear();
                mysqlquary = $"select i.jenis_item , i.nama_item, d.jumlah_item from dtrans d, list_item i where d.id_item = i.id_item and d.id_nota = '{dt.Rows[i][0].ToString()}'";
                myconnection = new MySqlConnection(mysqlconnection);
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myadapter = new MySqlDataAdapter(mycommand);
                myadapter.Fill(dtdorder);

                

                List<string> list = new List<string>();
                List<string> list2 = new List<string>();
                List<string> list3 = new List<string>();

                for (int j = 0; j < dtdorder.Rows.Count; j++)
                {
                    if (dtdorder.Rows[j][0].ToString() == "Makanan")
                    {
                        list.Add(dtdorder.Rows[j][1].ToString() + " x " + dtdorder.Rows[j][2].ToString());
                    }
                    else if (dtdorder.Rows[j][0].ToString() == "Minuman")
                    {
                        list2.Add(dtdorder.Rows[j][1].ToString() + " x " + dtdorder.Rows[j][2].ToString());
                    }
                    else
                    {
                        list3.Add(dtdorder.Rows[j][1].ToString() + " x " + dtdorder.Rows[j][2].ToString());
                    }
                }

                for (int j = 1; j <= list.Count; j++)
                {
                    lblmakan[i].Text = lblmakan[i].Text + list[j-1];
                    if (list.Count != j)
                    {
                        lblmakan[i].Text = lblmakan[i].Text + ", ";
                    }
                }
                for (int j = 1; j <= list2.Count; j++)
                {
                    lblminum[i].Text = lblminum[i].Text + list2[j - 1];
                    if (list.Count != j)
                    {
                        lblminum[i].Text = lblminum[i].Text + ", ";
                    }
                }
                for (int j = 1; j <= list3.Count; j++)
                {
                    lblsnack[i].Text = lblsnack[i].Text + list3[j - 1];
                    if (list.Count != j)
                    {
                        lblsnack[i].Text = lblsnack[i].Text + ", ";
                    }
                }

                if (list.Count == 0)
                {
                    lblmakan[i].Text = "-";
                }
                if (list2.Count == 0)
                {

                    lblminum[i].Text = "-";
                }
                if (list3.Count == 0)
                {
                    lblsnack[i].Text = "-";
                }

            }
        }

    }
}
