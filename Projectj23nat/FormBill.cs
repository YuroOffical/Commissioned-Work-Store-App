using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectj23nat
{
    public partial class FormBill : Form
    {
        string mysqlquary;
        string mysqlconnection = "server=localhost;uid=root;database=afl2sem3";
        int saveslot;
        string meja;
        MySqlConnection myconnection;
        MySqlCommand mycommand;
        MySqlDataAdapter myadapter;
        MySqlDataReader myreader;
        DataTable dt = new DataTable();
        DataTable dtcart = new DataTable();
        public Object Image;

        string[] month = { "All", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        string[] type = { "COGS", "Operational Cost", "Other Cost" };
        int[] qty = { 0, 0, 0, 0, 0 };
        int totalitas = 0;

        string emp, cust, table, idemp;

        int page;
        string id;

        public Form1 FormRef { get; set; }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            FormRef.GetBack();
        }

        public FormBill(string id)
        {
            InitializeComponent();
            this.id = id;
            GenerateSQLData();
            GeneratePanel();
        }
        private void GenerateSQLData()
        {
            dt = new DataTable();
            mysqlquary = $"select * from htrans where id_nota = '{id}';";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);

            dtcart = new DataTable();
            mysqlquary = $"select i.nama_item, d.jumlah_item, d.subtotal from dtrans d , list_item i  where  d.id_item = i.id_item and d.id_nota = '{id}';";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dtcart);
        }
        private void GeneratePanel()
        {
            for (int i = 0; i < dtcart.Rows.Count; i++)
            {
                Label label = new Label();
                label.Text = dtcart.Rows[i][0].ToString() + " x " + dtcart.Rows[i][1].ToString();
                label.Font = new Font("Inter", 10, FontStyle.Regular);
                label.AutoSize = true;
                label.Location = new Point(3, 39 + (i * 20));
                label.Name = "lbl_delthis_name_" + i.ToString();
                panelcost.Controls.Add(label);



                Label label2 = new Label();
                label2.Text = String.Format("Rp.{0:C},00", dtcart.Rows[i][2].ToString());
                label2.Font = new Font("Inter", 10, FontStyle.Regular);
                label2.Location = new Point(160, 39 + (i * 20));
                label2.Name = "lbl_delthis_cost_" + i.ToString();
                panelcost.Controls.Add(label2);
            }
            lbl1.Text = "Date     : " + dt.Rows[0][2].ToString();
            lbl2.Text = "Customer : " + dt.Rows[0][3].ToString();
            lbl3.Text = "Employee : " + dt.Rows[0][4].ToString();
            lbl4.Text = "Table    : " + dt.Rows[0][5].ToString();
            lbl5.Text = "Total    : " + String.Format("Rp.{0:C},00", dt.Rows[0][6].ToString());
        }
    }
}

/*
for (int i = 0; i < dtcart.Rows.Count; i++)
{
    Label label = new Label();
    label.Text = dtcart.Rows[i][4].ToString() + " " + dtcart.Rows[i][1].ToString();
    label.Font = new Font("Inter", 10, FontStyle.Regular);
    label.Location = new Point(3, 39 + (i * 20));
    label.Name = "lbl_delthis_name_" + i.ToString();
    panelcost.Controls.Add(label);

    int cost = int.Parse(dtcart.Rows[i][4].ToString());
    int qtyi = int.Parse(dtcart.Rows[i][3].ToString());


    Label label2 = new Label();
    label2.Text = String.Format("Rp.{0:C},00", (cost * qtyi).ToString());
    label2.Font = new Font("Inter", 10, FontStyle.Regular);
    label2.Location = new Point(160, 39 + (i * 20));
    label2.Name = "lbl_delthis_cost_" + i.ToString();
    panelcost.Controls.Add(label2);

    total = total + (cost * qtyi);
    lbl_total.Text = string.Format("Rp.{0:C},00", total.ToString());
    totalitas = total;
}
*/