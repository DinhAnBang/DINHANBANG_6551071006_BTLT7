using CAU4.Models;
using Microsoft.EntityFrameworkCore;

namespace CAU4
{
    public partial class Form1 : Form
    {
        private readonly CAU4_DBContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new CAU4_DBContext();
        }

        // =============================================
        // LOAD FORM
        // =============================================
        private async void Form1_Load(object sender, EventArgs e)
        {
            LoadTrangThai();

            await LoadBacSi();
            await LoadData();

            ClearInput();
        }

        // =============================================
        // TRẠNG THÁI
        // =============================================
        private void LoadTrangThai()
        {
            cboTrangThai.Items.Clear();

            cboTrangThai.Items.Add("Chờ khám");
            cboTrangThai.Items.Add("Đã khám");
            cboTrangThai.Items.Add("Đã hủy");

            cboTrangThai.SelectedIndex = 0;
        }

        // =============================================
        // LOAD BÁC SĨ
        // =============================================
        private async Task LoadBacSi()
        {
            var danhSach = await _context.BacSis
                .AsNoTracking()
                .OrderBy(x => x.HoTen)
                .ToListAsync();

            // ComboBox nhập liệu
            var dsNhap = danhSach.Select(x => new
            {
                x.MaBs,

                HienThi =
                    "BS. " +
                    x.HoTen +
                    " - " +
                    (x.ChuyenKhoa ?? "")
            }).ToList();

            cboBacSi.DataSource = dsNhap;
            cboBacSi.DisplayMember = "HienThi";
            cboBacSi.ValueMember = "MaBs";

            // ComboBox tìm kiếm
            var dsTim = new List<BacSiTimKiem>
            {
                new BacSiTimKiem
                {
                    MaBs = 0,
                    HienThi = "Tất cả bác sĩ"
                }
            };

            foreach (var bs in danhSach)
            {
                dsTim.Add(new BacSiTimKiem
                {
                    MaBs = bs.MaBs,

                    HienThi =
                        "BS. " +
                        bs.HoTen +
                        " - " +
                        (bs.ChuyenKhoa ?? "")
                });
            }

            cboTimBacSi.DataSource = dsTim;
            cboTimBacSi.DisplayMember = "HienThi";
            cboTimBacSi.ValueMember = "MaBs";
        }

        // =============================================
        // LOAD LỊCH KHÁM
        // =============================================
        private async Task LoadData()
        {
            var danhSach = await _context.LichKhams
                .AsNoTracking()
                .Include(x => x.MaBsNavigation)
                .OrderBy(x => x.NgayKham)
                .ThenBy(x => x.GioKham)
                .ToListAsync();

            HienThiDanhSach(danhSach);
        }

        // =============================================
        // HIỂN THỊ DATAGRIDVIEW
        // =============================================
        private void HienThiDanhSach(List<LichKham> danhSach)
        {
            var hienThi = danhSach.Select(x => new
            {
                x.MaLich,

                x.TenBenhNhan,

                x.Sdt,

                NgayKham = x.NgayKham.HasValue
                    ? x.NgayKham.Value.ToString("dd/MM/yyyy")
                    : "",

                GioKham = x.GioKham.HasValue
                    ? x.GioKham.Value.ToString("HH:mm")
                    : "",

                BacSi = x.MaBsNavigation != null
                    ? "BS. " + x.MaBsNavigation.HoTen
                    : "",

                ChuyenKhoa = x.MaBsNavigation != null
                    ? x.MaBsNavigation.ChuyenKhoa
                    : "",

                x.TrangThai,

                x.MaBs,

                // Dữ liệu thật dùng khi chọn dòng
                NgayKhamValue = x.NgayKham,
                GioKhamValue = x.GioKham

            }).ToList();

            dgvLichKham.DataSource = hienThi;

            if (dgvLichKham.Columns["MaLich"] != null)
                dgvLichKham.Columns["MaLich"].HeaderText = "Mã lịch";

            if (dgvLichKham.Columns["TenBenhNhan"] != null)
                dgvLichKham.Columns["TenBenhNhan"].HeaderText =
                    "Tên bệnh nhân";

            if (dgvLichKham.Columns["Sdt"] != null)
                dgvLichKham.Columns["Sdt"].HeaderText = "SĐT";

            if (dgvLichKham.Columns["NgayKham"] != null)
                dgvLichKham.Columns["NgayKham"].HeaderText =
                    "Ngày khám";

            if (dgvLichKham.Columns["GioKham"] != null)
                dgvLichKham.Columns["GioKham"].HeaderText =
                    "Giờ khám";

            if (dgvLichKham.Columns["BacSi"] != null)
                dgvLichKham.Columns["BacSi"].HeaderText = "Bác sĩ";

            if (dgvLichKham.Columns["ChuyenKhoa"] != null)
                dgvLichKham.Columns["ChuyenKhoa"].HeaderText =
                    "Chuyên khoa";

            if (dgvLichKham.Columns["TrangThai"] != null)
                dgvLichKham.Columns["TrangThai"].HeaderText =
                    "Trạng thái";

            // Các cột chỉ phục vụ xử lý
            if (dgvLichKham.Columns["MaBs"] != null)
                dgvLichKham.Columns["MaBs"].Visible = false;

            if (dgvLichKham.Columns["NgayKhamValue"] != null)
                dgvLichKham.Columns["NgayKhamValue"].Visible = false;

            if (dgvLichKham.Columns["GioKhamValue"] != null)
                dgvLichKham.Columns["GioKhamValue"].Visible = false;

            dgvLichKham.ClearSelection();
            dgvLichKham.CurrentCell = null;
        }

        // =============================================
        // CLEAR
        // =============================================
        private void ClearInput()
        {
            txtTenBenhNhan.Clear();
            txtSdt.Clear();

            dtpNgayKham.Value = DateTime.Today;

            dtpGioKham.Value =
                DateTime.Today.AddHours(8);

            if (cboBacSi.Items.Count > 0)
                cboBacSi.SelectedIndex = 0;

            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;

            dgvLichKham.ClearSelection();
            dgvLichKham.CurrentCell = null;

            txtTenBenhNhan.Focus();
        }

        // =============================================
        // VALIDATE
        // =============================================
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
            {
                MessageBox.Show(
                    "Tên bệnh nhân không được để trống!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTenBenhNhan.Focus();
                return false;
            }

            if (cboBacSi.SelectedValue == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn bác sĩ!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            if (dtpNgayKham.Value.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "Không được đặt lịch khám vào ngày trong quá khứ!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                dtpNgayKham.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtSdt.Text))
            {
                string sdt = txtSdt.Text.Trim();

                if (!sdt.All(char.IsDigit))
                {
                    MessageBox.Show(
                        "Số điện thoại chỉ được chứa chữ số!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtSdt.Focus();
                    return false;
                }
            }

            return true;
        }

        // =============================================
        // SELECTION CHANGED
        // Không query DB lần nữa
        // =============================================
        private void dgvLichKham_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (dgvLichKham.CurrentRow == null)
                return;

            DataGridViewRow row = dgvLichKham.CurrentRow;

            txtTenBenhNhan.Text =
                row.Cells["TenBenhNhan"].Value?.ToString() ?? "";

            txtSdt.Text =
                row.Cells["Sdt"].Value?.ToString() ?? "";

            // Ngày khám
            object? ngayObj =
                row.Cells["NgayKhamValue"].Value;

            if (ngayObj is DateOnly ngay)
            {
                dtpNgayKham.Value =
                    ngay.ToDateTime(TimeOnly.MinValue);
            }

            // Giờ khám
            object? gioObj =
                row.Cells["GioKhamValue"].Value;

            if (gioObj is TimeOnly gio)
            {
                dtpGioKham.Value =
                    DateTime.Today.Add(gio.ToTimeSpan());
            }

            // Bác sĩ
            if (row.Cells["MaBs"].Value != null)
            {
                int maBs =
                    Convert.ToInt32(
                        row.Cells["MaBs"].Value
                    );

                cboBacSi.SelectedValue = maBs;
            }

            // Trạng thái
            string trangThai =
                row.Cells["TrangThai"].Value?.ToString() ?? "";

            if (!string.IsNullOrWhiteSpace(trangThai))
                cboTrangThai.SelectedItem = trangThai;
        }

        // =============================================
        // THÊM
        // =============================================
        private async void btnThem_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                LichKham lich = new LichKham
                {
                    TenBenhNhan =
                        txtTenBenhNhan.Text.Trim(),

                    Sdt = string.IsNullOrWhiteSpace(txtSdt.Text)
                        ? null
                        : txtSdt.Text.Trim(),

                    NgayKham =
                        DateOnly.FromDateTime(
                            dtpNgayKham.Value
                        ),

                    GioKham =
                        TimeOnly.FromDateTime(
                            dtpGioKham.Value
                        ),

                    MaBs =
                        Convert.ToInt32(
                            cboBacSi.SelectedValue
                        ),

                    TrangThai =
                        cboTrangThai.SelectedItem?.ToString()
                };

                _context.LichKhams.Add(lich);

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Thêm lịch khám thành công!",
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
                    "Thêm lịch khám thất bại!\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =============================================
        // SỬA
        // =============================================
        private async void btnSua_Click(
            object sender,
            EventArgs e)
        {
            if (dgvLichKham.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn lịch khám cần sửa!"
                );

                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                int maLich =
                    Convert.ToInt32(
                        dgvLichKham.CurrentRow
                            .Cells["MaLich"].Value
                    );

                var lich =
                    await _context.LichKhams
                        .FindAsync(maLich);

                if (lich == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy lịch khám!"
                    );

                    return;
                }

                lich.TenBenhNhan =
                    txtTenBenhNhan.Text.Trim();

                lich.Sdt =
                    string.IsNullOrWhiteSpace(txtSdt.Text)
                    ? null
                    : txtSdt.Text.Trim();

                lich.NgayKham =
                    DateOnly.FromDateTime(
                        dtpNgayKham.Value
                    );

                lich.GioKham =
                    TimeOnly.FromDateTime(
                        dtpGioKham.Value
                    );

                lich.MaBs =
                    Convert.ToInt32(
                        cboBacSi.SelectedValue
                    );

                lich.TrangThai =
                    cboTrangThai.SelectedItem?.ToString();

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Cập nhật lịch khám thành công!",
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
                    "Cập nhật lịch khám thất bại!\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =============================================
        // XÓA
        // =============================================
        private async void btnXoa_Click(
            object sender,
            EventArgs e)
        {
            if (dgvLichKham.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn lịch khám cần xóa!"
                );

                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lịch khám này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                int maLich =
                    Convert.ToInt32(
                        dgvLichKham.CurrentRow
                            .Cells["MaLich"].Value
                    );

                var lich =
                    await _context.LichKhams
                        .FindAsync(maLich);

                if (lich == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy lịch khám!"
                    );

                    return;
                }

                _context.LichKhams.Remove(lich);

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Xóa lịch khám thành công!",
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
                    "Xóa lịch khám thất bại!\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =============================================
        // LÀM MỚI
        // =============================================
        private async void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            ClearInput();

            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value =
                DateTime.Today.AddMonths(1);

            if (cboTimBacSi.Items.Count > 0)
                cboTimBacSi.SelectedIndex = 0;

            await LoadData();
        }

        // =============================================
        // TÌM KIẾM
        // =============================================
        private async void btnTimKiem_Click(
            object sender,
            EventArgs e)
        {
            if (dtpTuNgay.Value.Date >
                dtpDenNgay.Value.Date)
            {
                MessageBox.Show(
                    "Từ ngày không được lớn hơn Đến ngày!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DateOnly tuNgay =
                DateOnly.FromDateTime(
                    dtpTuNgay.Value
                );

            DateOnly denNgay =
                DateOnly.FromDateTime(
                    dtpDenNgay.Value
                );

            int maBs = 0;

            if (cboTimBacSi.SelectedValue != null)
            {
                maBs =
                    Convert.ToInt32(
                        cboTimBacSi.SelectedValue
                    );
            }

            var query = _context.LichKhams
                .AsNoTracking()
                .Include(x => x.MaBsNavigation)
                .AsQueryable();

            // Khoảng ngày
            query = query.Where(x =>
                x.NgayKham >= tuNgay &&
                x.NgayKham <= denNgay
            );

            // Kết hợp bác sĩ
            if (maBs != 0)
            {
                query = query.Where(
                    x => x.MaBs == maBs
                );
            }

            var ketQua = await query
                .OrderBy(x => x.NgayKham)
                .ThenBy(x => x.GioKham)
                .ToListAsync();

            HienThiDanhSach(ketQua);

            if (ketQua.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy lịch khám phù hợp!",
                    "Kết quả",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // =============================================
        // QUẢN LÝ BÁC SĨ
        // =============================================
        private async void btnQuanLyBacSi_Click(
            object sender,
            EventArgs e)
        {
            using FormBacSi form =
                new FormBacSi();

            form.ShowDialog();

            // Bác sĩ có thể vừa được thêm/sửa
            await LoadBacSi();
            await LoadData();

            ClearInput();
        }

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }

    // =============================================
    // CLASS PHỤ CHO COMBOBOX TÌM BÁC SĨ
    // =============================================
    public class BacSiTimKiem
    {
        public int MaBs { get; set; }

        public string HienThi { get; set; } = "";
    }
}