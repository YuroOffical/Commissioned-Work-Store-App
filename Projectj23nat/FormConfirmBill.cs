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
    public partial class FormConfirmBill : Form
    {
        string mysqlquary;
        string mysqlconnection = "server=localhost;uid=root;database=afl2sem3";
        int saveslot;
        MySqlConnection myconnection;
        MySqlCommand mycommand;
        MySqlDataAdapter myadapter;
        MySqlDataReader myreader;
        DataTable dt = new DataTable();
        public FormConfirmBill()
        {
            InitializeComponent();
            GenerateSQLData();
        }
        public FormSales FormRef { get; set; }

        private void GenerateSQLData()
        {
            dt.Clear();
            mysqlquary = "select id_karyawan,nama_lengkap from Karyawan";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);

            cbox_type.DataSource = dt;
            cbox_type.DisplayMember = "nama_lengkap";
            cbox_type.ValueMember = "id_karyawan";

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string table = "";
            if (tbox_tbl.Text != "" && tbox_name.Text != "")
            {
                if (tbox_tbl.Text.Length == 1)
                {
                    table = tbox_tbl.Text;
                }
                else
                {
                    table = tbox_tbl.Text;
                }
                MessageBox.Show("Bill as been Created");
                FormRef.CreateBill(tbox_name.Text, dt.Rows[cbox_type.SelectedIndex][1].ToString(), table, cbox_type.SelectedValue.ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Input");
            }

        }

        private void tbox_tbl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbox_tbl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
