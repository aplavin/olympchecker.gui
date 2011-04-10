using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace olympchecker_gui
{
    public partial class CompilersForm : Form
    {

        private List<Compiler> compilers;

        public CompilersForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CompilersManager.compilers = compilers;
            CompilersManager.Save();
            this.Close();
        }

        private void SettingsForm_Activated(object sender, EventArgs e)
        {
            compilers = CompilersManager.compilers;

            comboCompilerName.Items.Clear();
            comboCompilerName.Items.AddRange(
                (from comp in compilers
                 select comp.name)
                .ToArray()
            );

            comboCompilerName.SelectedIndex = 0;
        }


        private void comboBoxCompilerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCompilerName.Text = compilers[comboCompilerName.SelectedIndex].name;
            tbSourceExtensions.Text = compilers[comboCompilerName.SelectedIndex].extensions;
            tbCompiler.Text = compilers[comboCompilerName.SelectedIndex].path;
            tbCompilerOptions.Text = compilers[comboCompilerName.SelectedIndex].options;
        }

        private void buttonAddCompiler_Click(object sender, EventArgs e)
        {
            compilers.Add(new Compiler(String.Empty, String.Empty, String.Empty, String.Empty));

            comboCompilerName.Items.Add("Новый");
            comboCompilerName.SelectedIndex = comboCompilerName.Items.Count - 1;
            tbCompilerName.Text = tbSourceExtensions.Text = tbCompiler.Text = tbCompilerOptions.Text = String.Empty;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            int index = comboCompilerName.SelectedIndex;
            compilers[index] = new Compiler(
                tbCompilerName.Text,
                tbCompiler.Text,
                tbCompilerOptions.Name,
                tbSourceExtensions.Name
            );
            comboCompilerName.Items[index] = tbCompilerName.Text;
        }

        private void buttonDeleteCompiler_Click(object sender, EventArgs e)
        {
            if (comboCompilerName.Items.Count <= 1)
            {
                Utils.Error("Нельзя удалить единственный компилятор");
            }
            else
            {
                comboCompilerName.Items.RemoveAt(comboCompilerName.SelectedIndex);
                compilers.RemoveAt(comboCompilerName.SelectedIndex);
                comboCompilerName.SelectedIndex = 0;
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
                tbCompiler.Text = filePaths[0];
                tbCompiler.SelectionStart = tbCompiler.Text.Length;
            }
        }

        private void textBoxCompiler_TextChanged(object sender, EventArgs e)
        {
            string text = tbCompiler.Text;
            Image image = null;
            string tooltip = null;

            if (String.IsNullOrEmpty(text))
            {
                image = Icons.Warning;
                tooltip = "Не введено имя файла";
            }
            else if (!File.Exists(text))
            {
                image = Icons.Error;
                tooltip = "Файл не существует";
            }
            else
            {
                image = Icons.OK;
            }

            pictureBox.Image = image;
            toolTip.SetToolTip(pictureBox, tooltip);
        }

        private void tbCompiler_DoubleClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbCompiler.Text))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(tbCompiler.Text);
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbCompiler.Text = openFileDialog.FileName;
                tbCompiler.SelectionStart = tbCompiler.Text.Length;
            }
        }
    }
}
