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
    public partial class FormSOPV : Form
    {
        public Form1 FormRef { get; set; }
        public FormSOPV()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            FormRef.MainSOP();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
