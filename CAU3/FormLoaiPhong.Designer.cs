using static System.Net.Mime.MediaTypeNames;

namespace CAU3
{
    partial class FormLoaiPhong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaLoai = new Label();
            lblTenLoai = new Label();
            lblGia = new Label();
            lblMoTa = new Label();

            txtMaLoai = new TextBox();
            txtTenLoai = new TextBox();
            txtGia = new TextBox();
            txtMoTa = new TextBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnDong = new Button();

            dgvLoaiPhong = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).BeginInit();
            SuspendLayout();

            // Mã loại
            lblMaLoai.AutoSize = true;
            lblMaLoai.Location = new Point(30, 30);
            lblMaLoai.Text = "Mã loại";

            txtMaLoai.Location = new Point(140, 27);
            txtMaLoai.Name = "txtMaLoai";
            txtMaLoai.ReadOnly = true;
            txtMaLoai.Size = new Size(250, 27);

            // Tên loại
            lblTenLoai.AutoSize = true;
            lblTenLoai.Location = new Point(30, 75);
            lblTenLoai.Text = "Tên loại";

            txtTenLoai.Location = new Point(140, 72);
            txtTenLoai.Name = "txtTenLoai";
            txtTenLoai.Size = new Size(250, 27);

            // Giá mỗi đêm
            lblGia.AutoSize = true;
            lblGia.Location = new Point(30, 120);
            lblGia.Text = "Giá mỗi đêm";

            txtGia.Location = new Point(140, 117);
            txtGia.Name = "txtGia";
            txtGia.Size = new Size(250, 27);

            // Mô tả
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(30, 165);
            lblMoTa.Text = "Mô tả";

            txtMoTa.Location = new Point(140, 162);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(250, 80);

            // Thêm
            btnThem.Location = new Point(450, 27);
            btnThem.Size = new Size(110, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            // Sửa
            btnSua.Location = new Point(450, 72);
            btnSua.Size = new Size(110, 35);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            // Xóa
            btnXoa.Location = new Point(450, 117);
            btnXoa.Size = new Size(110, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            // Làm mới
            btnLamMoi.Location = new Point(450, 162);
            btnLamMoi.Size = new Size(110, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            // Đóng
            btnDong.Location = new Point(450, 207);
            btnDong.Size = new Size(110, 35);
            btnDong.Text = "Đóng";
            btnDong.Click += btnDong_Click;

            // DataGridView
            dgvLoaiPhong.AllowUserToAddRows = false;
            dgvLoaiPhong.AllowUserToDeleteRows = false;
            dgvLoaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaiPhong.Location = new Point(30, 280);
            dgvLoaiPhong.MultiSelect = false;
            dgvLoaiPhong.Name = "dgvLoaiPhong";
            dgvLoaiPhong.ReadOnly = true;
            dgvLoaiPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiPhong.Size = new Size(700, 270);
            dgvLoaiPhong.SelectionChanged += dgvLoaiPhong_SelectionChanged;

            // Form
            ClientSize = new Size(770, 590);
            Controls.Add(lblMaLoai);
            Controls.Add(txtMaLoai);
            Controls.Add(lblTenLoai);
            Controls.Add(txtTenLoai);
            Controls.Add(lblGia);
            Controls.Add(txtGia);
            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnDong);

            Controls.Add(dgvLoaiPhong);

            Name = "FormLoaiPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý loại phòng";
            Load += FormLoaiPhong_Load;

            ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMaLoai;
        private Label lblTenLoai;
        private Label lblGia;
        private Label lblMoTa;

        private TextBox txtMaLoai;
        private TextBox txtTenLoai;
        private TextBox txtGia;
        private TextBox txtMoTa;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnDong;

        private DataGridView dgvLoaiPhong;
    }
}