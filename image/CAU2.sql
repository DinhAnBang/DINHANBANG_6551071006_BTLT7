-- 1. Tạo database
create database CAU2_DB;
go

use CAU2_DB;
go


create table HoiVien
(
    MaHV int identity(1,1) primary key,

    HoTen nvarchar(100) not null,

    -- 1 = Nam, 0 = Nữ
    GioiTinh bit,

    NgaySinh date,

    SDT varchar(15),

    Email varchar(100),

    -- Basic / VIP / Premium
    HangThanhVien nvarchar(20),

    NgayDangKy datetime default getdate(),

    -- 1 = Đang hoạt động
    -- 0 = Tạm ngưng
    TrangThai bit
);
go


insert into HoiVien
(
    HoTen,
    GioiTinh,
    NgaySinh,
    SDT,
    Email,
    HangThanhVien,
    TrangThai
)
values
(
    N'Nguyễn Văn An',
    1,
    '2002-05-15',
    '0901234567',
    'an@gmail.com',
    N'Basic',
    1
);

insert into HoiVien
(
    HoTen,
    GioiTinh,
    NgaySinh,
    SDT,
    Email,
    HangThanhVien,
    TrangThai
)
values
(
    N'Trần Thị Bình',
    0,
    '2001-08-20',
    '0912345678',
    'binh@gmail.com',
    N'VIP',
    1
);

insert into HoiVien
(
    HoTen,
    GioiTinh,
    NgaySinh,
    SDT,
    Email,
    HangThanhVien,
    TrangThai
)
values
(
    N'Lê Minh Cường',
    1,
    '1998-03-10',
    '0987654321',
    'cuong@gmail.com',
    N'Premium',
    1
);

insert into HoiVien
(
    HoTen,
    GioiTinh,
    NgaySinh,
    SDT,
    Email,
    HangThanhVien,
    TrangThai
)
values
(
    N'Phạm Ngọc Dung',
    0,
    '2000-11-25',
    '0934567890',
    'dung@gmail.com',
    N'Basic',
    0
);

insert into HoiVien
(
    HoTen,
    GioiTinh,
    NgaySinh,
    SDT,
    Email,
    HangThanhVien,
    TrangThai
)
values
(
    N'Hoàng Quốc Huy',
    1,
    '1997-07-12',
    '0976543210',
    'huy@gmail.com',
    N'VIP',
    1
);
go



select * from HoiVien;
go