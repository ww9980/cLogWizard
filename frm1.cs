using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WizardLayout
{
    public partial class frm1 : Form
    {
        public frm1()
        {
            InitializeComponent();
            //plog.ONtimestamp = DateTime.Now.ToString("HH:mm:ss");
        }
        public frm1(ref cLog plog)
        {
            InitializeComponent();
            plog.ONtimestamp = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
