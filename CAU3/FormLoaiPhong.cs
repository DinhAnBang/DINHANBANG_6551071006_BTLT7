using CAU3.Models;
using Microsoft.EntityFrameworkCore;

namespace CAU3
{
    public partial class FormLoaiPhong : Form
    {
        private readonly CAU3_DBContext _context;

        public FormLoaiPhong()
        {
            InitializeComponent();
            _context = new CAU3_DBContext();
        }

        private async void FormLoaiPhong_Load(object sender, EventArgs e)
        {
            await LoadData();
            ClearInput();
        }

        private async Task LoadData()
        {
            var danhSach = await _context.LoaiPhongs
                .AsNoTracking()
                .OrderBy(x => x.MaLoai)
                .ToListAsync();

            dgvLoaiPhong.DataSource = danhSach;

            // Không hiển thị navigation collection
            if (dgvLoaiPhong.Columns["Phongs"] != null)
                dgvLoaiPhong.Columns["Phongs"].Visible = false;

            if (dgvLoaiPhong.Columns["MaLoai"] != null)
                dgvLoaiPhong.Columns["MaLoai"].HeaderText = "Mã loại";

            if (dgvLoaiPhong.Columns["TenLoai"] != null)
                dgvLoaiPhong.Columns["TenLoai"].HeaderText = "Tên loại";

            if (dgvLoaiPhong.Columns["GiaMoiDem"] != null)
            {
                dgvLoaiPhong.Columns["GiaMoiDem"].HeaderText = "Giá mỗi đêm";
                dgvLoaiPhong.Columns["GiaMoiDem"].DefaultCellStyle.Format = "N0";
            }

            if (dgvLoaiPhong.Columns["MoTa"] != null)
                dgvLoaiPhong.Columns["MoTa"].HeaderText = "Mô tả";

            dgvLoaiPhong.ClearSelection();
            dgvLoaiPhong.CurrentCell = null;
        }

        private void ClearInput()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtGia.Clear();
            txtMoTa.Clear();

            dgvLoaiPhong.ClearSelection();
            dgvLoaiPhong.CurrentCell = null;

            txtTenLoai.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show(
                    "Tên loại phòng không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTenLoai.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGia.Text.Trim(), out decimal gia))
            {
                MessageBox.Show(
                    "Giá mỗi đêm phải là số!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtGia.Focus();
                return false;
            }

            if (gia < 0)
            {
                MessageBox.Show(
                    "Giá mỗi đêm không được nhỏ hơn 0!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtGia.Focus();
                return false;
            }

            return true;
        }

        private void dgvLoaiPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoaiPhong.CurrentRow?.DataBoundItem is not LoaiPhong lp)
                return;

            txtMaLoai.Text = lp.MaLoai.ToString();
            txtTenLoai.Text = lp.TenLoai ?? "";
            txtGia.Text = lp.GiaMoiDem?.ToString("0") ?? "";
            txtMoTa.Text = lp.MoTa ?? "";
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string tenLoai = txtTenLoai.Text.Trim();

            bool tonTai = await _context.LoaiPhongs
                .AnyAsync(x => x.TenLoai == tenLoai);

            if (tonTai)
            {
                MessageBox.Show(
                    "Tên loại phòng đã tồn tại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            var loaiPhong = new LoaiPhong
            {
                TenLoai = tenLoai,
                GiaMoiDem = decimal.Parse(txtGia.Text.Trim()),
                MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text)
                    ? null
                    : txtMoTa.Text.Trim()
            };

            _context.LoaiPhongs.Add(loaiPhong);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm loại phòng thành công!");

            await LoadData();
            ClearInput();
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần sửa!");
                return;
            }

            if (!ValidateInput())
                return;

            int maLoai = int.Parse(txtMaLoai.Text);

            var loaiPhong = await _context.LoaiPhongs.FindAsync(maLoai);

            if (loaiPhong == null)
            {
                MessageBox.Show("Không tìm thấy loại phòng!");
                return;
            }

            string tenLoai = txtTenLoai.Text.Trim();

            bool trungTen = await _context.LoaiPhongs
                .AnyAsync(x =>
                    x.TenLoai == tenLoai &&
                    x.MaLoai != maLoai);

            if (trungTen)
            {
                MessageBox.Show("Tên loại phòng đã tồn tại!");
                return;
            }

            loaiPhong.TenLoai = tenLoai;
            loaiPhong.GiaMoiDem = decimal.Parse(txtGia.Text.Trim());
            loaiPhong.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text)
                ? null
                : txtMoTa.Text.Trim();

            await _context.SaveChangesAsync();

            MessageBox.Show("Cập nhật loại phòng thành công!");

            await LoadData();
            ClearInput();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa!");
                return;
            }

            int maLoai = int.Parse(txtMaLoai.Text);

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa loại phòng này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                var loaiPhong = await _context.LoaiPhongs.FindAsync(maLoai);

                if (loaiPhong == null)
                {
                    MessageBox.Show("Không tìm thấy loại phòng!");
                    return;
                }

                _context.LoaiPhongs.Remove(loaiPhong);
                await _context.SaveChangesAsync();

                MessageBox.Show("Xóa loại phòng thành công!");

                await LoadData();
                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể xóa vì loại phòng đang được sử dụng bởi phòng!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            await LoadData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosed(e);
        }
    }
}