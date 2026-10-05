using CAU4.Models;
using Microsoft.EntityFrameworkCore;

namespace CAU4
{
    public partial class FormBacSi : Form
    {
        private readonly CAU4_DBContext _context;

        public FormBacSi()
        {
            InitializeComponent();
            _context = new CAU4_DBContext();
        }

        private async void FormBacSi_Load(object sender, EventArgs e)
        {
            await LoadData();
            ClearInput();
        }

        private async Task LoadData()
        {
            var danhSach = await _context.BacSis
                .AsNoTracking()
                .OrderBy(x => x.MaBs)
                .ToListAsync();

            dgvBacSi.DataSource = danhSach;

            if (dgvBacSi.Columns["MaBs"] != null)
                dgvBacSi.Columns["MaBs"].HeaderText = "Mã bác sĩ";

            if (dgvBacSi.Columns["HoTen"] != null)
                dgvBacSi.Columns["HoTen"].HeaderText = "Họ tên";

            if (dgvBacSi.Columns["ChuyenKhoa"] != null)
                dgvBacSi.Columns["ChuyenKhoa"].HeaderText = "Chuyên khoa";

            if (dgvBacSi.Columns["Sdt"] != null)
                dgvBacSi.Columns["Sdt"].HeaderText = "SĐT";

            if (dgvBacSi.Columns["LichKhams"] != null)
                dgvBacSi.Columns["LichKhams"].Visible = false;

            dgvBacSi.ClearSelection();
            dgvBacSi.CurrentCell = null;
        }

        private void ClearInput()
        {
            txtMaBs.Clear();
            txtHoTen.Clear();
            txtChuyenKhoa.Clear();
            txtSdt.Clear();

            dgvBacSi.ClearSelection();
            dgvBacSi.CurrentCell = null;

            txtHoTen.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên bác sĩ không được để trống!");
                txtHoTen.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtSdt.Text))
            {
                string sdt = txtSdt.Text.Trim();

                if (!sdt.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại chỉ được chứa chữ số!");
                    txtSdt.Focus();
                    return false;
                }

                if (sdt.Length < 9 || sdt.Length > 15)
                {
                    MessageBox.Show("Số điện thoại phải có từ 9 đến 15 chữ số!");
                    txtSdt.Focus();
                    return false;
                }
            }

            return true;
        }

        private void dgvBacSi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBacSi.CurrentRow?.DataBoundItem is not BacSi bs)
                return;

            txtMaBs.Text = bs.MaBs.ToString();
            txtHoTen.Text = bs.HoTen ?? "";
            txtChuyenKhoa.Text = bs.ChuyenKhoa ?? "";
            txtSdt.Text = bs.Sdt ?? "";
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                BacSi bacSi = new BacSi
                {
                    HoTen = txtHoTen.Text.Trim(),
                    ChuyenKhoa = string.IsNullOrWhiteSpace(txtChuyenKhoa.Text)
                        ? null
                        : txtChuyenKhoa.Text.Trim(),

                    Sdt = string.IsNullOrWhiteSpace(txtSdt.Text)
                        ? null
                        : txtSdt.Text.Trim()
                };

                _context.BacSis.Add(bacSi);
                await _context.SaveChangesAsync();

                MessageBox.Show("Thêm bác sĩ thành công!");

                await LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Thêm bác sĩ thất bại!\n" + ex.Message
                );
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBs.Text))
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần sửa!");
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                int maBs = int.Parse(txtMaBs.Text);

                var bacSi = await _context.BacSis.FindAsync(maBs);

                if (bacSi == null)
                {
                    MessageBox.Show("Không tìm thấy bác sĩ!");
                    return;
                }

                bacSi.HoTen = txtHoTen.Text.Trim();

                bacSi.ChuyenKhoa =
                    string.IsNullOrWhiteSpace(txtChuyenKhoa.Text)
                    ? null
                    : txtChuyenKhoa.Text.Trim();

                bacSi.Sdt =
                    string.IsNullOrWhiteSpace(txtSdt.Text)
                    ? null
                    : txtSdt.Text.Trim();

                await _context.SaveChangesAsync();

                MessageBox.Show("Cập nhật bác sĩ thành công!");

                await LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Cập nhật bác sĩ thất bại!\n" + ex.Message
                );
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBs.Text))
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa bác sĩ này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                int maBs = int.Parse(txtMaBs.Text);

                var bacSi = await _context.BacSis.FindAsync(maBs);

                if (bacSi == null)
                {
                    MessageBox.Show("Không tìm thấy bác sĩ!");
                    return;
                }

                _context.BacSis.Remove(bacSi);

                await _context.SaveChangesAsync();

                MessageBox.Show("Xóa bác sĩ thành công!");

                await LoadData();
                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể xóa bác sĩ vì bác sĩ này đang có lịch khám!",
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