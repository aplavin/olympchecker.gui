using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace olympchecker_gui
{
    public partial class SettingsForm : Form
    {

        private List<Compiler> compilers;

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
            Settings.compilers = compilers;
            Settings.Save();
            this.Close();
        }

        private void SettingsForm_Activated(object sender, EventArgs e)
        {
            compilers = Settings.compilers;

            comboBoxCompilerName.Items.Clear();
            comboBoxCompilerName.Items.AddRange(
                (from comp in compilers
                 select comp.name)
                .ToArray()
            );

            comboBoxCompilerName.SelectedIndex = 0;
        }


        private void comboBoxCompilerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxCompilerName.Text = compilers[comboBoxCompilerName.SelectedIndex].name;
            textBoxSourceExtensions.Text = compilers[comboBoxCompilerName.SelectedIndex].extensions;
            textBoxCompiler.Text = compilers[comboBoxCompilerName.SelectedIndex].path;
            textBoxCompilerOptions.Text = compilers[comboBoxCompilerName.SelectedIndex].options;
        }

        private void buttonAddCompiler_Click(object sender, EventArgs e)
        {
            compilers.Add(new Compiler(String.Empty, String.Empty, String.Empty, String.Empty));

            comboBoxCompilerName.Items.Add("Новый");
            comboBoxCompilerName.SelectedIndex = comboBoxCompilerName.Items.Count - 1;
            textBoxCompilerName.Text = textBoxSourceExtensions.Text = textBoxCompiler.Text = textBoxCompilerOptions.Text = String.Empty;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            int index = comboBoxCompilerName.SelectedIndex;
            /*compilers[index].name = textBoxCompilerName.Text;
            compilers[index].extensions = textBoxSourceExtensions.Text;
            compilers[index].path = textBoxCompiler.Text;
            compilers[index].options = textBoxCompilerOptions.Text;*/
            compilers[index] = new Compiler(
                textBoxCompilerName.Text,
                textBoxCompiler.Text,
                textBoxCompilerOptions.Name,
                textBoxSourceExtensions.Name
            );
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

        private void textBoxCompiler_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxCompiler_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                textBoxCompiler.Text = filePaths[0];
            }
        }

        private void textBoxCompiler_TextChanged(object sender, EventArgs e)
        {
            pictureBox.Image = (File.Exists(textBoxCompiler.Text) ? Icons.OK : Icons.Error);
        }
    }
}
