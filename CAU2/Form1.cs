using CAU2.Models;
using Microsoft.EntityFrameworkCore;

namespace CAU2
{
    public partial class Form1 : Form
    {
        private readonly CAU2_DBContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new CAU2_DBContext();
        }

        // Load form
        private async void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            await LoadData();
            ClearInput();
        }

        // Nạp dữ liệu cho ComboBox
        private void LoadComboBox()
        {
            cboHangThanhVien.Items.Clear();
            cboHangThanhVien.Items.Add("Basic");
            cboHangThanhVien.Items.Add("VIP");
            cboHangThanhVien.Items.Add("Premium");
            cboHangThanhVien.SelectedIndex = 0;

            cboTimHang.Items.Clear();
            cboTimHang.Items.Add("Tất cả");
            cboTimHang.Items.Add("Basic");
            cboTimHang.Items.Add("VIP");
            cboTimHang.Items.Add("Premium");
            cboTimHang.SelectedIndex = 0;
        }

        // Load dữ liệu hội viên
        private async Task LoadData()
        {
            try
            {
                var danhSach = await _context.HoiViens
                    .AsNoTracking()
                    .OrderBy(x => x.MaHv)
                    .ToListAsync();

                dgvHoiVien.DataSource = danhSach;

                DinhDangDataGridView();

                dgvHoiVien.ClearSelection();
                dgvHoiVien.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Định dạng DataGridView
        private void DinhDangDataGridView()
        {
            if (dgvHoiVien.Columns["MaHv"] != null)
                dgvHoiVien.Columns["MaHv"].HeaderText = "Mã HV";

            if (dgvHoiVien.Columns["HoTen"] != null)
                dgvHoiVien.Columns["HoTen"].HeaderText = "Họ tên";

            if (dgvHoiVien.Columns["GioiTinh"] != null)
                dgvHoiVien.Columns["GioiTinh"].HeaderText = "Giới tính";

            if (dgvHoiVien.Columns["NgaySinh"] != null)
                dgvHoiVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";

            if (dgvHoiVien.Columns["Sdt"] != null)
                dgvHoiVien.Columns["Sdt"].HeaderText = "SĐT";

            if (dgvHoiVien.Columns["Email"] != null)
                dgvHoiVien.Columns["Email"].HeaderText = "Email";

            if (dgvHoiVien.Columns["HangThanhVien"] != null)
                dgvHoiVien.Columns["HangThanhVien"].HeaderText = "Hạng thành viên";

            if (dgvHoiVien.Columns["NgayDangKy"] != null)
                dgvHoiVien.Columns["NgayDangKy"].HeaderText = "Ngày đăng ký";

            if (dgvHoiVien.Columns["TrangThai"] != null)
                dgvHoiVien.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        // Làm sạch các ô nhập
        private void ClearInput()
        {
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();

            rdoNam.Checked = true;
            rdoNu.Checked = false;

            dtpNgaySinh.Value = DateTime.Today.AddYears(-15);

            if (cboHangThanhVien.Items.Count > 0)
                cboHangThanhVien.SelectedIndex = 0;

            chkTrangThai.Checked = true;

            dgvHoiVien.ClearSelection();
            dgvHoiVien.CurrentCell = null;

            txtHoTen.Focus();
        }

        // Validate dữ liệu
        private bool ValidateInput()
        {
            // Họ tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show(
                    "Họ tên không được để trống!",
                    "Lỗi họ tên",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtHoTen.Focus();
                return false;
            }

            // Số điện thoại
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show(
                    "Số điện thoại không được để trống!",
                    "Lỗi số điện thoại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSDT.Focus();
                return false;
            }

            if (!sdt.All(char.IsDigit))
            {
                MessageBox.Show(
                    "Số điện thoại chỉ được chứa chữ số!",
                    "Lỗi số điện thoại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSDT.Focus();
                return false;
            }

            if (sdt.Length < 9 || sdt.Length > 11)
            {
                MessageBox.Show(
                    "Số điện thoại phải có từ 9 đến 11 chữ số!",
                    "Lỗi số điện thoại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtSDT.Focus();
                return false;
            }

            // Email
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Email không được để trống!",
                    "Lỗi Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();
                return false;
            }

            if (!email.Contains('@'))
            {
                MessageBox.Show(
                    "Email phải chứa ký tự '@'!",
                    "Lỗi Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtEmail.Focus();
                return false;
            }

            // Tuổi
            int tuoi = TinhTuoi(dtpNgaySinh.Value);

            if (tuoi < 15)
            {
                MessageBox.Show(
                    "Hội viên phải từ 15 tuổi trở lên!",
                    "Lỗi ngày sinh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                dtpNgaySinh.Focus();
                return false;
            }

            // Hạng thành viên
            if (cboHangThanhVien.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn hạng thành viên!",
                    "Lỗi hạng thành viên",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cboHangThanhVien.Focus();
                return false;
            }

            return true;
        }

        // Tính tuổi
        private int TinhTuoi(DateTime ngaySinh)
        {
            DateTime homNay = DateTime.Today;

            int tuoi = homNay.Year - ngaySinh.Year;

            if (ngaySinh.Date > homNay.AddYears(-tuoi))
                tuoi--;

            return tuoi;
        }

        // Chọn dòng trong DataGridView
        private void dgvHoiVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoiVien.CurrentRow == null)
                return;

            if (dgvHoiVien.CurrentRow.DataBoundItem is not HoiVien hv)
                return;

            txtHoTen.Text = hv.HoTen ?? "";
            txtSDT.Text = hv.Sdt ?? "";
            txtEmail.Text = hv.Email ?? "";

            // Giới tính
            if (hv.GioiTinh == true)
            {
                rdoNam.Checked = true;
                rdoNu.Checked = false;
            }
            else
            {
                rdoNam.Checked = false;
                rdoNu.Checked = true;
            }

            // Ngày sinh
            if (hv.NgaySinh.HasValue)
            {
                dtpNgaySinh.Value =
                    hv.NgaySinh.Value.ToDateTime(TimeOnly.MinValue);
            }

            // Hạng thành viên
            if (!string.IsNullOrWhiteSpace(hv.HangThanhVien))
            {
                cboHangThanhVien.SelectedItem = hv.HangThanhVien;
            }

            // Trạng thái
            chkTrangThai.Checked = hv.TrangThai == true;
        }

        // THÊM
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                HoiVien hoiVien = new HoiVien
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = rdoNam.Checked,
                    NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                    Sdt = txtSDT.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    HangThanhVien = cboHangThanhVien.SelectedItem?.ToString(),
                    NgayDangKy = DateTime.Now,
                    TrangThai = chkTrangThai.Checked
                };

                _context.HoiViens.Add(hoiVien);

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Thêm hội viên thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                await LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Thêm hội viên thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // SỬA
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHoiVien.CurrentRow == null ||
                dgvHoiVien.CurrentRow.DataBoundItem is not HoiVien selected)
            {
                MessageBox.Show(
                    "Vui lòng chọn hội viên cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                var hoiVien = await _context.HoiViens
                    .FindAsync(selected.MaHv);

                if (hoiVien == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy hội viên cần sửa!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                hoiVien.HoTen = txtHoTen.Text.Trim();
                hoiVien.GioiTinh = rdoNam.Checked;
                hoiVien.NgaySinh =
                    DateOnly.FromDateTime(dtpNgaySinh.Value);
                hoiVien.Sdt = txtSDT.Text.Trim();
                hoiVien.Email = txtEmail.Text.Trim();
                hoiVien.HangThanhVien =
                    cboHangThanhVien.SelectedItem?.ToString();
                hoiVien.TrangThai = chkTrangThai.Checked;

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Cập nhật hội viên thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                await LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Cập nhật hội viên thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // XÓA
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoiVien.CurrentRow == null ||
                dgvHoiVien.CurrentRow.DataBoundItem is not HoiVien selected)
            {
                MessageBox.Show(
                    "Vui lòng chọn hội viên cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hội viên \"{selected.HoTen}\" không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                var hoiVien = await _context.HoiViens
                    .FindAsync(selected.MaHv);

                if (hoiVien == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy hội viên cần xóa!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                _context.HoiViens.Remove(hoiVien);

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Xóa hội viên thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                await LoadData();
                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể xóa hội viên do ràng buộc dữ liệu!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Xóa hội viên thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // LÀM MỚI
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            await LoadData();
        }

        // TÌM KIẾM
        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string hoTen = txtTimHoTen.Text.Trim();
                string hang =
                    cboTimHang.SelectedItem?.ToString() ?? "Tất cả";

                var query = _context.HoiViens
                    .AsNoTracking()
                    .AsQueryable();

                // Tìm theo họ tên
                if (!string.IsNullOrWhiteSpace(hoTen))
                {
                    query = query.Where(
                        x => x.HoTen.Contains(hoTen)
                    );
                }

                // Tìm theo hạng thành viên
                if (hang != "Tất cả")
                {
                    query = query.Where(
                        x => x.HangThanhVien == hang
                    );
                }

                var ketQua = await query
                    .OrderBy(x => x.MaHv)
                    .ToListAsync();

                dgvHoiVien.DataSource = ketQua;

                DinhDangDataGridView();

                dgvHoiVien.ClearSelection();
                dgvHoiVien.CurrentCell = null;

                if (ketQua.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy hội viên phù hợp!",
                        "Kết quả tìm kiếm",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Tìm kiếm thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Đóng Form thì giải phóng DbContext
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }
}