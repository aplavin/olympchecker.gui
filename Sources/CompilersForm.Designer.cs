namespace olympchecker_gui
{
    partial class CompilersForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompilersForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tbCompilerName = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnDeleteCompiler = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSourceExtensions = new System.Windows.Forms.TextBox();
            this.btnAddCompiler = new System.Windows.Forms.Button();
            this.tbCompilerOptions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCompiler = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboCompilerName = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Controls.Add(this.tbCompilerName);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.btnDeleteCompiler);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbSourceExtensions);
            this.groupBox1.Controls.Add(this.btnAddCompiler);
            this.groupBox1.Controls.Add(this.tbCompilerOptions);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbCompiler);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboCompilerName);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 218);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройка";
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
            // tbCompilerName
            // 
            this.tbCompilerName.Location = new System.Drawing.Point(116, 50);
            this.tbCompilerName.Name = "tbCompilerName";
            this.tbCompilerName.Size = new System.Drawing.Size(355, 20);
            this.tbCompilerName.TabIndex = 11;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(396, 185);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // btnDeleteCompiler
            // 
            this.btnDeleteCompiler.Location = new System.Drawing.Point(107, 182);
            this.btnDeleteCompiler.Name = "btnDeleteCompiler";
            this.btnDeleteCompiler.Size = new System.Drawing.Size(95, 22);
            this.btnDeleteCompiler.TabIndex = 9;
            this.btnDeleteCompiler.Text = "Удалить";
            this.btnDeleteCompiler.UseVisualStyleBackColor = true;
            this.btnDeleteCompiler.Click += new System.EventHandler(this.buttonDeleteCompiler_Click);
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
            // tbSourceExtensions
            // 
            this.tbSourceExtensions.Location = new System.Drawing.Point(116, 79);
            this.tbSourceExtensions.Name = "tbSourceExtensions";
            this.tbSourceExtensions.Size = new System.Drawing.Size(355, 20);
            this.tbSourceExtensions.TabIndex = 6;
            // 
            // btnAddCompiler
            // 
            this.btnAddCompiler.Location = new System.Drawing.Point(7, 182);
            this.btnAddCompiler.Name = "btnAddCompiler";
            this.btnAddCompiler.Size = new System.Drawing.Size(95, 22);
            this.btnAddCompiler.TabIndex = 5;
            this.btnAddCompiler.Text = "Добавить";
            this.btnAddCompiler.UseVisualStyleBackColor = true;
            this.btnAddCompiler.Click += new System.EventHandler(this.buttonAddCompiler_Click);
            // 
            // tbCompilerOptions
            // 
            this.tbCompilerOptions.Location = new System.Drawing.Point(116, 144);
            this.tbCompilerOptions.Name = "tbCompilerOptions";
            this.tbCompilerOptions.Size = new System.Drawing.Size(355, 20);
            this.tbCompilerOptions.TabIndex = 4;
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
            // tbCompiler
            // 
            this.tbCompiler.AllowDrop = true;
            this.tbCompiler.Location = new System.Drawing.Point(116, 111);
            this.tbCompiler.Name = "tbCompiler";
            this.tbCompiler.Size = new System.Drawing.Size(329, 20);
            this.tbCompiler.TabIndex = 2;
            this.tbCompiler.TextChanged += new System.EventHandler(this.textBoxCompiler_TextChanged);
            this.tbCompiler.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxCompiler_DragDrop);
            this.tbCompiler.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxCompiler_DragEnter);
            this.tbCompiler.DoubleClick += new System.EventHandler(this.tbCompiler_DoubleClick);
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
            // comboCompilerName
            // 
            this.comboCompilerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCompilerName.FormattingEnabled = true;
            this.comboCompilerName.Location = new System.Drawing.Point(7, 19);
            this.comboCompilerName.Name = "comboCompilerName";
            this.comboCompilerName.Size = new System.Drawing.Size(163, 21);
            this.comboCompilerName.TabIndex = 0;
            this.comboCompilerName.SelectedIndexChanged += new System.EventHandler(this.comboBoxCompilerName_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(329, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(427, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.RestoreDirectory = true;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipTitle = "Ошибка";
            // 
            // CompilersForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(514, 271);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CompilersForm";
            this.Text = "Компиляторы";
            this.Activated += new System.EventHandler(this.SettingsForm_Activated);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteCompiler;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSourceExtensions;
        private System.Windows.Forms.Button btnAddCompiler;
        private System.Windows.Forms.TextBox tbCompilerOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCompiler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboCompilerName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox tbCompilerName;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
    }
}