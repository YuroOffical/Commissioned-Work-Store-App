using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectj23nat
{
    public partial class FormRegister : Component
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        public FormRegister(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
