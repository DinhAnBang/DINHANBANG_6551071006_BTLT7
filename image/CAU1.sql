create database knowledgeWeb;
go

-- cau 1
create table TheLoaiSach (
    MaTL int identity(1,1) primary key,
    TenTheLoai nvarchar(100) not null unique,
    MoTa nvarchar(255) null,
    SoLuongSach int default 0,
    NgayTao datetime default getdate()
);
go


insert into TheLoaiSach (TenTheLoai, MoTa, SoLuongSach)
values
(N'Tiểu thuyết', N'Thể loại tiểu thuyết', 10),
(N'Kỹ năng sống', N'Sách kỹ năng sống', 15),
(N'Thiếu nhi', N'Sách dành cho thiếu nhi', 8),
(N'Sách giáo khoa', N'Sách phục vụ học tập', 20),
(N'Truyện tranh', N'Truyện tranh các loại', 12);

select * from TheLoaiSach;

