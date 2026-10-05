using CAU1.Models;
using Microsoft.EntityFrameworkCore;

namespace CAU1
{
    public partial class Form1 : Form
    {
        private readonly knowledgeWebContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new knowledgeWebContext();
        }

        // Load Form
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadData();
            ClearInput();
        }

        // Load dữ liệu từ database lên DataGridView
        private async Task LoadData()
        {
            try
            {
                var danhSach = await _context.TheLoaiSaches
                    .AsNoTracking()
                    .OrderBy(x => x.MaTl)
                    .ToListAsync();

                dgvTheLoaiSach.DataSource = danhSach;

                // Đổi tên cột hiển thị
                if (dgvTheLoaiSach.Columns["MaTl"] != null)
                    dgvTheLoaiSach.Columns["MaTl"].HeaderText = "Mã thể loại";

                if (dgvTheLoaiSach.Columns["TenTheLoai"] != null)
                    dgvTheLoaiSach.Columns["TenTheLoai"].HeaderText = "Tên thể loại";

                if (dgvTheLoaiSach.Columns["MoTa"] != null)
                    dgvTheLoaiSach.Columns["MoTa"].HeaderText = "Mô tả";

                if (dgvTheLoaiSach.Columns["SoLuongSach"] != null)
                    dgvTheLoaiSach.Columns["SoLuongSach"].HeaderText = "Số lượng sách";

                if (dgvTheLoaiSach.Columns["NgayTao"] != null)
                    dgvTheLoaiSach.Columns["NgayTao"].HeaderText = "Ngày tạo";

                dgvTheLoaiSach.ClearSelection();
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

        // Xóa dữ liệu trên các ô nhập
        private void ClearInput()
        {
            txtMaTL.Clear();
            txtTenTheLoai.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();

            lblNgayTao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            dgvTheLoaiSach.ClearSelection();

            txtTenTheLoai.Focus();
        }

        // Kiểm tra tên thể loại có bị bỏ trống hay không
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenTheLoai.Text))
            {
                MessageBox.Show(
                    "Tên thể loại không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTenTheLoai.Focus();
                return false;
            }

            return true;
        }

        // Chọn một dòng -> đổ dữ liệu lên các control
        private void dgvTheLoaiSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheLoaiSach.CurrentRow == null ||
                dgvTheLoaiSach.CurrentRow.DataBoundItem == null)
            {
                return;
            }

            if (dgvTheLoaiSach.CurrentRow.DataBoundItem is TheLoaiSach item)
            {
                txtMaTL.Text = item.MaTl.ToString();
                txtTenTheLoai.Text = item.TenTheLoai;
                txtMoTa.Text = item.MoTa ?? "";

                lblNgayTao.Text = item.NgayTao.HasValue
                    ? item.NgayTao.Value.ToString("dd/MM/yyyy HH:mm")
                    : "";
            }
        }

        // THÊM
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string tenTheLoai = txtTenTheLoai.Text.Trim();

            try
            {
                // Kiểm tra trùng tên
                bool daTonTai = await _context.TheLoaiSaches
                    .AnyAsync(x => x.TenTheLoai == tenTheLoai);

                if (daTonTai)
                {
                    MessageBox.Show(
                        "Tên thể loại đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtTenTheLoai.Focus();
                    return;
                }

                var theLoai = new TheLoaiSach
                {
                    TenTheLoai = tenTheLoai,
                    MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text)
                        ? null
                        : txtMoTa.Text.Trim(),

                    SoLuongSach = 0,
                    NgayTao = DateTime.Now
                };

                _context.Add(theLoai);
                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Thêm thể loại thành công!",
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
                    "Thêm thể loại thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // SỬA
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTL.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn thể loại cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!ValidateInput())
                return;

            int maTL = int.Parse(txtMaTL.Text);
            string tenTheLoai = txtTenTheLoai.Text.Trim();

            try
            {
                // Kiểm tra tên có trùng với một thể loại khác không
                bool daTonTai = await _context.TheLoaiSaches
                    .AnyAsync(x =>
                        x.TenTheLoai == tenTheLoai &&
                        x.MaTl != maTL);

                if (daTonTai)
                {
                    MessageBox.Show(
                        "Tên thể loại đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtTenTheLoai.Focus();
                    return;
                }

                var theLoai = await _context.TheLoaiSaches
                    .FindAsync(maTL);

                if (theLoai == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy thể loại cần sửa!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                theLoai.TenTheLoai = tenTheLoai;

                theLoai.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text)
                    ? null
                    : txtMoTa.Text.Trim();

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Cập nhật thể loại thành công!",
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
                    "Cập nhật thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // XÓA
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTL.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn thể loại cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int maTL = int.Parse(txtMaTL.Text);

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa thể loại này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                var theLoai = await _context.TheLoaiSaches
                    .FindAsync(maTL);

                if (theLoai == null)
                {
                    MessageBox.Show(
                        "Không tìm thấy thể loại cần xóa!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                _context.TheLoaiSaches.Remove(theLoai);

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Xóa thể loại thành công!",
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
                    "Không thể xóa thể loại vì đang được dữ liệu khác tham chiếu!",
                    "Lỗi ràng buộc dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Xóa thể loại thất bại!\n" + ex.Message,
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
            string tuKhoa = txtTimKiem.Text.Trim();

            try
            {
                // Nếu không nhập gì thì hiển thị toàn bộ
                if (string.IsNullOrWhiteSpace(tuKhoa))
                {
                    await LoadData();
                    return;
                }

                // LINQ Where + Contains theo yêu cầu đề
                var ketQua = await _context.TheLoaiSaches
                    .AsNoTracking()
                    .Where(x => x.TenTheLoai.Contains(tuKhoa))
                    .OrderBy(x => x.MaTl)
                    .ToListAsync();

                dgvTheLoaiSach.DataSource = ketQua;
                dgvTheLoaiSach.ClearSelection();

                if (ketQua.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy thể loại phù hợp!",
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }
}