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
    public partial class FormItemMaster : Form
    {
        public FormItemMaster()
        {
            InitializeComponent();
        }
        public Form1 FormRef { get; set; }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormRef.GetEmployeTab();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormRef.GetItemMaster();
        }
    }
}
