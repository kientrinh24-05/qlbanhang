namespace QuanLyBanHang
{
    partial class FTonKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTonKho));
            this.btn_xem = new CustomButton.VBButton();
            this.item = new System.Windows.Forms.ComboBox();
            this.dFrom = new System.Windows.Forms.DateTimePicker();
            this.dTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btn_print = new CustomButton.VBButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maPNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maDHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayBanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slxuatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tonKhoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qUANLYBANHANGDataSet = new QuanLyBanHang.QUANLYBANHANGDataSet();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSảnPhẩmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýĐơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.tonKhoTableAdapter = new QuanLyBanHang.QUANLYBANHANGDataSetTableAdapters.TonKhoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tonKhoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUANLYBANHANGDataSet)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_xem
            // 
            this.btn_xem.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_xem.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_xem.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_xem.BorderRadius = 20;
            this.btn_xem.BorderSize = 0;
            this.btn_xem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xem.ForeColor = System.Drawing.Color.White;
            this.btn_xem.Location = new System.Drawing.Point(890, 123);
            this.btn_xem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_xem.Name = "btn_xem";
            this.btn_xem.Size = new System.Drawing.Size(112, 35);
            this.btn_xem.TabIndex = 1;
            this.btn_xem.Text = "Xem";
            this.btn_xem.TextColor = System.Drawing.Color.White;
            this.btn_xem.UseVisualStyleBackColor = true;
            this.btn_xem.Click += new System.EventHandler(this.btn_xem_Click);
            // 
            // item
            // 
            this.item.FormattingEnabled = true;
            this.item.Location = new System.Drawing.Point(669, 125);
            this.item.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(180, 28);
            this.item.TabIndex = 2;
            this.item.SelectedIndexChanged += new System.EventHandler(this.item_SelectedIndexChanged);
            // 
            // dFrom
            // 
            this.dFrom.CustomFormat = "dd-MM-yyyy";
            this.dFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dFrom.Location = new System.Drawing.Point(148, 128);
            this.dFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dFrom.Name = "dFrom";
            this.dFrom.Size = new System.Drawing.Size(178, 26);
            this.dFrom.TabIndex = 3;
            // 
            // dTo
            // 
            this.dTo.CustomFormat = "dd-MM-yyyy";
            this.dTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTo.Location = new System.Drawing.Point(339, 126);
            this.dTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dTo.Name = "dTo";
            this.dTo.Size = new System.Drawing.Size(178, 26);
            this.dTo.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ngày từ/đến :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(548, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sản phẩm :";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.Size = new System.Drawing.Size(400, 250);
            this.reportViewer1.TabIndex = 0;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_print.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_print.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btn_print.BorderRadius = 20;
            this.btn_print.BorderSize = 0;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.Location = new System.Drawing.Point(1012, 123);
            this.btn_print.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(112, 35);
            this.btn_print.TabIndex = 7;
            this.btn_print.Text = "Xuất Excel";
            this.btn_print.TextColor = System.Drawing.Color.White;
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maPNDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.maDHDataGridViewTextBoxColumn,
            this.ngayBanDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn10,
            this.slxuatDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn11});
            this.dataGridView1.DataSource = this.tonKhoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(2, 209);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1124, 348);
            this.dataGridView1.TabIndex = 8;
            // 
            // maPNDataGridViewTextBoxColumn
            // 
            this.maPNDataGridViewTextBoxColumn.DataPropertyName = "MaPN";
            this.maPNDataGridViewTextBoxColumn.HeaderText = "MaPN";
            this.maPNDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maPNDataGridViewTextBoxColumn.Name = "maPNDataGridViewTextBoxColumn";
            this.maPNDataGridViewTextBoxColumn.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MaSP";
            this.dataGridViewTextBoxColumn6.HeaderText = "MaSP";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TenSP";
            this.dataGridViewTextBoxColumn7.HeaderText = "TenSP";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DVT";
            this.dataGridViewTextBoxColumn8.HeaderText = "DVT";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NgayNhap";
            this.dataGridViewTextBoxColumn9.HeaderText = "NgayNhap";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // maDHDataGridViewTextBoxColumn
            // 
            this.maDHDataGridViewTextBoxColumn.DataPropertyName = "MaDH";
            this.maDHDataGridViewTextBoxColumn.HeaderText = "MaDH";
            this.maDHDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.maDHDataGridViewTextBoxColumn.Name = "maDHDataGridViewTextBoxColumn";
            this.maDHDataGridViewTextBoxColumn.Width = 150;
            // 
            // ngayBanDataGridViewTextBoxColumn
            // 
            this.ngayBanDataGridViewTextBoxColumn.DataPropertyName = "NgayBan";
            this.ngayBanDataGridViewTextBoxColumn.HeaderText = "NgayBan";
            this.ngayBanDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.ngayBanDataGridViewTextBoxColumn.Name = "ngayBanDataGridViewTextBoxColumn";
            this.ngayBanDataGridViewTextBoxColumn.Width = 150;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "sl_nhap";
            this.dataGridViewTextBoxColumn10.HeaderText = "sl_nhap";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // slxuatDataGridViewTextBoxColumn
            // 
            this.slxuatDataGridViewTextBoxColumn.DataPropertyName = "sl_xuat";
            this.slxuatDataGridViewTextBoxColumn.HeaderText = "sl_xuat";
            this.slxuatDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.slxuatDataGridViewTextBoxColumn.Name = "slxuatDataGridViewTextBoxColumn";
            this.slxuatDataGridViewTextBoxColumn.ReadOnly = true;
            this.slxuatDataGridViewTextBoxColumn.Width = 150;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "sl_ton";
            this.dataGridViewTextBoxColumn11.HeaderText = "sl_ton";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 150;
            // 
            // tonKhoBindingSource
            // 
            this.tonKhoBindingSource.DataMember = "TonKho";
            this.tonKhoBindingSource.DataSource = this.qUANLYBANHANGDataSet;
            // 
            // qUANLYBANHANGDataSet
            // 
            this.qUANLYBANHANGDataSet.DataSetName = "QUANLYBANHANGDataSet";
            this.qUANLYBANHANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýSảnPhẩmToolStripMenuItem,
            this.quảnLýĐơnHàngToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1246, 40);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýSảnPhẩmToolStripMenuItem
            // 
            this.quảnLýSảnPhẩmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýNhânViênToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.quảnLýNhàCungCấpToolStripMenuItem,
            this.quảnLýSảnPhẩmToolStripMenuItem1});
            this.quảnLýSảnPhẩmToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.quảnLýSảnPhẩmToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.quảnLýSảnPhẩmToolStripMenuItem.Name = "quảnLýSảnPhẩmToolStripMenuItem";
            this.quảnLýSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(191, 36);
            this.quảnLýSảnPhẩmToolStripMenuItem.Text = "Dữ Liệu Cơ Sở";
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(382, 40);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản Lý Nhân Viên";
            this.quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(382, 40);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản Lý Khách Hàng";
            this.quảnLýKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchHàngToolStripMenuItem_Click);
            // 
            // quảnLýNhàCungCấpToolStripMenuItem
            // 
            this.quảnLýNhàCungCấpToolStripMenuItem.Name = "quảnLýNhàCungCấpToolStripMenuItem";
            this.quảnLýNhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(382, 40);
            this.quảnLýNhàCungCấpToolStripMenuItem.Text = "Quản Lý Nhà Cung Cấp";
            this.quảnLýNhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhàCungCấpToolStripMenuItem_Click);
            // 
            // quảnLýSảnPhẩmToolStripMenuItem1
            // 
            this.quảnLýSảnPhẩmToolStripMenuItem1.Name = "quảnLýSảnPhẩmToolStripMenuItem1";
            this.quảnLýSảnPhẩmToolStripMenuItem1.Size = new System.Drawing.Size(382, 40);
            this.quảnLýSảnPhẩmToolStripMenuItem1.Text = "Quản Lý Sản Phẩm";
            this.quảnLýSảnPhẩmToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýSảnPhẩmToolStripMenuItem1_Click);
            // 
            // quảnLýĐơnHàngToolStripMenuItem
            // 
            this.quảnLýĐơnHàngToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.quảnLýĐơnHàngToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.quảnLýĐơnHàngToolStripMenuItem.Name = "quảnLýĐơnHàngToolStripMenuItem";
            this.quảnLýĐơnHàngToolStripMenuItem.Size = new System.Drawing.Size(247, 36);
            this.quảnLýĐơnHàngToolStripMenuItem.Text = "Quản lý nhập hàng";
            this.quảnLýĐơnHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐơnHàngToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(233, 36);
            this.toolStripMenuItem2.Text = "Quản lý bán hàng";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.Blue;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(227, 36);
            this.toolStripMenuItem3.Text = "Báo Cáo Tồn Kho";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(446, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(364, 29);
            this.label3.TabIndex = 30;
            this.label3.Text = "TRA CỨU TỒN KHO SẢN PHẨM";
            // 
            // tonKhoTableAdapter
            // 
            this.tonKhoTableAdapter.ClearBeforeFill = true;
            // 
            // FTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1246, 674);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dTo);
            this.Controls.Add(this.dFrom);
            this.Controls.Add(this.item);
            this.Controls.Add(this.btn_xem);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FTonKho";
            this.Text = "Quản Lý Bán Hàng - Tra Cứu Tồn Kho Sản Phẩm";
            this.Load += new System.EventHandler(this.FTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tonKhoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUANLYBANHANGDataSet)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn maSPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dVTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slnhapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sltonDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox item;
        private System.Windows.Forms.DateTimePicker dFrom;
        private System.Windows.Forms.DateTimePicker dTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayNhapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn asslxuatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýĐơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Label label3;
        private CustomButton.VBButton btn_xem;
        private CustomButton.VBButton btn_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn maPNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayBanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn slxuatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.BindingSource tonKhoBindingSource;
        private QUANLYBANHANGDataSet qUANLYBANHANGDataSet;
        private QUANLYBANHANGDataSetTableAdapters.TonKhoTableAdapter tonKhoTableAdapter;
    }
}