namespace CAU1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblMaTL = new Label();
            lblTenTheLoai = new Label();
            lblMoTa = new Label();
            lblNgayTaoText = new Label();

            txtMaTL = new TextBox();
            txtTenTheLoai = new TextBox();
            txtMoTa = new TextBox();
            txtTimKiem = new TextBox();

            lblNgayTao = new Label();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnTimKiem = new Button();

            dgvTheLoaiSach = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).BeginInit();
            SuspendLayout();

            // lblMaTL
            lblMaTL.AutoSize = true;
            lblMaTL.Location = new Point(30, 35);
            lblMaTL.Name = "lblMaTL";
            lblMaTL.Size = new Size(83, 20);
            lblMaTL.Text = "Mã thể loại";

            // txtMaTL
            txtMaTL.Location = new Point(140, 32);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.ReadOnly = true;
            txtMaTL.Size = new Size(260, 27);

            // lblTenTheLoai
            lblTenTheLoai.AutoSize = true;
            lblTenTheLoai.Location = new Point(30, 80);
            lblTenTheLoai.Name = "lblTenTheLoai";
            lblTenTheLoai.Size = new Size(91, 20);
            lblTenTheLoai.Text = "Tên thể loại";

            // txtTenTheLoai
            txtTenTheLoai.Location = new Point(140, 77);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(260, 27);

            // lblMoTa
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(30, 125);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(48, 20);
            lblMoTa.Text = "Mô tả";

            // txtMoTa
            txtMoTa.Location = new Point(140, 122);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(260, 95);

            // lblNgayTaoText
            lblNgayTaoText.AutoSize = true;
            lblNgayTaoText.Location = new Point(30, 235);
            lblNgayTaoText.Name = "lblNgayTaoText";
            lblNgayTaoText.Size = new Size(70, 20);
            lblNgayTaoText.Text = "Ngày tạo";

            // lblNgayTao
            lblNgayTao.AutoSize = true;
            lblNgayTao.Location = new Point(140, 235);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new Size(18, 20);
            lblNgayTao.Text = "...";

            // btnThem
            btnThem.Location = new Point(500, 32);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 35);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;

            // btnSua
            btnSua.Location = new Point(620, 32);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 35);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;

            // btnXoa
            btnXoa.Location = new Point(740, 32);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 35);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // btnLamMoi
            btnLamMoi.Location = new Point(860, 32);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;

            // txtTimKiem
            txtTimKiem.Location = new Point(30, 285);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên thể loại cần tìm...";
            txtTimKiem.Size = new Size(370, 27);

            // btnTimKiem
            btnTimKiem.Location = new Point(415, 282);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 33);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;

            // dgvTheLoaiSach
            dgvTheLoaiSach.AllowUserToAddRows = false;
            dgvTheLoaiSach.AllowUserToDeleteRows = false;
            dgvTheLoaiSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoaiSach.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheLoaiSach.Location = new Point(30, 335);
            dgvTheLoaiSach.MultiSelect = false;
            dgvTheLoaiSach.Name = "dgvTheLoaiSach";
            dgvTheLoaiSach.ReadOnly = true;
            dgvTheLoaiSach.RowHeadersWidth = 51;
            dgvTheLoaiSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoaiSach.Size = new Size(930, 300);
            dgvTheLoaiSach.SelectionChanged += dgvTheLoaiSach_SelectionChanged;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 670);
            Controls.Add(lblMaTL);
            Controls.Add(txtMaTL);
            Controls.Add(lblTenTheLoai);
            Controls.Add(txtTenTheLoai);
            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);
            Controls.Add(lblNgayTaoText);
            Controls.Add(lblNgayTao);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvTheLoaiSach);

            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Thể Loại Sách - Tri Thức Books";
            Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaTL;
        private Label lblTenTheLoai;
        private Label lblMoTa;
        private Label lblNgayTaoText;
        private Label lblNgayTao;

        private TextBox txtMaTL;
        private TextBox txtTenTheLoai;
        private TextBox txtMoTa;
        private TextBox txtTimKiem;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;

        private DataGridView dgvTheLoaiSach;
    }
}