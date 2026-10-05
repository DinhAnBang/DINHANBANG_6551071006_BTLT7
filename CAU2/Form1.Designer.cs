namespace CAU2
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
            lblHoTen = new Label();
            lblSDT = new Label();
            lblEmail = new Label();
            lblNgaySinh = new Label();
            lblHangThanhVien = new Label();
            lblTimHoTen = new Label();
            lblTimHang = new Label();

            txtHoTen = new TextBox();
            txtSDT = new TextBox();
            txtEmail = new TextBox();
            txtTimHoTen = new TextBox();

            grpGioiTinh = new GroupBox();
            rdoNam = new RadioButton();
            rdoNu = new RadioButton();

            dtpNgaySinh = new DateTimePicker();

            cboHangThanhVien = new ComboBox();
            cboTimHang = new ComboBox();

            chkTrangThai = new CheckBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnTimKiem = new Button();

            dgvHoiVien = new DataGridView();

            grpGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).BeginInit();
            SuspendLayout();

            // =========================
            // HỌ TÊN
            // =========================
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(30, 35);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(52, 20);
            lblHoTen.Text = "Họ tên";

            txtHoTen.Location = new Point(150, 32);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(270, 27);

            // =========================
            // SỐ ĐIỆN THOẠI
            // =========================
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(30, 78);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(97, 20);
            lblSDT.Text = "Số điện thoại";

            txtSDT.Location = new Point(150, 75);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(270, 27);

            // =========================
            // EMAIL
            // =========================
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 121);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.Text = "Email";

            txtEmail.Location = new Point(150, 118);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(270, 27);

            // =========================
            // GIỚI TÍNH
            // =========================
            grpGioiTinh.Controls.Add(rdoNam);
            grpGioiTinh.Controls.Add(rdoNu);
            grpGioiTinh.Location = new Point(470, 25);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(250, 80);
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";

            rdoNam.AutoSize = true;
            rdoNam.Checked = true;
            rdoNam.Location = new Point(35, 35);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(62, 24);
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;

            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(140, 35);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(49, 24);
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;

            // =========================
            // NGÀY SINH
            // =========================
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(30, 165);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(75, 20);
            lblNgaySinh.Text = "Ngày sinh";

            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(150, 162);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(270, 27);

            // =========================
            // HẠNG THÀNH VIÊN
            // =========================
            lblHangThanhVien.AutoSize = true;
            lblHangThanhVien.Location = new Point(30, 208);
            lblHangThanhVien.Name = "lblHangThanhVien";
            lblHangThanhVien.Size = new Size(115, 20);
            lblHangThanhVien.Text = "Hạng thành viên";

            cboHangThanhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHangThanhVien.FormattingEnabled = true;
            cboHangThanhVien.Location = new Point(150, 205);
            cboHangThanhVien.Name = "cboHangThanhVien";
            cboHangThanhVien.Size = new Size(270, 28);

            // =========================
            // TRẠNG THÁI
            // =========================
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = CheckState.Checked;
            chkTrangThai.Location = new Point(30, 255);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(138, 24);
            chkTrangThai.Text = "Đang hoạt động";
            chkTrangThai.UseVisualStyleBackColor = true;

            // =========================
            // BUTTON THÊM
            // =========================
            btnThem.Location = new Point(780, 32);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(130, 38);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;

            // =========================
            // BUTTON SỬA
            // =========================
            btnSua.Location = new Point(780, 80);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(130, 38);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;

            // =========================
            // BUTTON XÓA
            // =========================
            btnXoa.Location = new Point(780, 128);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(130, 38);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // =========================
            // BUTTON LÀM MỚI
            // =========================
            btnLamMoi.Location = new Point(780, 176);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(130, 38);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;

            // =========================
            // TÌM THEO HỌ TÊN
            // =========================
            lblTimHoTen.AutoSize = true;
            lblTimHoTen.Location = new Point(30, 315);
            lblTimHoTen.Name = "lblTimHoTen";
            lblTimHoTen.Size = new Size(86, 20);
            lblTimHoTen.Text = "Tìm họ tên";

            txtTimHoTen.Location = new Point(130, 312);
            txtTimHoTen.Name = "txtTimHoTen";
            txtTimHoTen.PlaceholderText = "Nhập họ tên...";
            txtTimHoTen.Size = new Size(260, 27);

            // =========================
            // TÌM THEO HẠNG
            // =========================
            lblTimHang.AutoSize = true;
            lblTimHang.Location = new Point(420, 315);
            lblTimHang.Name = "lblTimHang";
            lblTimHang.Size = new Size(115, 20);
            lblTimHang.Text = "Hạng thành viên";

            cboTimHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTimHang.FormattingEnabled = true;
            cboTimHang.Location = new Point(550, 312);
            cboTimHang.Name = "cboTimHang";
            cboTimHang.Size = new Size(170, 28);

            // =========================
            // BUTTON TÌM KIẾM
            // =========================
            btnTimKiem.Location = new Point(780, 307);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(130, 38);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;

            // =========================
            // DATAGRIDVIEW
            // =========================
            dgvHoiVien.AllowUserToAddRows = false;
            dgvHoiVien.AllowUserToDeleteRows = false;
            dgvHoiVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoiVien.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvHoiVien.Location = new Point(30, 370);
            dgvHoiVien.MultiSelect = false;
            dgvHoiVien.Name = "dgvHoiVien";
            dgvHoiVien.ReadOnly = true;
            dgvHoiVien.RowHeadersWidth = 51;
            dgvHoiVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoiVien.Size = new Size(880, 300);
            dgvHoiVien.SelectionChanged += dgvHoiVien_SelectionChanged;

            // =========================
            // FORM1
            // =========================
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 710);

            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);

            Controls.Add(lblSDT);
            Controls.Add(txtSDT);

            Controls.Add(lblEmail);
            Controls.Add(txtEmail);

            Controls.Add(grpGioiTinh);

            Controls.Add(lblNgaySinh);
            Controls.Add(dtpNgaySinh);

            Controls.Add(lblHangThanhVien);
            Controls.Add(cboHangThanhVien);

            Controls.Add(chkTrangThai);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(lblTimHoTen);
            Controls.Add(txtTimHoTen);

            Controls.Add(lblTimHang);
            Controls.Add(cboTimHang);

            Controls.Add(btnTimKiem);
            Controls.Add(dgvHoiVien);

            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Hội Viên Phòng Gym FitZone";
            Load += Form1_Load;

            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHoTen;
        private Label lblSDT;
        private Label lblEmail;
        private Label lblNgaySinh;
        private Label lblHangThanhVien;
        private Label lblTimHoTen;
        private Label lblTimHang;

        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtEmail;
        private TextBox txtTimHoTen;

        private GroupBox grpGioiTinh;
        private RadioButton rdoNam;
        private RadioButton rdoNu;

        private DateTimePicker dtpNgaySinh;

        private ComboBox cboHangThanhVien;
        private ComboBox cboTimHang;

        private CheckBox chkTrangThai;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;

        private DataGridView dgvHoiVien;
    }
}