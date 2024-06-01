using MySql.Data.MySqlClient;
using Projectj23nat.Properties;
using Sales_and_Finance_Application.Aesthetic;
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
    public partial class FormItemMastery : Form
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
        Object Image;

        string[] month = { "All", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        string[] type = { "COGS", "Operational Cost", "Other Cost" };
        int[] qty = { 0, 0, 0, 0, 0 };
        int totalitas = 0;

        string emp, cust, table, idemp, currentthing;

        int page;
        public Form1 FormRef { get; set; }
        public FormItemMastery()
        {
            InitializeComponent();
            page = 0;
            currentthing = "Makanan";
            GetSQLData(currentthing);
            GenerateLabel("all");

            dtcart.Columns.Add("id");
            dtcart.Columns.Add("name");
            dtcart.Columns.Add("cost");
            dtcart.Columns.Add("type");
            dtcart.Columns.Add("qty");
        }
        private void GetSQLData(string type)
        {
            qty[0] = 0;
            qty[1] = 0;
            qty[2] = 0;
            qty[3] = 0;
            qty[4] = 0;
            
            dt = new DataTable();
            dt.Clear();
            mysqlquary = $"select * from list_item where jenis_item = '{type}';";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
            dt.Columns.Add("qty");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][4] = 0;
            }
        }

        

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            page = 0;
            currentthing = "Makanan";
            GetSQLData(currentthing);
            GenerateLabel("all");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            page = 0;
            currentthing = "Minuman";
            GetSQLData(currentthing);
            GenerateLabel("all");
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            page = 0;
            currentthing = "Snack";
            GetSQLData(currentthing);
            GenerateLabel("all");
        }
        private void GenerateNewData(int val, int id)
        {
            
            myconnection.Open();
            mysqlquary = $"update list_item set harga_item = {val} where id_item = '{dt.Rows[(id-1) + (page * 5)][0].ToString()}' ;";
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myreader = mycommand.ExecuteReader();
            myconnection.Close();
        }
        private void btn_plus_1_Click(object sender, EventArgs e)
        {
            int qty1 = int.Parse(dt.Rows[0 + (page * 5)][3].ToString());
            qty1 += 1000;
            GenerateNewData(qty1, 1);
            GetSQLData(currentthing);
            GenerateLabel("just");
        }

        private void btn_plus_2_Click(object sender, EventArgs e)
        {
            int qty2 = int.Parse(dt.Rows[1 + (page * 5)][3].ToString());
            qty2 += 1000;
            GenerateNewData(qty2, 2);
            GetSQLData(currentthing);
            GenerateLabel("just");
        }

        private void btn_minus_2_Click(object sender, EventArgs e)
        {
            int qty2 = int.Parse(dt.Rows[1 + (page * 5)][3].ToString());
            qty2 -= 1000;
            if (qty2 < 0)
            {
                qty2 = 0;
            }
            GenerateNewData(qty2, 2);
            GetSQLData(currentthing);
            GenerateLabel("just");
        }

        private void btn_plus_3_Click(object sender, EventArgs e)
        {
            int qty3 = int.Parse(dt.Rows[2 + (page * 5)][3].ToString());
            qty3 += 1000;
            GenerateNewData(qty3, 3);
            GetSQLData(currentthing);
            GenerateLabel("just");
        }

        private void btn_minus_3_Click(object sender, EventArgs e)
        {
            int qty3 = int.Parse(dt.Rows[2 + (page * 5)][3].ToString());
            qty3 -= 1000;
            if (qty3 < 0)
            {
                qty3 = 0;
            }
            GenerateNewData(qty3, 3);
            GetSQLData(currentthing);
            GenerateLabel("just");
        }

        private void btn_plus_4_Click(object sender, EventArgs e)
        {
            int qty4 = int.Parse(dt.Rows[3 + (page * 5)][3].ToString());
            qty4 += 1000;
            GenerateNewData(qty4, 4);
            GetSQLData(currentthing);
            GenerateLabel("just");
        }

        private void btn_minus_4_Click(object sender, EventArgs e)
        {
            int qty4 = int.Parse(dt.Rows[3 + (page * 5)][3].ToString());
            qty4 -= 1000;
            if (qty4 < 0)
            {
                qty4 = 0;
            }
            GenerateNewData(qty4, 4);
            GetSQLData(currentthing);
            GenerateLabel("just");
        }

        private void btn_plus_5_Click(object sender, EventArgs e)
        {
            int qty5 = int.Parse(dt.Rows[4 + (page * 5)][3].ToString());
            qty5 += 1000;
            GenerateNewData(qty5, 5);
            GetSQLData(currentthing);
            GenerateLabel("just");
        }

        private void btn_minus_5_Click(object sender, EventArgs e)
        {
            int qty5 = int.Parse(dt.Rows[4 + (page * 5)][3].ToString());
            qty5 -= 1000;
            if (qty5 < 0)
            {
                qty5 = 0;
            }
            GenerateNewData(qty5, 5);
            GetSQLData(currentthing);
            GenerateLabel("just");
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string[] dataset = { "Makanan", "Minuman", "Snack" };
            if (tbox_name.Text != "" && tbox_cost.Text != "" && cbox_type.SelectedIndex != -1)
            {
                myconnection.Open();
                mysqlquary = $"insert into LIST_ITEM ( nama_item, jenis_item, harga_item)  values (  '{tbox_name.Text}', '{dataset[cbox_type.SelectedIndex]}', '{tbox_cost.Text}');";
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myreader = mycommand.ExecuteReader();
                myconnection.Close();
            }

            
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            page++;
            GenerateLabel("all");
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            page--;
            if (page < 0)
            {
                page = 0;
            }
            GenerateLabel("all");
        }
        private void statuschange(string iditem)
        {
            myconnection.Open();
            mysqlquary = $"update list_item set jenis_item = 'Deleted' where id_item = '{iditem}'";
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myreader = mycommand.ExecuteReader();
            myconnection.Close();

            GetSQLData(currentthing);
            GenerateLabel("all");
        }
        

        private void btn_del_1_Click(object sender, EventArgs e)
        {
            statuschange(dt.Rows[0 + (page * 5)][0].ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            statuschange(dt.Rows[1 + (page * 5)][0].ToString());

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            statuschange(dt.Rows[2 + (page * 5)][0].ToString());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            statuschange(dt.Rows[3 + (page * 5)][0].ToString());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            statuschange(dt.Rows[4 + (page * 5)][0].ToString());
        }

        private void btn_minus_1_Click(object sender, EventArgs e)
        {
            int qty1 = int.Parse(dt.Rows[0 + (page * 5)][3].ToString());
            qty1 -= 1000;
            if (qty1 < 0)
            {
                qty1 = 0;
            }
            GenerateNewData(qty1, 1);
            GetSQLData(currentthing);
            GenerateLabel("just");
        }

        private void DeleteMemory()
        {
            qty[0] = 0;
            qty[1] = 0;
            qty[2] = 0;
            qty[3] = 0;
            qty[4] = 0;
        }
        private void DeleteQuantity()
        {

            if (dt.Rows.Count % 5 == 1)
            {
                lbl_qty_1.Text = dt.Rows[0 + (page * 5)][4].ToString();
            }
            if (dt.Rows.Count % 5 == 2)
            {
                lbl_qty_1.Text = dt.Rows[0 + (page * 5)][4].ToString();
                lbl_qty_2.Text = dt.Rows[1 + (page * 5)][4].ToString();
            }
            if (dt.Rows.Count % 5 == 3)
            {
                lbl_qty_1.Text = dt.Rows[0 + (page * 5)][4].ToString();
                lbl_qty_2.Text = dt.Rows[1 + (page * 5)][4].ToString();
                lbl_qty_3.Text = dt.Rows[2 + (page * 5)][4].ToString();
            }
            if (dt.Rows.Count % 5 == 4)
            {
                lbl_qty_1.Text = dt.Rows[0 + (page * 5)][4].ToString();
                lbl_qty_2.Text = dt.Rows[1 + (page * 5)][4].ToString();
                lbl_qty_3.Text = dt.Rows[2 + (page * 5)][4].ToString();
                lbl_qty_4.Text = dt.Rows[3 + (page * 5)][4].ToString();
            }
            if (dt.Rows.Count % 5 == 0)
            {
                lbl_qty_1.Text = dt.Rows[0 + (page * 5)][4].ToString();
                lbl_qty_2.Text = dt.Rows[1 + (page * 5)][4].ToString();
                lbl_qty_3.Text = dt.Rows[2 + (page * 5)][4].ToString();
                lbl_qty_4.Text = dt.Rows[3 + (page * 5)][4].ToString();
                lbl_qty_5.Text = dt.Rows[4 + (page * 5)][4].ToString();
            }
        }
        private void GenerateLabel(string check)
        {
            DeleteQuantity();
            Panel[] panelling = { panel2, panel4, panel6, panel8, panel10 };
            Label[] labelnama = { lbl_nama_1, lbl_nama_2, lbl_nama_3, lbl_nama_4, lbl_nama_5 };
            Label[] labelcost = { lbl_qty_1, lbl_qty_2, lbl_qty_3, lbl_qty_4, lbl_qty_5 };
            REPictureBox[] pbox = { rePictureBox1, rePictureBox2, rePictureBox3, rePictureBox4, rePictureBox5 };

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
                labelcost[i].Text = dt.Rows[i + (page * 5)][3].ToString();
                labelnama[i].Text = dt.Rows[i + (page * 5)][1].ToString();

                try
                {
                    Image = Resources.ResourceManager.GetObject(dt.Rows[i + (page * 5)][1].ToString());
                    pbox[i].Image = (Image)Image;
                }
                catch (Exception e)
                {
                    Image = Resources.ResourceManager.GetObject("No_Image_Placeholder_svg");
                    pbox[i].Image = (Image)Image;
                }
            }
        }
    }
}
