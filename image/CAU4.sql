

create database CAU4_DB;
go

use CAU4_DB;
go



create table BacSi
(
    MaBS int identity(1,1) primary key,

    HoTen nvarchar(100) not null,

    ChuyenKhoa nvarchar(100),

    SDT varchar(15)
);
go



create table LichKham
(
    MaLich int identity(1,1) primary key,

    TenBenhNhan nvarchar(100) not null,

    SDT varchar(15),

    NgayKham date,

    GioKham time,

    MaBS int,

    TrangThai nvarchar(20),

    constraint FK_LichKham_BacSi
        foreign key (MaBS)
        references BacSi(MaBS)
);
go



insert into BacSi(HoTen, ChuyenKhoa, SDT)
values
(N'Nguyễn Văn An', N'Nội tổng quát', '0901111111');

insert into BacSi(HoTen, ChuyenKhoa, SDT)
values
(N'Trần Thị Bình', N'Nhi khoa', '0902222222');

insert into BacSi(HoTen, ChuyenKhoa, SDT)
values
(N'Lê Minh Cường', N'Tim mạch', '0903333333');

insert into BacSi(HoTen, ChuyenKhoa, SDT)
values
(N'Phạm Ngọc Dung', N'Da liễu', '0904444444');
go


insert into LichKham
(
    TenBenhNhan,
    SDT,
    NgayKham,
    GioKham,
    MaBS,
    TrangThai
)
values
(
    N'Nguyễn Hoàng Nam',
    '0972566789',
    '2026-10-10',
    '08:00:00',
    1,
    N'Chờ khám'
);

insert into LichKham
(
    TenBenhNhan,
    SDT,
    NgayKham,
    GioKham,
    MaBS,
    TrangThai
)
values
(
    N'Trần Ngọc Mai',
    '0972566790',
    '2026-10-11',
    '09:30:00',
    2,
    N'Chờ khám'
);

insert into LichKham
(
    TenBenhNhan,
    SDT,
    NgayKham,
    GioKham,
    MaBS,
    TrangThai
)
values
(
    N'Lê Quốc Huy',
    '0972566791',
    '2026-10-12',
    '10:00:00',
    3,
    N'Chờ khám'
);

insert into LichKham
(
    TenBenhNhan,
    SDT,
    NgayKham,
    GioKham,
    MaBS,
    TrangThai
)
values
(
    N'Phạm Thanh Hà',
    '0972566792',
    '2026-10-13',
    '14:00:00',
    4,
    N'Chờ khám'
);

insert into LichKham
(
    TenBenhNhan,
    SDT,
    NgayKham,
    GioKham,
    MaBS,
    TrangThai
)
values
(
    N'Võ Minh Anh',
    '0972566793',
    '2026-10-14',
    '16:30:00',
    1,
    N'Chờ khám'
);
go



select * from BacSi;
go

select
    lk.MaLich,
    lk.TenBenhNhan,
    lk.SDT,
    lk.NgayKham,
    lk.GioKham,
    bs.HoTen as TenBacSi,
    bs.ChuyenKhoa,
    lk.TrangThai
from LichKham lk
join BacSi bs
    on lk.MaBS = bs.MaBS
order by lk.NgayKham, lk.GioKham;
go