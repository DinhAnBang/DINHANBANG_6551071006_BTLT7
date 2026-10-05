namespace CAU3
{
    partial class Form1
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
            lblMaPhong = new Label();
            lblSoPhong = new Label();
            lblTang = new Label();
            lblLoaiPhong = new Label();
            lblTinhTrang = new Label();
            lblHinhAnh = new Label();
            lblLocLoai = new Label();
            lblLocTinhTrang = new Label();

            txtMaPhong = new TextBox();
            txtSoPhong = new TextBox();
            txtTang = new TextBox();
            txtHinhAnh = new TextBox();

            cboLoaiPhong = new ComboBox();
            cboTinhTrang = new ComboBox();
            cboLocLoai = new ComboBox();
            cboLocTinhTrang = new ComboBox();

            picHinhAnh = new PictureBox();

            btnChonAnh = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnLoaiPhong = new Button();
            btnLoc = new Button();

            dgvPhong = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();

            SuspendLayout();

            // Mã phòng
            lblMaPhong.AutoSize = true;
            lblMaPhong.Location = new Point(30, 30);
            lblMaPhong.Text = "Mã phòng";

            txtMaPhong.Location = new Point(150, 27);
            txtMaPhong.ReadOnly = true;
            txtMaPhong.Size = new Size(250, 27);

            // Số phòng
            lblSoPhong.AutoSize = true;
            lblSoPhong.Location = new Point(30, 70);
            lblSoPhong.Text = "Số phòng";

            txtSoPhong.Location = new Point(150, 67);
            txtSoPhong.Size = new Size(250, 27);

            // Tầng
            lblTang.AutoSize = true;
            lblTang.Location = new Point(30, 110);
            lblTang.Text = "Tầng số";

            txtTang.Location = new Point(150, 107);
            txtTang.Size = new Size(250, 27);

            // Loại phòng
            lblLoaiPhong.AutoSize = true;
            lblLoaiPhong.Location = new Point(30, 150);
            lblLoaiPhong.Text = "Loại phòng";

            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.Location = new Point(150, 147);
            cboLoaiPhong.Size = new Size(250, 28);

            // Tình trạng
            lblTinhTrang.AutoSize = true;
            lblTinhTrang.Location = new Point(30, 190);
            lblTinhTrang.Text = "Tình trạng";

            cboTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTinhTrang.Location = new Point(150, 187);
            cboTinhTrang.Size = new Size(250, 28);

            // Hình ảnh
            lblHinhAnh.AutoSize = true;
            lblHinhAnh.Location = new Point(30, 230);
            lblHinhAnh.Text = "Hình ảnh";

            txtHinhAnh.Location = new Point(150, 227);
            txtHinhAnh.ReadOnly = true;
            txtHinhAnh.Size = new Size(250, 27);

            btnChonAnh.Location = new Point(410, 225);
            btnChonAnh.Size = new Size(100, 32);
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.Click += btnChonAnh_Click;

            // PictureBox
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            picHinhAnh.Location = new Point(540, 27);
            picHinhAnh.Size = new Size(230, 230);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;

            // Buttons
            btnThem.Location = new Point(820, 27);
            btnThem.Size = new Size(120, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(820, 72);
            btnSua.Size = new Size(120, 35);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(820, 117);
            btnXoa.Size = new Size(120, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(820, 162);
            btnLamMoi.Size = new Size(120, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            btnLoaiPhong.Location = new Point(820, 207);
            btnLoaiPhong.Size = new Size(120, 50);
            btnLoaiPhong.Text = "Quản lý\nloại phòng";
            btnLoaiPhong.Click += btnLoaiPhong_Click;

            // Bộ lọc
            lblLocLoai.AutoSize = true;
            lblLocLoai.Location = new Point(30, 305);
            lblLocLoai.Text = "Loại phòng";

            cboLocLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoai.Location = new Point(130, 302);
            cboLocLoai.Size = new Size(200, 28);

            lblLocTinhTrang.AutoSize = true;
            lblLocTinhTrang.Location = new Point(360, 305);
            lblLocTinhTrang.Text = "Tình trạng";

            cboLocTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocTinhTrang.Location = new Point(450, 302);
            cboLocTinhTrang.Size = new Size(190, 28);

            btnLoc.Location = new Point(670, 298);
            btnLoc.Size = new Size(100, 35);
            btnLoc.Text = "Lọc";
            btnLoc.Click += btnLoc_Click;

            // DataGridView
            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.AllowUserToDeleteRows = false;
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhong.Location = new Point(30, 360);
            dgvPhong.MultiSelect = false;
            dgvPhong.ReadOnly = true;
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.Size = new Size(910, 310);
            dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;

            // Form
            ClientSize = new Size(980, 710);

            Controls.Add(lblMaPhong);
            Controls.Add(txtMaPhong);
            Controls.Add(lblSoPhong);
            Controls.Add(txtSoPhong);
            Controls.Add(lblTang);
            Controls.Add(txtTang);
            Controls.Add(lblLoaiPhong);
            Controls.Add(cboLoaiPhong);
            Controls.Add(lblTinhTrang);
            Controls.Add(cboTinhTrang);
            Controls.Add(lblHinhAnh);
            Controls.Add(txtHinhAnh);
            Controls.Add(btnChonAnh);
            Controls.Add(picHinhAnh);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnLoaiPhong);

            Controls.Add(lblLocLoai);
            Controls.Add(cboLocLoai);
            Controls.Add(lblLocTinhTrang);
            Controls.Add(cboLocTinhTrang);
            Controls.Add(btnLoc);

            Controls.Add(dgvPhong);

            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý phòng - Sunrise Homestay";
            Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMaPhong;
        private Label lblSoPhong;
        private Label lblTang;
        private Label lblLoaiPhong;
        private Label lblTinhTrang;
        private Label lblHinhAnh;
        private Label lblLocLoai;
        private Label lblLocTinhTrang;

        private TextBox txtMaPhong;
        private TextBox txtSoPhong;
        private TextBox txtTang;
        private TextBox txtHinhAnh;

        private ComboBox cboLoaiPhong;
        private ComboBox cboTinhTrang;
        private ComboBox cboLocLoai;
        private ComboBox cboLocTinhTrang;

        private PictureBox picHinhAnh;

        private Button btnChonAnh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnLoaiPhong;
        private Button btnLoc;

        private DataGridView dgvPhong;
    }
}