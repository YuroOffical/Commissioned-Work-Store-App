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
    public partial class FormSOP : Form
    {
        public FormSOP()
        {
            InitializeComponent();
        }
        public Form1 FormRef { get; set; }  

        private void btn_submit_Click(object sender, EventArgs e)
        {
            FormRef.SOPII();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormRef.SOPIII();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FormRef.SOPIV();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormRef.SOPV();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            FormRef.SOPVI();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            FormRef.SOPVII();
        }
    }
}
