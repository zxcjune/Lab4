using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVLib;

namespace Lab3
{
    public partial class fTV : Form
    {
        public TV Tv = new TV();
        public fTV(TV tv)
        {
            Tv = tv;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Tv.Model = tbModel.Text.Trim();
            Tv.Display = tbDisplay.Text.Trim();
            Tv.Cores = int.Parse(tbCores.Text.Trim());
            Tv.Resolution = tbResolution.Text.Trim();
            Tv.Platform = tbPlatform.Text.Trim();
            Tv.HasTuner = chbTuner.Checked;
            Tv.HasAI = chbAI.Checked;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void fPhone_Load(object sender, EventArgs e)
        {
            if (Tv != null)
            {
                tbModel.Text = Tv.Model;
                tbDisplay.Text = Tv.Display;
                tbCores.Text = Tv.Cores.ToString();
                tbResolution.Text = Tv.Resolution;
                tbPlatform.Text = Tv.Platform;
                chbTuner.Checked = Tv.HasTuner;
                chbAI.Checked = Tv.HasAI;
            }

        }
    }
}
