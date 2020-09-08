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
    public partial class frmParent : Form
    {
        public static cLog log = new cLog();
        Form[] frm = { new frm1(), new frm1(ref log), new frm2(), new frm3(), new frm4(ref log), new frm5() };
        int top = 0;
        int last = -1;
        int count;


        public frmParent()
        {
            count = frm.Count();
            InitializeComponent();
        }
        private void LoadNewForm()
        {
            frm[top].TopLevel = false;
            frm[top].AutoScroll = true;
            frm[top].Dock = DockStyle.Fill;
            this.pnlContent.Controls.Clear();
            this.pnlContent.Controls.Add(frm[top]);

            if (last >= 0)
            { 
                frm[last].Hide();
                if (frm[last].Text == "1")
                {
                    frm[last].Show();
                    last--;
                    top--;
                    return;
                }
            }
            frm[top].Show();
        }

        private void Back()
        {
            last = top;
            top--;

            if (top <= 0)
            {
                return;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                LoadNewForm();
                if (top - 1 <= 0)
                {
                    btnBack.Enabled = false;
                }
            }

            if (top >= count + 1)
            {
                btnNext.Enabled = false;
            }
        }
        private void Next()
        {

            if (frm[top].Text == "0")
            {
                frm[top].Hide();
                if (frm[top].Text == "1")
                {
                    frm[top].Show();
                    return;
                }
            }


            last = top;
            top++;

            if (top == count -1)
            {
                btnCancel.Text = "&Finish";
            }
            else
            {
                btnCancel.Text = "&Cancel";
            }

            if (top >= count+1)
            {
                return;
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                LoadNewForm();
                if (top + 1 == count)
                {
                    btnNext.Enabled = false;
                }
                if (top == 2 && last == 1)
                {
                    btnNext.Enabled = false;
                    timer1min.Enabled = true;
                }
            }

            if (top <= 1)
            {
                btnBack.Enabled = false;
            }
        }

        private void frmParent_Load(object sender, EventArgs e)
        {
            Next();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "&Cancel")
            {
                DialogResult dialogResult = MessageBox.Show("Sure to quit? Doing so will log you off this PC. ", "Sure to quit? ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    //this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                // finish
            }

        }

        private void timer1min_Tick(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            timer1min.Enabled = false;
        }
    }
}
