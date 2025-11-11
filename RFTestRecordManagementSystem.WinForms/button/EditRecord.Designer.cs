namespace RFTestRecordManagementSystem.WinForms.button
{
    partial class EditRecord
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
            txtRegulation = new DevExpress.XtraEditors.TextEdit();
            txtTechnology = new DevExpress.XtraEditors.TextEdit();
            txtBand = new DevExpress.XtraEditors.TextEdit();
            txtResult = new DevExpress.XtraEditors.TextEdit();
            spinPower = new DevExpress.XtraEditors.SpinEdit();
            btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)txtRegulation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTechnology.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBand.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtResult.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinPower.Properties).BeginInit();
            SuspendLayout();
            // 
            // lblRegulation
            // 
            lblRegulation.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblRegulation.Appearance.Options.UseFont = true;
            lblRegulation.Location = new System.Drawing.Point(165, 42);
            lblRegulation.Name = "lblRegulation";
            lblRegulation.Size = new System.Drawing.Size(182, 39);
            lblRegulation.TabIndex = 0;
            lblRegulation.Text = "Regulation：";
            lblRegulation.Click += lblRegulation_Click;
            // 
            // lblTechnology
            // 
            lblTechnology.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblTechnology.Appearance.Options.UseFont = true;
            lblTechnology.Location = new System.Drawing.Point(187, 101);
            lblTechnology.Name = "lblTechnology";
            lblTechnology.Size = new System.Drawing.Size(160, 39);
            lblTechnology.TabIndex = 1;
            lblTechnology.Text = "無線技術：";
            // 
            // lblBand
            // 
            lblBand.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblBand.Appearance.Options.UseFont = true;
            lblBand.Location = new System.Drawing.Point(169, 157);
            lblBand.Name = "lblBand";
            lblBand.Size = new System.Drawing.Size(178, 39);
            lblBand.TabIndex = 2;
            lblBand.Text = "測試 Band：";
            // 
            // lblPower
            // 
            lblPower.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblPower.Appearance.Options.UseFont = true;
            lblPower.Location = new System.Drawing.Point(187, 213);
            lblPower.Name = "lblPower";
            lblPower.Size = new System.Drawing.Size(160, 39);
            lblPower.TabIndex = 3;
            lblPower.Text = "測試功率：";
            // 
            // lblResult
            // 
            lblResult.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblResult.Appearance.Options.UseFont = true;
            lblResult.Location = new System.Drawing.Point(187, 274);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(160, 39);
            lblResult.TabIndex = 4;
            lblResult.Text = "測試結果：";
            // 
            // txtRegulation
            // 
            txtRegulation.Location = new System.Drawing.Point(353, 45);
            txtRegulation.Name = "txtRegulation";
            txtRegulation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtRegulation.Properties.Appearance.Options.UseFont = true;
            txtRegulation.Size = new System.Drawing.Size(225, 36);
            txtRegulation.TabIndex = 5;
            txtRegulation.Click += txtRegulation_Click;
            // 
            // txtTechnology
            // 
            txtTechnology.Location = new System.Drawing.Point(353, 104);
            txtTechnology.Name = "txtTechnology";
            txtTechnology.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtTechnology.Properties.Appearance.Options.UseFont = true;
            txtTechnology.Size = new System.Drawing.Size(225, 36);
            txtTechnology.TabIndex = 6;
            txtTechnology.Click += txtTechnology_Click;
            // 
            // txtBand
            // 
            txtBand.Location = new System.Drawing.Point(353, 160);
            txtBand.Name = "txtBand";
            txtBand.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtBand.Properties.Appearance.Options.UseFont = true;
            txtBand.Size = new System.Drawing.Size(225, 36);
            txtBand.TabIndex = 7;
            txtBand.Click += txtBand_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new System.Drawing.Point(353, 277);
            txtResult.Name = "txtResult";
            txtResult.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtResult.Properties.Appearance.Options.UseFont = true;
            txtResult.Size = new System.Drawing.Size(225, 36);
            txtResult.TabIndex = 8;
            txtResult.Click += txtResult_Click;
            // 
            // spinPower
            // 
            spinPower.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            spinPower.Location = new System.Drawing.Point(353, 216);
            spinPower.Name = "spinPower";
            spinPower.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            spinPower.Properties.Appearance.Options.UseFont = true;
            spinPower.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            spinPower.Size = new System.Drawing.Size(225, 36);
            spinPower.TabIndex = 10;
            spinPower.Click += spinPower_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnConfirm.Appearance.Options.UseFont = true;
            btnConfirm.Location = new System.Drawing.Point(165, 355);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new System.Drawing.Size(168, 51);
            btnConfirm.TabIndex = 11;
            btnConfirm.Text = "確認修改";
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Location = new System.Drawing.Point(410, 355);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(168, 51);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "取消";
            btnCancel.Click += btnCancel_Click;
            // 
            // EditRecord
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(spinPower);
            Controls.Add(txtResult);
            Controls.Add(txtBand);
            Controls.Add(txtTechnology);
            Controls.Add(txtRegulation);
            Controls.Add(lblResult);
            Controls.Add(lblPower);
            Controls.Add(lblBand);
            Controls.Add(lblTechnology);
            Controls.Add(lblRegulation);
            Name = "EditRecord";
            Text = "EditRecord";
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
        private DevExpress.XtraEditors.TextEdit txtRegulation;
        private DevExpress.XtraEditors.TextEdit txtTechnology;
        private DevExpress.XtraEditors.TextEdit txtBand;
        private DevExpress.XtraEditors.TextEdit txtResult;
        private DevExpress.XtraEditors.SpinEdit spinPower;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}