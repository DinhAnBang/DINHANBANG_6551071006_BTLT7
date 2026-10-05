

create database CAU3_DB;
go

use CAU3_DB;
go



create table LoaiPhong
(
    MaLoai int identity(1,1) primary key,

    TenLoai nvarchar(100) not null,

    GiaMoiDem decimal(18,2),

    MoTa nvarchar(255)
);
go



create table Phong
(
    MaPhong int identity(1,1) primary key,

    SoPhong varchar(10) not null,

    TangSo int,

    TinhTrang nvarchar(20),

    HinhAnh nvarchar(255),

    MaLoai int,

    constraint FK_Phong_LoaiPhong
        foreign key (MaLoai)
        references LoaiPhong(MaLoai)
);
go



insert into LoaiPhong
(
    TenLoai,
    GiaMoiDem,
    MoTa
)
values
(
    N'Phòng đơn',
    350000,
    N'Phòng dành cho 1-2 người'
);

insert into LoaiPhong
(
    TenLoai,
    GiaMoiDem,
    MoTa
)
values
(
    N'Phòng đôi',
    550000,
    N'Phòng có giường đôi, dành cho 2-4 người'
);

insert into LoaiPhong
(
    TenLoai,
    GiaMoiDem,
    MoTa
)
values
(
    N'Phòng VIP',
    850000,
    N'Phòng cao cấp, đầy đủ tiện nghi'
);
go



insert into Phong
(
    SoPhong,
    TangSo,
    TinhTrang,
    HinhAnh,
    MaLoai
)
values
(
    '101',
    1,
    N'Trống',
    null,
    1
);

insert into Phong
(
    SoPhong,
    TangSo,
    TinhTrang,
    HinhAnh,
    MaLoai
)
values
(
    '102',
    1,
    N'Đang ở',
    null,
    2
);

insert into Phong
(
    SoPhong,
    TangSo,
    TinhTrang,
    HinhAnh,
    MaLoai
)
values
(
    '201',
    2,
    N'Trống',
    null,
    2
);

insert into Phong
(
    SoPhong,
    TangSo,
    TinhTrang,
    HinhAnh,
    MaLoai
)
values
(
    '202',
    2,
    N'Đang dọn',
    null,
    3
);

insert into Phong
(
    SoPhong,
    TangSo,
    TinhTrang,
    HinhAnh,
    MaLoai
)
values
(
    '301',
    3,
    N'Trống',
    null,
    3
);
go



select * from LoaiPhong;
go


select
    p.MaPhong,
    p.SoPhong,
    p.TangSo,
    p.TinhTrang,
    p.HinhAnh,
    lp.MaLoai,
    lp.TenLoai,
    lp.GiaMoiDem
from Phong p
join LoaiPhong lp
    on p.MaLoai = lp.MaLoai;
go