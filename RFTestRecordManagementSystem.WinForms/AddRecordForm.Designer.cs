namespace RFTestRecordManagementSystem.WinForms
{
    partial class AddRecordForm
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
            lblRegulation = new DevExpress.XtraEditors.LabelControl();
            lblTechnology = new DevExpress.XtraEditors.LabelControl();
            lblBand = new DevExpress.XtraEditors.LabelControl();
            lblPower = new DevExpress.XtraEditors.LabelControl();
            lblResult = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            txtRegulation = new DevExpress.XtraEditors.TextEdit();
            txtTechnology = new DevExpress.XtraEditors.TextEdit();
            txtBand = new DevExpress.XtraEditors.TextEdit();
            txtResult = new DevExpress.XtraEditors.TextEdit();
            spinPower = new DevExpress.XtraEditors.SpinEdit();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)txtRegulation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTechnology.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBand.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtResult.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinPower.Properties).BeginInit();
            SuspendLayout();
            // 
            // lblRegulation
            // 
            lblRegulation.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblRegulation.Appearance.Options.UseFont = true;
            lblRegulation.Location = new System.Drawing.Point(219, 112);
            lblRegulation.Name = "lblRegulation";
            lblRegulation.Size = new System.Drawing.Size(135, 29);
            lblRegulation.TabIndex = 0;
            lblRegulation.Text = "Regulation：";
            lblRegulation.Click += lblRegulation_Click;
            // 
            // lblTechnology
            // 
            lblTechnology.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblTechnology.Appearance.Options.UseFont = true;
            lblTechnology.Location = new System.Drawing.Point(234, 161);
            lblTechnology.Name = "lblTechnology";
            lblTechnology.Size = new System.Drawing.Size(120, 29);
            lblTechnology.TabIndex = 1;
            lblTechnology.Text = "無線技術：";
            lblTechnology.Click += lblTechnology_Click;
            // 
            // lblBand
            // 
            lblBand.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblBand.Appearance.Options.UseFont = true;
            lblBand.Location = new System.Drawing.Point(229, 212);
            lblBand.Name = "lblBand";
            lblBand.Size = new System.Drawing.Size(125, 29);
            lblBand.TabIndex = 2;
            lblBand.Text = "測試Band：";
            lblBand.Click += lblBand_Click;
            // 
            // lblPower
            // 
            lblPower.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblPower.Appearance.Options.UseFont = true;
            lblPower.Location = new System.Drawing.Point(234, 263);
            lblPower.Name = "lblPower";
            lblPower.Size = new System.Drawing.Size(120, 29);
            lblPower.TabIndex = 3;
            lblPower.Text = "測試功率：";
            lblPower.Click += lblPower_Click;
            // 
            // lblResult
            // 
            lblResult.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblResult.Appearance.Options.UseFont = true;
            lblResult.Location = new System.Drawing.Point(234, 316);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(120, 29);
            lblResult.TabIndex = 4;
            lblResult.Text = "測試結果：";
            lblResult.Click += lblResult_Click;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            labelControl1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            labelControl1.LineVisible = true;
            labelControl1.Location = new System.Drawing.Point(74, 55);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(128, 39);
            labelControl1.TabIndex = 5;
            labelControl1.Text = "請輸入：";
            labelControl1.Click += labelControl1_Click;
            // 
            // txtRegulation
            // 
            txtRegulation.Location = new System.Drawing.Point(387, 113);
            txtRegulation.Name = "txtRegulation";
            txtRegulation.Size = new System.Drawing.Size(225, 28);
            txtRegulation.TabIndex = 6;
            txtRegulation.EditValueChanged += textEdit1_EditValueChanged;
            // 
            // txtTechnology
            // 
            txtTechnology.Location = new System.Drawing.Point(387, 162);
            txtTechnology.Name = "txtTechnology";
            txtTechnology.Size = new System.Drawing.Size(225, 28);
            txtTechnology.TabIndex = 7;
            // 
            // txtBand
            // 
            txtBand.Location = new System.Drawing.Point(387, 213);
            txtBand.Name = "txtBand";
            txtBand.Size = new System.Drawing.Size(225, 28);
            txtBand.TabIndex = 8;
            // 
            // txtResult
            // 
            txtResult.Location = new System.Drawing.Point(387, 319);
            txtResult.Name = "txtResult";
            txtResult.Size = new System.Drawing.Size(225, 28);
            txtResult.TabIndex = 9;
            // 
            // spinPower
            // 
            spinPower.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            spinPower.Location = new System.Drawing.Point(387, 266);
            spinPower.Name = "spinPower";
            spinPower.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            spinPower.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            spinPower.Size = new System.Drawing.Size(225, 28);
            spinPower.TabIndex = 10;
            spinPower.EditValueChanged += spinPower_EditValueChanged;
            // 
            // simpleButton1
            // 
            simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            simpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 0, 64);
            simpleButton1.Appearance.Options.UseFont = true;
            simpleButton1.Appearance.Options.UseForeColor = true;
            simpleButton1.Location = new System.Drawing.Point(197, 374);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(168, 51);
            simpleButton1.TabIndex = 11;
            simpleButton1.Text = "確認";
            // 
            // simpleButton2
            // 
            simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            simpleButton2.Appearance.ForeColor = System.Drawing.Color.FromArgb(64, 0, 64);
            simpleButton2.Appearance.Options.UseFont = true;
            simpleButton2.Appearance.Options.UseForeColor = true;
            simpleButton2.Location = new System.Drawing.Point(444, 374);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new System.Drawing.Size(168, 51);
            simpleButton2.TabIndex = 12;
            simpleButton2.Text = "取消";
            // 
            // AddRecordForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(simpleButton2);
            Controls.Add(simpleButton1);
            Controls.Add(spinPower);
            Controls.Add(txtResult);
            Controls.Add(txtBand);
            Controls.Add(txtTechnology);
            Controls.Add(txtRegulation);
            Controls.Add(labelControl1);
            Controls.Add(lblResult);
            Controls.Add(lblPower);
            Controls.Add(lblBand);
            Controls.Add(lblTechnology);
            Controls.Add(lblRegulation);
            Name = "AddRecordForm";
            Text = "AddRecordForm";
            Load += AddRecordForm_Load;
            ((System.ComponentModel.ISupportInitialize)txtRegulation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTechnology.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBand.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtResult.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinPower.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblRegulation;
        private DevExpress.XtraEditors.LabelControl lblTechnology;
        private DevExpress.XtraEditors.LabelControl lblBand;
        private DevExpress.XtraEditors.LabelControl lblPower;
        private DevExpress.XtraEditors.LabelControl lblResult;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtRegulation;
        private DevExpress.XtraEditors.TextEdit txtTechnology;
        private DevExpress.XtraEditors.TextEdit txtBand;
        private DevExpress.XtraEditors.TextEdit txtResult;
        private DevExpress.XtraEditors.SpinEdit spinPower;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}