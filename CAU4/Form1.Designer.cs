namespace CAU4
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
            lblTenBenhNhan = new Label();
            lblSdt = new Label();
            lblNgayKham = new Label();
            lblGioKham = new Label();
            lblBacSi = new Label();
            lblTrangThai = new Label();

            txtTenBenhNhan = new TextBox();
            txtSdt = new TextBox();

            dtpNgayKham = new DateTimePicker();
            dtpGioKham = new DateTimePicker();

            cboBacSi = new ComboBox();
            cboTrangThai = new ComboBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnQuanLyBacSi = new Button();

            lblTuNgay = new Label();
            lblDenNgay = new Label();
            lblTimBacSi = new Label();

            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            cboTimBacSi = new ComboBox();
            btnTimKiem = new Button();

            dgvLichKham = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            SuspendLayout();

            // Tên bệnh nhân
            lblTenBenhNhan.AutoSize = true;
            lblTenBenhNhan.Location = new Point(30, 30);
            lblTenBenhNhan.Text = "Tên bệnh nhân";

            txtTenBenhNhan.Location = new Point(160, 27);
            txtTenBenhNhan.Size = new Size(260, 27);

            // SĐT
            lblSdt.AutoSize = true;
            lblSdt.Location = new Point(30, 75);
            lblSdt.Text = "Số điện thoại";

            txtSdt.Location = new Point(160, 72);
            txtSdt.Size = new Size(260, 27);

            // Ngày khám
            lblNgayKham.AutoSize = true;
            lblNgayKham.Location = new Point(30, 120);
            lblNgayKham.Text = "Ngày khám";

            dtpNgayKham.Format = DateTimePickerFormat.Short;
            dtpNgayKham.Location = new Point(160, 117);
            dtpNgayKham.Size = new Size(260, 27);

            // Giờ khám
            lblGioKham.AutoSize = true;
            lblGioKham.Location = new Point(460, 30);
            lblGioKham.Text = "Giờ khám";

            dtpGioKham.Format = DateTimePickerFormat.Time;
            dtpGioKham.ShowUpDown = true;
            dtpGioKham.Location = new Point(550, 27);
            dtpGioKham.Size = new Size(180, 27);

            // Bác sĩ
            lblBacSi.AutoSize = true;
            lblBacSi.Location = new Point(460, 75);
            lblBacSi.Text = "Bác sĩ";

            cboBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBacSi.Location = new Point(550, 72);
            cboBacSi.Size = new Size(330, 28);

            // Trạng thái
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(460, 120);
            lblTrangThai.Text = "Trạng thái";

            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Location = new Point(550, 117);
            cboTrangThai.Size = new Size(180, 28);

            // Buttons
            btnThem.Location = new Point(920, 27);
            btnThem.Size = new Size(110, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(1045, 27);
            btnSua.Size = new Size(110, 35);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(920, 72);
            btnXoa.Size = new Size(110, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(1045, 72);
            btnLamMoi.Size = new Size(110, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            btnQuanLyBacSi.Location = new Point(920, 117);
            btnQuanLyBacSi.Size = new Size(235, 35);
            btnQuanLyBacSi.Text = "Quản lý bác sĩ";
            btnQuanLyBacSi.Click += btnQuanLyBacSi_Click;

            // ============================
            // TÌM KIẾM
            // ============================

            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(30, 205);
            lblTuNgay.Text = "Từ ngày";

            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(105, 202);
            dtpTuNgay.Size = new Size(150, 27);

            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(280, 205);
            lblDenNgay.Text = "Đến ngày";

            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(370, 202);
            dtpDenNgay.Size = new Size(150, 27);

            lblTimBacSi.AutoSize = true;
            lblTimBacSi.Location = new Point(550, 205);
            lblTimBacSi.Text = "Bác sĩ";

            cboTimBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimBacSi.Location = new Point(610, 202);
            cboTimBacSi.Size = new Size(300, 28);

            btnTimKiem.Location = new Point(930, 198);
            btnTimKiem.Size = new Size(110, 35);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Click += btnTimKiem_Click;

            // ============================
            // DATAGRIDVIEW
            // ============================

            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AllowUserToDeleteRows = false;
            dgvLichKham.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvLichKham.Location = new Point(30, 270);
            dgvLichKham.MultiSelect = false;
            dgvLichKham.ReadOnly = true;

            dgvLichKham.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvLichKham.Size = new Size(1125, 380);

            dgvLichKham.SelectionChanged +=
                dgvLichKham_SelectionChanged;

            // Form
            ClientSize = new Size(1190, 690);

            Controls.Add(lblTenBenhNhan);
            Controls.Add(txtTenBenhNhan);

            Controls.Add(lblSdt);
            Controls.Add(txtSdt);

            Controls.Add(lblNgayKham);
            Controls.Add(dtpNgayKham);

            Controls.Add(lblGioKham);
            Controls.Add(dtpGioKham);

            Controls.Add(lblBacSi);
            Controls.Add(cboBacSi);

            Controls.Add(lblTrangThai);
            Controls.Add(cboTrangThai);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnQuanLyBacSi);

            Controls.Add(lblTuNgay);
            Controls.Add(dtpTuNgay);

            Controls.Add(lblDenNgay);
            Controls.Add(dtpDenNgay);

            Controls.Add(lblTimBacSi);
            Controls.Add(cboTimBacSi);

            Controls.Add(btnTimKiem);

            Controls.Add(dgvLichKham);

            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Lịch Khám Bệnh - An Khang Clinic";

            Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTenBenhNhan;
        private Label lblSdt;
        private Label lblNgayKham;
        private Label lblGioKham;
        private Label lblBacSi;
        private Label lblTrangThai;

        private TextBox txtTenBenhNhan;
        private TextBox txtSdt;

        private DateTimePicker dtpNgayKham;
        private DateTimePicker dtpGioKham;

        private ComboBox cboBacSi;
        private ComboBox cboTrangThai;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnQuanLyBacSi;

        private Label lblTuNgay;
        private Label lblDenNgay;
        private Label lblTimBacSi;

        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;

        private ComboBox cboTimBacSi;

        private Button btnTimKiem;

        private DataGridView dgvLichKham;
    }
}