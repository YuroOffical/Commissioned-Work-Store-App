using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Projectj23nat
{
    public partial class FormStatistic : Form
    {
        string mysqlquary;
        string mysqlconnection = "server=localhost;uid=root;database=afl2sem3";
        int saveslot;
        MySqlConnection myconnection;
        MySqlCommand mycommand;
        MySqlDataAdapter myadapter;
        MySqlDataReader myreader;
        DataTable dt = new DataTable();
        public FormStatistic()
        {
            InitializeComponent();
            GetSQLData("");
            generatechart(); generatedgv();
        }
        private void GetSQLData(string thing)
        {
            dt.Clear();
            mysqlquary = $"select i.nama_item as 'Item', sum(d.jumlah_item) as 'Total Sold', sum(d.subtotal) as 'Total Revenue From Item' from dtrans d , list_item i  where  d.id_item = i.id_item {thing} group by i.nama_item order by d.jumlah_item desc;";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
        }
        private void generatedgv()
        {
            dgv.DataSource = dt;
            dgv.Font = new Font("Inter", 15,FontStyle.Regular);
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void generatechart()
        {
            bigchart.DataSource = dt;
            DataTable dtPieChartData = new DataTable();
            dtPieChartData.Columns.Add("Month");
            dtPieChartData.Columns.Add("Total");

            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                string name = "";
                int qty = 0;
                bool none = true;
                /*
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (i.ToString() == dt.Rows[j][1].ToString())
                    {
                        name = dt.Rows[j][1].ToString();
                        qty = int.Parse(dt.Rows[j][2].ToString());
                        none = false;
                        break;
                    }
                }
                if (none)
                {
                    name = i.ToString();
                    qty = 0;
                }
                */
                name = dt.Rows[i-1][0].ToString();
                qty = int.Parse(dt.Rows[i-1][1].ToString());
                dtPieChartData.Rows.Add(name, qty);
            }
            bigchart.DataSource = dtPieChartData;
            bigchart.Series["Series1"].XValueMember = "Month";
            bigchart.Series["Series1"].YValueMembers = "Total";
            bigchart.Series["Series1"].ChartType = SeriesChartType.Pie;
            bigchart.Series["Series1"].IsValueShownAsLabel = true;
            bigchart.ChartAreas["ChartArea1"].Area3DStyle.Rotation = -90;

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string a = "and i.jenis_item = 'Makanan'";
            string b = "and i.jenis_item = 'Minuman'";
            string c = "and i.jenis_item = 'Snack'";
            string[] thingy = { "",a,b,c };
            GetSQLData(thingy[comboBox1.SelectedIndex]);
            generatechart();
            generatedgv();
        }
    }
}

