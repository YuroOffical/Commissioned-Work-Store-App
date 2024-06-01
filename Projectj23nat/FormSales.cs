using MySql.Data.MySqlClient;
using Projectj23nat.Properties;
using Sales_and_Finance_Application.Aesthetic;
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
using static System.Net.WebRequestMethods;

namespace Projectj23nat
{
    public partial class FormSales : Form
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

        string emp,cust,table,idemp;

        int page;
        public FormSales()
        {
            InitializeComponent();
            page = 0;
            GetSQLData("Makanan");
            GenerateLabel();

            dtcart.Columns.Add("id");
            dtcart.Columns.Add("name");
            dtcart.Columns.Add("cost");
            dtcart.Columns.Add("type");
            dtcart.Columns.Add("qty");
        }
        public Form1 FormRef { get; set; }
        private void GetSQLData(string type)
        {
            qty[0] = 0;
            qty[1] = 0;
            qty[2] = 0;
            qty[3] = 0;
            qty[4] = 0;
            dt = new DataTable();
            mysqlquary = $"select * from list_item where jenis_item = '{type}';";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);
            dt.Columns.Add("qty");

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][4] = 0;
            }
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
            // Error when displaying;
            
            if (page == dt.Rows.Count / 5)
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
                    
                }
            }
            else
            {
                lbl_qty_1.Text = dt.Rows[0 + (page * 5)][4].ToString();
                lbl_qty_2.Text = dt.Rows[1 + (page * 5)][4].ToString();
                lbl_qty_3.Text = dt.Rows[2 + (page * 5)][4].ToString();
                lbl_qty_4.Text = dt.Rows[3 + (page * 5)][4].ToString();
                lbl_qty_5.Text = dt.Rows[4 + (page * 5)][4].ToString();
            }
        }
        private void GenerateLabel()
        {
            DeleteQuantity();
            Panel[] panelling = { panel2, panel4, panel6, panel8, panel10 };
            Label[] labelnama = { lbl_nama_1, lbl_nama_2, lbl_nama_3, lbl_nama_4, lbl_nama_5 };
            Label[] labelcost = { lbl_cost_1, lbl_cost_2, lbl_cost_3, lbl_cost_4 ,lbl_cost_5};
            Label[] labelqty = { lbl_qty_1, lbl_qty_2, lbl_qty_3, lbl_qty_4, lbl_qty_5 };
            REPictureBox[] pbox = { rePictureBox1,rePictureBox2,rePictureBox3,rePictureBox4,rePictureBox5};

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
            else if (page == theLimitofPage-1 && dt.Rows.Count % 5 == 0)
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
                labelcost[i].Text = String.Format("Rp.{0:C},00", dt.Rows[i + (page * 5)][3].ToString());
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            page = 0;
            GetSQLData("Makanan");
            GenerateLabel();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            page = 0;
            GetSQLData("Minuman");
            GenerateLabel();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            page = 0;
            GetSQLData("Snack");
            GenerateLabel();
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

        private void btn_minus_1_Click(object sender, EventArgs e)
        {
            qty[0]--;
            if (qty[0] < 0)
            {
                qty[0] = 0;
            }
            dt.Rows[0][4] = qty[0];
            DeleteQuantity();

        }

        private void btn_plus_1_Click(object sender, EventArgs e)
        {
            qty[0]++;
            dt.Rows[0][4] = qty[0];
            DeleteQuantity();
        }

        private void btn_minus_2_Click(object sender, EventArgs e)
        {
            qty[1]--;
            if (qty[1] < 0)
            {
                qty[1] = 0;
            }
            dt.Rows[1][4] = qty[1];
            DeleteQuantity();
        }

        private void btn_plus_2_Click(object sender, EventArgs e)
        {
            qty[1]++;
            dt.Rows[1][4] = qty[1];
            DeleteQuantity();
        }

        private void btn_minus_3_Click(object sender, EventArgs e)
        {
            qty[2]--;
            if (qty[2] < 0)
            {
                qty[2] = 0;
            }
            dt.Rows[2][4] = qty[2];
            DeleteQuantity();
        }

        private void btn_plus_3_Click(object sender, EventArgs e)
        {
            qty[2]++;
            dt.Rows[2][4] = qty[2];
            DeleteQuantity();
        }

        private void btn_minus_4_Click(object sender, EventArgs e)
        {
            qty[3]--;
            if (qty[3] < 0)
            {
                qty[3] = 0;
            }
            dt.Rows[3][4] = qty[3];
            DeleteQuantity();
        }

        private void btn_plus_4_Click(object sender, EventArgs e)
        {
            qty[3]++;
            dt.Rows[3][4] = qty[3];
            DeleteQuantity();
        }

        private void btn_minus_5_Click(object sender, EventArgs e)
        {
            qty[4]--;
            if (qty[4] < 0)
            {
                qty[4] = 0;
            }
            dt.Rows[4][4] = qty[4];
            DeleteQuantity();
        }

        private void btn_plus_5_Click(object sender, EventArgs e)
        {
            qty[4]++;
            dt.Rows[4][4] = qty[4];
            DeleteQuantity();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i][4].ToString()) > 0)
                {
                    string check = "false";
                    string ID = "";
                    for (int j = 0; j < dtcart.Rows.Count; j++)
                    {
                        if (dtcart.Rows[j][0].ToString() == dt.Rows[i][0].ToString())
                        {
                            int qtyadd = int.Parse(dt.Rows[i][4].ToString());
                            int qtyold = int.Parse(dtcart.Rows[j][4].ToString());
                            dtcart.Rows[j][4] = qtyadd + qtyold;
                            check = "true";
                            break;
                        }
                    }

                    if (check == "true")
                    {

                    }
                    else
                    {
                        dtcart.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString());
                    }
                }
                dt.Rows[i][4] = 0;
            }

            int total = 0;

            foreach(Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }

            for (int i = 0;i < dtcart.Rows.Count; i++)
            {
                Label label = new Label();
                label.Text = dtcart.Rows[i][4].ToString() + " "+ dtcart.Rows[i][1].ToString();
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
            DeleteMemory();
            DeleteQuantity();
        }

        private void btn_del_1_Click(object sender, EventArgs e)
        {
            dtcart.Clear();
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            int total = 0;
            lbl_total.Text = string.Format("Rp.{0:C},00", total.ToString());
            totalitas = total;
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            FormConfirmBill form = new FormConfirmBill();
            form.FormRef = this;
            form.ShowDialog();
        }

        private void btn_receipt_Click(object sender, EventArgs e)
        {
            FormRef.GetBilLTab();
            FormRef.ViewBillTab();
        }

        public void CreateBill(string name, string emp, string table, string idemp)
        {
            lbl_tbl.Text = table;
            lbl_cust.Text = name;
            lbl_em.Text = emp;
            this.emp = emp;
            this.table = table;
            this.idemp = idemp;
            this.cust = name;
            this.meja = table;
        }

        private void FormSales_Load(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dtcart.Rows.Count != 0 && lbl_cust.Text != "")
            {
                myconnection.Open();
                mysqlquary = $" insert into HTRANS (id_karyawan, tanggal_transaksi, nama_customer, nama_pegawai, meja_customer, harga_total, status_del) values ('{idemp}', DATE_FORMAT(NOW(), '%Y-%m-%d') , '{cust}', '{emp}','{meja}', '{totalitas}','P'); ;";
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myreader = mycommand.ExecuteReader();
                myconnection.Close();

                DataTable dtlaster = new DataTable();
                mysqlquary = $"select id_nota from htrans order by tanggal_transaksi desc limit 1;";
                myconnection = new MySqlConnection(mysqlconnection);
                mycommand = new MySqlCommand(mysqlquary, myconnection);
                myadapter = new MySqlDataAdapter(mycommand);
                myadapter.Fill(dtlaster);

                for (int i = 0;i < dtcart.Rows.Count; i++)
                {
                    int cost = int.Parse(dtcart.Rows[i][3].ToString());
                    int qtyi = int.Parse(dtcart.Rows[i][4].ToString());

                    myconnection.Open();
                    mysqlquary = $"insert into DTRANS ( id_nota, id_item, harga_item, jumlah_item, subtotal) value ( '{dtlaster.Rows[0][0].ToString()}' , '{dtcart.Rows[i][0].ToString()}', '{cost}', '{qtyi}', '{cost*qtyi}');";
                    mycommand = new MySqlCommand(mysqlquary, myconnection);
                    myreader = mycommand.ExecuteReader();
                    myconnection.Close();
                }
            }

            dtcart.Clear();
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }

            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            foreach (Label label in panelcost.Controls.OfType<Label>())
            {
                if (label.Name.Contains("delthis"))
                {
                    panelcost.Controls.Remove(label);
                }
            }
            int total = 0;
            lbl_total.Text = string.Format("Rp.{0:C},00", total.ToString());
            lbl_cust.Text = "-";
            lbl_em.Text = "-";
            totalitas = total;
        }
    }
}

