﻿using System;
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
    public partial class FormSOPIII : Form
    {
        public Form1 FormRef { get; set; }
        public FormSOPIII()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            FormRef.MainSOP();
        }
    }
}