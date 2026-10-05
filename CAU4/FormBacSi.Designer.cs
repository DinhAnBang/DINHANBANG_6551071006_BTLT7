using static System.Net.Mime.MediaTypeNames;

namespace CAU4
{
    partial class FormBacSi
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
            lblMaBs = new Label();
            lblHoTen = new Label();
            lblChuyenKhoa = new Label();
            lblSdt = new Label();

            txtMaBs = new TextBox();
            txtHoTen = new TextBox();
            txtChuyenKhoa = new TextBox();
            txtSdt = new TextBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnDong = new Button();

            dgvBacSi = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvBacSi).BeginInit();
            SuspendLayout();

            // Mã bác sĩ
            lblMaBs.AutoSize = true;
            lblMaBs.Location = new Point(30, 30);
            lblMaBs.Text = "Mã bác sĩ";

            txtMaBs.Location = new Point(150, 27);
            txtMaBs.ReadOnly = true;
            txtMaBs.Size = new Size(280, 27);

            // Họ tên
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(30, 75);
            lblHoTen.Text = "Họ tên";

            txtHoTen.Location = new Point(150, 72);
            txtHoTen.Size = new Size(280, 27);

            // Chuyên khoa
            lblChuyenKhoa.AutoSize = true;
            lblChuyenKhoa.Location = new Point(30, 120);
            lblChuyenKhoa.Text = "Chuyên khoa";

            txtChuyenKhoa.Location = new Point(150, 117);
            txtChuyenKhoa.Size = new Size(280, 27);

            // SĐT
            lblSdt.AutoSize = true;
            lblSdt.Location = new Point(30, 165);
            lblSdt.Text = "Số điện thoại";

            txtSdt.Location = new Point(150, 162);
            txtSdt.Size = new Size(280, 27);

            // Buttons
            btnThem.Location = new Point(500, 27);
            btnThem.Size = new Size(110, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(500, 72);
            btnSua.Size = new Size(110, 35);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(500, 117);
            btnXoa.Size = new Size(110, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(500, 162);
            btnLamMoi.Size = new Size(110, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            btnDong.Location = new Point(630, 162);
            btnDong.Size = new Size(110, 35);
            btnDong.Text = "Đóng";
            btnDong.Click += btnDong_Click;

            // Grid
            dgvBacSi.AllowUserToAddRows = false;
            dgvBacSi.AllowUserToDeleteRows = false;
            dgvBacSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBacSi.Location = new Point(30, 230);
            dgvBacSi.MultiSelect = false;
            dgvBacSi.ReadOnly = true;
            dgvBacSi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBacSi.Size = new Size(710, 300);
            dgvBacSi.SelectionChanged += dgvBacSi_SelectionChanged;

            // Form
            ClientSize = new Size(780, 570);

            Controls.Add(lblMaBs);
            Controls.Add(txtMaBs);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblChuyenKhoa);
            Controls.Add(txtChuyenKhoa);
            Controls.Add(lblSdt);
            Controls.Add(txtSdt);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnDong);

            Controls.Add(dgvBacSi);

            Name = "FormBacSi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Bác sĩ - An Khang Clinic";
            Load += FormBacSi_Load;

            ((System.ComponentModel.ISupportInitialize)dgvBacSi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMaBs;
        private Label lblHoTen;
        private Label lblChuyenKhoa;
        private Label lblSdt;

        private TextBox txtMaBs;
        private TextBox txtHoTen;
        private TextBox txtChuyenKhoa;
        private TextBox txtSdt;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnDong;

        private DataGridView dgvBacSi;
    }
}