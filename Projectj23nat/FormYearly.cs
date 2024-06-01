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
using System.Windows.Forms.DataVisualization.Charting;

namespace Projectj23nat
{
    public partial class FormYearly : Form
    {
        string mysqlquary;
        string mysqlconnection = "server=localhost;uid=root;database=afl2sem3";
        int saveslot;
        MySqlConnection myconnection;
        MySqlCommand mycommand;
        MySqlDataAdapter myadapter;
        MySqlDataReader myreader;
        DataTable dt = new DataTable();
        public FormYearly()
        {
            InitializeComponent();
            GetSQLData();
            generatechart();
        }
        private void GetSQLData()
        {
            dt.Clear();
            mysqlquary = $"select tanggal_transaksi, month(tanggal_transaksi), ifnull(sum(harga_total),0) from htrans group by month(tanggal_transaksi);";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
        }
        private void generatechart()
        {
            bigchart.DataSource = dt;
            DataTable dtPieChartData = new DataTable();
            dtPieChartData.Columns.Add("Month");
            dtPieChartData.Columns.Add("Total");

            for (int i = 1; i <= 12; i++)
            {
                string name = "";
                int qty = 0;
                bool none = true;
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
                dtPieChartData.Rows.Add(name, qty);
            }
            bigchart.DataSource = dtPieChartData;
            bigchart.Series["Series1"].XValueMember = "Month";
            bigchart.Series["Series1"].YValueMembers = "Total";
            this.bigchart.Titles.Add("");
            bigchart.Series["Series1"].ChartType = SeriesChartType.Area;
            bigchart.Series["Series1"].IsValueShownAsLabel = false;
            bigchart.ChartAreas["ChartArea1"].Area3DStyle.Rotation = -90;
            
        }
    }
}
