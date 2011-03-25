namespace olympchecker_gui
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBoxCompilerName = new System.Windows.Forms.TextBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonDeleteCompiler = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSourceExtensions = new System.Windows.Forms.TextBox();
            this.buttonAddCompiler = new System.Windows.Forms.Button();
            this.textBoxCompilerOptions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCompiler = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCompilerName = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Controls.Add(this.textBoxCompilerName);
            this.groupBox1.Controls.Add(this.buttonApply);
            this.groupBox1.Controls.Add(this.buttonDeleteCompiler);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxSourceExtensions);
            this.groupBox1.Controls.Add(this.buttonAddCompiler);
            this.groupBox1.Controls.Add(this.textBoxCompilerOptions);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxCompiler);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxCompilerName);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 214);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки компиляторов";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(451, 111);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(20, 20);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 12;
            this.pictureBox.TabStop = false;
            // 
            // textBoxCompilerName
            // 
            this.textBoxCompilerName.Location = new System.Drawing.Point(116, 50);
            this.textBoxCompilerName.Name = "textBoxCompilerName";
            this.textBoxCompilerName.Size = new System.Drawing.Size(218, 20);
            this.textBoxCompilerName.TabIndex = 11;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(396, 182);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 10;
            this.buttonApply.Text = "Применить";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonDeleteCompiler
            // 
            this.buttonDeleteCompiler.Location = new System.Drawing.Point(107, 182);
            this.buttonDeleteCompiler.Name = "buttonDeleteCompiler";
            this.buttonDeleteCompiler.Size = new System.Drawing.Size(95, 22);
            this.buttonDeleteCompiler.TabIndex = 9;
            this.buttonDeleteCompiler.Text = "Удалить";
            this.buttonDeleteCompiler.UseVisualStyleBackColor = true;
            this.buttonDeleteCompiler.Click += new System.EventHandler(this.buttonDeleteCompiler_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Название";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Расширения файлов";
            // 
            // textBoxSourceExtensions
            // 
            this.textBoxSourceExtensions.Location = new System.Drawing.Point(116, 79);
            this.textBoxSourceExtensions.Name = "textBoxSourceExtensions";
            this.textBoxSourceExtensions.Size = new System.Drawing.Size(355, 20);
            this.textBoxSourceExtensions.TabIndex = 6;
            // 
            // buttonAddCompiler
            // 
            this.buttonAddCompiler.Location = new System.Drawing.Point(7, 182);
            this.buttonAddCompiler.Name = "buttonAddCompiler";
            this.buttonAddCompiler.Size = new System.Drawing.Size(95, 22);
            this.buttonAddCompiler.TabIndex = 5;
            this.buttonAddCompiler.Text = "Добавить";
            this.buttonAddCompiler.UseVisualStyleBackColor = true;
            this.buttonAddCompiler.Click += new System.EventHandler(this.buttonAddCompiler_Click);
            // 
            // textBoxCompilerOptions
            // 
            this.textBoxCompilerOptions.Location = new System.Drawing.Point(116, 144);
            this.textBoxCompilerOptions.Name = "textBoxCompilerOptions";
            this.textBoxCompilerOptions.Size = new System.Drawing.Size(157, 20);
            this.textBoxCompilerOptions.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Опции компилятора";
            // 
            // textBoxCompiler
            // 
            this.textBoxCompiler.AllowDrop = true;
            this.textBoxCompiler.Location = new System.Drawing.Point(116, 111);
            this.textBoxCompiler.Name = "textBoxCompiler";
            this.textBoxCompiler.Size = new System.Drawing.Size(329, 20);
            this.textBoxCompiler.TabIndex = 2;
            this.textBoxCompiler.TextChanged += new System.EventHandler(this.textBoxCompiler_TextChanged);
            this.textBoxCompiler.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxCompiler_DragDrop);
            this.textBoxCompiler.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxCompiler_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Компилятор";
            // 
            // comboBoxCompilerName
            // 
            this.comboBoxCompilerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompilerName.FormattingEnabled = true;
            this.comboBoxCompilerName.Location = new System.Drawing.Point(7, 19);
            this.comboBoxCompilerName.Name = "comboBoxCompilerName";
            this.comboBoxCompilerName.Size = new System.Drawing.Size(163, 21);
            this.comboBoxCompilerName.TabIndex = 0;
            this.comboBoxCompilerName.SelectedIndexChanged += new System.EventHandler(this.comboBoxCompilerName_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(322, 232);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(421, 232);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 271);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.Activated += new System.EventHandler(this.SettingsForm_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDeleteCompiler;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSourceExtensions;
        private System.Windows.Forms.Button buttonAddCompiler;
        private System.Windows.Forms.TextBox textBoxCompilerOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCompiler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCompilerName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.TextBox textBoxCompilerName;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}