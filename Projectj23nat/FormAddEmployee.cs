using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectj23nat
{
    public partial class FormAddEmployee : Form
    {
        Thread thread;
        string name, nik, salary, birthcity, birthdate, shift, address, role, gender;
        string[] dataset1 = { "Manager", "Waitress", "Kasir", "Staff" };
        string[] dataset2 = { "Morning", "Evening", };
        string[] dataset3 = { "L", "P", };
        public FormAddEmployee()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void openmenu(object obj)
        {
            Application.Run(new FormRegisterAccount(name,gender,role,salary,birthcity,birthdate,nik,shift,address));
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            name = tbox_name.Text;
            nik = tbox_nik.Text;
            salary = tbox_salary.Text;
            birthcity = tbox_city.Text;
            birthdate = dtp.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            role = dataset1[cbox_role.SelectedIndex];
            shift = dataset2[cbox_shift.SelectedIndex];
            gender = dataset3[cbox_gender.SelectedIndex];
            address = tbox_add.Text;

            if (name != "" && nik != "" && salary != "" && birthcity != "" && birthdate != "" && role != "" && shift != "" && gender != "" && address != "" )
            {
                this.Close();
                thread = new Thread(openmenu);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show("Missing Data");
            }

            

        }
    }
}
