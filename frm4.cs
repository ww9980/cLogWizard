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
    public partial class frm4 : Form
    {
        cLog pntLog;
        public frm4()
        {
            InitializeComponent();
        }
        public frm4(ref cLog plog)
        {
            InitializeComponent();
            pntLog = plog;
            label4.Text = pntLog.user;
        }

        private void frm4_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {

                pntLog.user = Environment.UserName;
                if (rbGood.Checked)
                {
                    pntLog.OFFflagError = false;
                    this.Text = "0";
                }
                else if (rbError.Checked)
                {
                    pntLog.OFFflagError = true;
                    this.Text = "0";
                }
                else
                {
                    MessageBox.Show("Select if there is an error plz");
                    this.Text = "1";
                    return;
                }

                this.Text = "2";

                pntLog.i2c = cbi2c.Checked;


                pntLog.Major = (int)nMajor.Value;
                pntLog.Minor = (int)nMinor.Value;

                pntLog.OFFnote = tbComments.Text;
                pntLog.OFFtimestamp = DateTime.Now.ToString("HH:mm:ss");
                pntLog.totalmin = DateTime.Now.Subtract(Convert.ToDateTime(pntLog.ONtimestamp)).ToString("mm");

                pntLog.writeToFile();
            }
            else
            {
                this.Text = "0";
            }
        }
    }
}
