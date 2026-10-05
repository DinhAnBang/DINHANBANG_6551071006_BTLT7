using CAU3.Models;
using Microsoft.EntityFrameworkCore;

namespace CAU3
{
    public partial class Form1 : Form
    {
        private readonly CAU3_DBContext _context;

        private string? _duongDanAnhTam;

        private readonly string _thuMucAnh =
            Path.Combine(Application.StartupPath, "Images");

        public Form1()
        {
            InitializeComponent();
            _context = new CAU3_DBContext();

            Directory.CreateDirectory(_thuMucAnh);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            LoadTinhTrang();
            await LoadLoaiPhong();
            await LoadData();
            ClearInput();
        }

        // =========================
        // COMBOBOX TÌNH TRẠNG
        // =========================
        private void LoadTinhTrang()
        {
            cboTinhTrang.Items.Clear();
            cboTinhTrang.Items.Add("Trống");
            cboTinhTrang.Items.Add("Đang ở");
            cboTinhTrang.Items.Add("Đang dọn");
            cboTinhTrang.SelectedIndex = 0;

            cboLocTinhTrang.Items.Clear();
            cboLocTinhTrang.Items.Add("Tất cả");
            cboLocTinhTrang.Items.Add("Trống");
            cboLocTinhTrang.Items.Add("Đang ở");
            cboLocTinhTrang.Items.Add("Đang dọn");
            cboLocTinhTrang.SelectedIndex = 0;
        }

        // =========================
        // LOAD LOẠI PHÒNG
        // =========================
        private async Task LoadLoaiPhong()
        {
            var danhSach = await _context.LoaiPhongs
                .AsNoTracking()
                .OrderBy(x => x.TenLoai)
                .ToListAsync();

            cboLoaiPhong.DataSource = danhSach;
            cboLoaiPhong.DisplayMember = "TenLoai";
            cboLoaiPhong.ValueMember = "MaLoai";

            var danhSachLoc = new List<LoaiPhong>
            {
                new LoaiPhong
                {
                    MaLoai = 0,
                    TenLoai = "Tất cả"
                }
            };

            danhSachLoc.AddRange(danhSach);

            cboLocLoai.DataSource = danhSachLoc;
            cboLocLoai.DisplayMember = "TenLoai";
            cboLocLoai.ValueMember = "MaLoai";
        }

        // =========================
        // LOAD PHÒNG
        // =========================
        private async Task LoadData()
        {
            var danhSach = await _context.Phongs
                .AsNoTracking()
                .Include(x => x.MaLoaiNavigation)
                .OrderBy(x => x.MaPhong)
                .ToListAsync();

            HienThiDanhSach(danhSach);
        }

        private void HienThiDanhSach(List<Phong> danhSach)
        {
            dgvPhong.DataSource = null;
            dgvPhong.Columns.Clear();

            // =========================
            // CỘT MÃ PHÒNG
            // =========================
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaPhong",
                HeaderText = "Mã phòng",
                DataPropertyName = "MaPhong"
            });

            // =========================
            // CỘT ẢNH
            // =========================
            DataGridViewImageColumn cotAnh = new DataGridViewImageColumn
            {
                Name = "Anh",
                HeaderText = "Ảnh",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 100
            };

            dgvPhong.Columns.Add(cotAnh);

            // =========================
            // CỘT SỐ PHÒNG
            // =========================
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoPhong",
                HeaderText = "Số phòng",
                DataPropertyName = "SoPhong"
            });

            // =========================
            // CỘT TẦNG
            // =========================
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TangSo",
                HeaderText = "Tầng",
                DataPropertyName = "TangSo"
            });

            // =========================
            // CỘT LOẠI PHÒNG
            // =========================
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LoaiPhong",
                HeaderText = "Loại phòng",
                DataPropertyName = "LoaiPhong"
            });

            // =========================
            // CỘT GIÁ / ĐÊM
            // =========================
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GiaMoiDem",
                HeaderText = "Giá/đêm",
                DataPropertyName = "GiaMoiDem"
            });

            // =========================
            // CỘT TÌNH TRẠNG
            // =========================
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TinhTrang",
                HeaderText = "Tình trạng",
                DataPropertyName = "TinhTrang"
            });

            // =========================
            // CỘT MÃ LOẠI ẨN
            // =========================
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaLoai",
                HeaderText = "Mã loại",
                DataPropertyName = "MaLoai",
                Visible = false
            });

            // =========================
            // CỘT TÊN FILE ẢNH ẨN
            // =========================
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HinhAnh",
                HeaderText = "Hình ảnh",
                DataPropertyName = "HinhAnh",
                Visible = false
            });

            // =========================
            // DỮ LIỆU GRID
            // =========================
            var hienThi = danhSach.Select(x => new
            {
                x.MaPhong,

                x.SoPhong,

                x.TangSo,

                LoaiPhong = x.MaLoaiNavigation?.TenLoai ?? "",

                GiaMoiDem = x.MaLoaiNavigation?.GiaMoiDem,

                x.TinhTrang,

                x.MaLoai,

                x.HinhAnh

            }).ToList();

            dgvPhong.AutoGenerateColumns = false;
            dgvPhong.DataSource = hienThi;

            // =========================
            // HIỂN THỊ ẢNH
            // =========================
            foreach (DataGridViewRow row in dgvPhong.Rows)
            {
                string? tenAnh =
                    row.Cells["HinhAnh"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(tenAnh))
                    continue;

                string duongDan =
                    Path.Combine(_thuMucAnh, tenAnh);

                if (!File.Exists(duongDan))
                    continue;

                try
                {
                    using Image temp = Image.FromFile(duongDan);

                    row.Cells["Anh"].Value =
                        new Bitmap(temp);
                }
                catch
                {
                    row.Cells["Anh"].Value = null;
                }
            }

            // Tăng chiều cao dòng để nhìn rõ ảnh
            dgvPhong.RowTemplate.Height = 75;

            foreach (DataGridViewRow row in dgvPhong.Rows)
            {
                row.Height = 75;
            }

            // Format giá
            dgvPhong.Columns["GiaMoiDem"]
                .DefaultCellStyle.Format = "N0";

            dgvPhong.ClearSelection();
            dgvPhong.CurrentCell = null;
        }

        // =========================
        // CLEAR
        // =========================
        private void ClearInput()
        {
            txtMaPhong.Clear();
            txtSoPhong.Clear();
            txtTang.Clear();
            txtHinhAnh.Clear();

            _duongDanAnhTam = null;

            if (cboLoaiPhong.Items.Count > 0)
                cboLoaiPhong.SelectedIndex = 0;

            if (cboTinhTrang.Items.Count > 0)
                cboTinhTrang.SelectedIndex = 0;

            XoaAnhPictureBox();

            dgvPhong.ClearSelection();
            dgvPhong.CurrentCell = null;

            txtSoPhong.Focus();
        }

        // =========================
        // VALIDATE
        // =========================
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Số phòng không được để trống!");
                txtSoPhong.Focus();
                return false;
            }

            if (!int.TryParse(txtTang.Text.Trim(), out int tang))
            {
                MessageBox.Show("Tầng phải là số nguyên!");
                txtTang.Focus();
                return false;
            }

            if (tang <= 0)
            {
                MessageBox.Show("Tầng phải lớn hơn 0!");
                txtTang.Focus();
                return false;
            }

            if (cboLoaiPhong.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng!");
                return false;
            }

            if (cboTinhTrang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn tình trạng!");
                return false;
            }

            return true;
        }

        // =========================
        // CHỌN ẢNH
        // =========================
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using OpenFileDialog open = new OpenFileDialog();

            open.Title = "Chọn hình ảnh phòng";

            open.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (open.ShowDialog() != DialogResult.OK)
                return;

            _duongDanAnhTam = open.FileName;

            txtHinhAnh.Text = Path.GetFileName(open.FileName);

            HienThiAnh(open.FileName);
        }

        private void HienThiAnh(string duongDan)
        {
            XoaAnhPictureBox();

            if (!File.Exists(duongDan))
                return;

            using var temp = Image.FromFile(duongDan);

            picHinhAnh.Image = new Bitmap(temp);
        }

        private void XoaAnhPictureBox()
        {
            if (picHinhAnh.Image != null)
            {
                var old = picHinhAnh.Image;
                picHinhAnh.Image = null;
                old.Dispose();
            }
        }

        // Copy ảnh vào thư mục Images
        private string? LuuAnh()
        {
            if (string.IsNullOrWhiteSpace(_duongDanAnhTam))
                return string.IsNullOrWhiteSpace(txtHinhAnh.Text)
                    ? null
                    : txtHinhAnh.Text;

            string extension =
                Path.GetExtension(_duongDanAnhTam);

            string tenFile =
                Guid.NewGuid().ToString() + extension;

            string dich =
                Path.Combine(_thuMucAnh, tenFile);

            File.Copy(
                _duongDanAnhTam,
                dich,
                true
            );

            return tenFile;
        }

        // =========================
        // CHỌN DÒNG
        // =========================
        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null)
                return;

            var row = dgvPhong.CurrentRow;

            if (row.Cells["MaPhong"].Value == null)
                return;

            txtMaPhong.Text =
                row.Cells["MaPhong"].Value?.ToString() ?? "";

            txtSoPhong.Text =
                row.Cells["SoPhong"].Value?.ToString() ?? "";

            txtTang.Text =
                row.Cells["TangSo"].Value?.ToString() ?? "";

            // Lấy MaLoai đã lưu ẩn trong DataGridView
            if (row.Cells["MaLoai"].Value != null)
            {
                int maLoai =
                    Convert.ToInt32(row.Cells["MaLoai"].Value);

                cboLoaiPhong.SelectedValue = maLoai;
            }

            string tinhTrang =
                row.Cells["TinhTrang"].Value?.ToString() ?? "";

            if (!string.IsNullOrWhiteSpace(tinhTrang))
                cboTinhTrang.SelectedItem = tinhTrang;

            string hinhAnh =
                row.Cells["HinhAnh"].Value?.ToString() ?? "";

            txtHinhAnh.Text = hinhAnh;

            _duongDanAnhTam = null;

            XoaAnhPictureBox();

            if (!string.IsNullOrWhiteSpace(hinhAnh))
            {
                string duongDan =
                    Path.Combine(_thuMucAnh, hinhAnh);

                if (File.Exists(duongDan))
                    HienThiAnh(duongDan);
            }
        }

        // =========================
        // THÊM
        // =========================
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string soPhong = txtSoPhong.Text.Trim();

            bool tonTai = await _context.Phongs
                .AnyAsync(x => x.SoPhong == soPhong);

            if (tonTai)
            {
                MessageBox.Show("Số phòng đã tồn tại!");
                txtSoPhong.Focus();
                return;
            }

            try
            {
                string? tenAnh = LuuAnh();

                var phong = new Phong
                {
                    SoPhong = soPhong,
                    TangSo = int.Parse(txtTang.Text.Trim()),
                    MaLoai = Convert.ToInt32(
                        cboLoaiPhong.SelectedValue
                    ),
                    TinhTrang =
                        cboTinhTrang.SelectedItem!.ToString(),
                    HinhAnh = tenAnh
                };

                _context.Phongs.Add(phong);

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Thêm phòng thành công!",
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
                    "Thêm phòng thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================
        // SỬA
        // =========================
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!");
                return;
            }

            if (!ValidateInput())
                return;

            int maPhong = int.Parse(txtMaPhong.Text);
            string soPhong = txtSoPhong.Text.Trim();

            bool trungSoPhong = await _context.Phongs
                .AnyAsync(x =>
                    x.SoPhong == soPhong &&
                    x.MaPhong != maPhong);

            if (trungSoPhong)
            {
                MessageBox.Show("Số phòng đã tồn tại!");
                return;
            }

            try
            {
                var phong =
                    await _context.Phongs.FindAsync(maPhong);

                if (phong == null)
                {
                    MessageBox.Show("Không tìm thấy phòng!");
                    return;
                }

                phong.SoPhong = soPhong;
                phong.TangSo =
                    int.Parse(txtTang.Text.Trim());

                phong.MaLoai =
                    Convert.ToInt32(
                        cboLoaiPhong.SelectedValue
                    );

                phong.TinhTrang =
                    cboTinhTrang.SelectedItem!.ToString();

                // Nếu chọn ảnh mới thì copy ảnh mới
                if (!string.IsNullOrWhiteSpace(_duongDanAnhTam))
                    phong.HinhAnh = LuuAnh();

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Cập nhật phòng thành công!",
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
                    "Cập nhật phòng thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================
        // XÓA
        // =========================
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phòng này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                int maPhong =
                    int.Parse(txtMaPhong.Text);

                var phong =
                    await _context.Phongs.FindAsync(maPhong);

                if (phong == null)
                {
                    MessageBox.Show("Không tìm thấy phòng!");
                    return;
                }

                _context.Phongs.Remove(phong);

                await _context.SaveChangesAsync();

                MessageBox.Show(
                    "Xóa phòng thành công!",
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
                    "Xóa phòng thất bại!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =========================
        // LÀM MỚI
        // =========================
        private async void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();

            cboLocLoai.SelectedIndex = 0;
            cboLocTinhTrang.SelectedIndex = 0;

            await LoadData();
        }

        // =========================
        // LỌC
        // =========================
        private async void btnLoc_Click(object sender, EventArgs e)
        {
            int maLoai =
                Convert.ToInt32(cboLocLoai.SelectedValue);

            string tinhTrang =
                cboLocTinhTrang.SelectedItem?.ToString()
                ?? "Tất cả";

            var query = _context.Phongs
                .AsNoTracking()
                .Include(x => x.MaLoaiNavigation)
                .AsQueryable();

            if (maLoai != 0)
            {
                query = query.Where(
                    x => x.MaLoai == maLoai
                );
            }

            if (tinhTrang != "Tất cả")
            {
                query = query.Where(
                    x => x.TinhTrang == tinhTrang
                );
            }

            var ketQua = await query
                .OrderBy(x => x.MaPhong)
                .ToListAsync();

            HienThiDanhSach(ketQua);

            if (ketQua.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy phòng phù hợp!"
                );
            }
        }

        // =========================
        // MỞ FORM LOẠI PHÒNG
        // =========================
        private async void btnLoaiPhong_Click(
            object sender,
            EventArgs e)
        {
            using FormLoaiPhong form =
                new FormLoaiPhong();

            form.ShowDialog();

            // Load lại ComboBox vì loại phòng có thể thay đổi
            await LoadLoaiPhong();
            await LoadData();
            ClearInput();
        }

        protected override void OnFormClosed(
            FormClosedEventArgs e)
        {
            XoaAnhPictureBox();

            _context.Dispose();

            base.OnFormClosed(e);
        }
    }
}