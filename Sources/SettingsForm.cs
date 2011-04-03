using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace olympchecker_gui
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            comboLanguage.Text = SettingsManager.Language;
            cbAutoSave.Checked = SettingsManager.AutoSaveState;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SettingsManager.Language = comboLanguage.Text;
            SettingsManager.AutoSaveState = cbAutoSave.Checked;
            SettingsManager.Save();

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
