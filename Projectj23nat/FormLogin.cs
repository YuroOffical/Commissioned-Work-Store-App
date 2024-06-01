using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectj23nat
{
    public partial class FormLogin : Form
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

        Thread thread;
        List<string> listofusers = new List<string>();
        List<string> listofpassword = new List<string>();

        string name, pass;
        public FormLogin()
        {
            InitializeComponent();
            GetSQLData();
        }
        private void GetSQLData()
        {
            dt.Clear();
            mysqlquary = $"select * from userdata;";
            myconnection = new MySqlConnection(mysqlconnection);
            mycommand = new MySqlCommand(mysqlquary, myconnection);
            myadapter = new MySqlDataAdapter(mycommand);
            myadapter.Fill(dt);

            for(int i = 0;i < dt.Rows.Count; i++)
            {
                listofusers.Add(dt.Rows[i][0].ToString());
                listofpassword.Add(dt.Rows[i][1].ToString());
            }
        }
        private void openmenu(object obj)
        {
            Application.Run(new Form1(name+","+pass));
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            this.name = tbox_1.Text;
            this.pass = tbox_2.Text;
            if (tbox_1.Text != "" && tbox_2.Text != "")
            {
                if (listofusers.Contains(tbox_1.Text))
                {
                    if (listofpassword.Contains(tbox_2.Text))
                    {
                        this.Close();
                        thread = new Thread(openmenu);
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password");
                    }
                }
                else
                {
                    MessageBox.Show("Unknown Username");
                }
            }
            else
            {
                MessageBox.Show("Input Error");
            }
        }
    }
}
