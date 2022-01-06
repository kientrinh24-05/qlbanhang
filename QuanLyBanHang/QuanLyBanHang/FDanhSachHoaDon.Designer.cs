
namespace QuanLyBanHang
{
    partial class FDanhSachHoaDon
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
            this.label1 = new System.Windows.Forms.Label();
            this.quanlybanhangDataSet1 = new QuanLyBanHang.QUANLYBANHANGDataSet();
            this.dGHDBH = new System.Windows.Forms.DataGridView();
            this.Import = new CustomButton.VBButton();
            ((System.ComponentModel.ISupportInitialize)(this.quanlybanhangDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGHDBH)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(347, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 29);
            this.label1.TabIndex = 37;
            this.label1.Text = "DANH SÁCH HÓA ĐƠN BÁN HÀNG";
            // 
            // quanlybanhangDataSet1
            // 
            this.quanlybanhangDataSet1.DataSetName = "QUANLYBANHANGDataSet";
            this.quanlybanhangDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dGHDBH
            // 
            this.dGHDBH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGHDBH.Location = new System.Drawing.Point(22, 108);
            this.dGHDBH.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dGHDBH.Name = "dGHDBH";
            this.dGHDBH.RowHeadersWidth = 51;
            this.dGHDBH.RowTemplate.Height = 24;
            this.dGHDBH.Size = new System.Drawing.Size(1022, 464);
            this.dGHDBH.TabIndex = 38;
            // 
            // Import
            // 
            this.Import.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Import.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Import.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Import.BorderRadius = 20;
            this.Import.BorderSize = 0;
            this.Import.FlatAppearance.BorderSize = 0;
            this.Import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Import.ForeColor = System.Drawing.Color.White;
            this.Import.Location = new System.Drawing.Point(829, 584);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(108, 40);
            this.Import.TabIndex = 39;
            this.Import.Text = "Import";
            this.Import.TextColor = System.Drawing.Color.White;
            this.Import.UseVisualStyleBackColor = false;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // FDanhSachHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 636);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.dGHDBH);
            this.Controls.Add(this.label1);
            this.Name = "FDanhSachHoaDon";
            this.Text = "FDanhSachHoaDon";
            this.Load += new System.EventHandler(this.FDanhSachHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanlybanhangDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGHDBH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private QUANLYBANHANGDataSet quanlybanhangDataSet1;
        private System.Windows.Forms.DataGridView dGHDBH;
        private CustomButton.VBButton Import;
    }
}