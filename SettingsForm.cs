using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace olympchecker_gui
{
    public partial class SettingsForm : Form
    {

        private List<CompilerInfo> compilers;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Settings.SetCompilers(compilers);
            Settings.Save();
            this.Close();
        }

        private void SettingsForm_Activated(object sender, EventArgs e)
        {
            compilers = Settings.GetCompilers();

            comboBoxCompilerName.Items.Clear();
            foreach (CompilerInfo compiler in compilers)
            {
                comboBoxCompilerName.Items.Add(compiler.name);
            }
            comboBoxCompilerName.SelectedIndex = 0;
        }


        private void comboBoxCompilerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxCompilerName.Text = compilers[comboBoxCompilerName.SelectedIndex].name;
            textBoxSourceExtensions.Text = compilers[comboBoxCompilerName.SelectedIndex].extensions;
            textBoxCompiler.Text = compilers[comboBoxCompilerName.SelectedIndex].path;
            textBoxCompilerOptions.Text = compilers[comboBoxCompilerName.SelectedIndex].options;

            pictureBox.Image = (File.Exists(compilers[comboBoxCompilerName.SelectedIndex].path) ? Icons.OK : Icons.Error);
        }

        private void buttonAddCompiler_Click(object sender, EventArgs e)
        {
            compilers.Add(new CompilerInfo("", "", "", ""));

            comboBoxCompilerName.Items.Add("Новый");
            comboBoxCompilerName.SelectedIndex = comboBoxCompilerName.Items.Count - 1;
            textBoxCompilerName.Text = textBoxSourceExtensions.Text = textBoxCompiler.Text = textBoxCompilerOptions.Text = "";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            int index = comboBoxCompilerName.SelectedIndex;
            compilers[index].name = textBoxCompilerName.Text;
            compilers[index].extensions = textBoxSourceExtensions.Text;
            compilers[index].path = textBoxCompiler.Text;
            compilers[index].options = textBoxCompilerOptions.Text;
            comboBoxCompilerName.Items[index] = textBoxCompilerName.Text;
        }

        private void buttonDeleteCompiler_Click(object sender, EventArgs e)
        {
            if (comboBoxCompilerName.Items.Count <= 1)
            {
                Utils.Error("Нельзя удалить единственный компилятор");
            }
            else
            {
                comboBoxCompilerName.Items.RemoveAt(comboBoxCompilerName.SelectedIndex);
                compilers.RemoveAt(comboBoxCompilerName.SelectedIndex);
                comboBoxCompilerName.SelectedIndex = 0;
            }
        }
    }
}
