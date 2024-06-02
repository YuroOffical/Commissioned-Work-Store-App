drop database afl2sem3;
create database afl2sem3;
use afl2sem3;

-- TABLE & DUMM DATA: LINE 8 - 97
-- VIEW: LINE 100 - 130

create table LIST_ITEM (
id_item varchar(6) primary key,
nama_item varchar(50),
jenis_item varchar(8),
harga_item int
);

insert into LIST_ITEM (id_item, nama_item, jenis_item, harga_item) 
values
( 'MA0001', 'Nasi Pecel', 'Makanan', '33000'),
( 'MA0002', 'Misua Ikan', 'Makanan', '43000'),
( 'MA0003', 'Rawon', 'Makanan', '43000'),
( 'MI0001', 'Es Teh', 'Minuman', '8000'),
( 'MI0002', 'Cao', 'Minuman', '13000'),
( 'MI0003', 'Jeruk Murni', 'Minuman','30000'), 
( 'SN0001', 'Kerupuk udang', 'Snack', '10000'),
( 'SN0002', 'Kerupuk Putih', 'Snack', '5000');

create table DTRANS (
id_nota varchar(12) references htrans(id_nota),
id_item varchar(6) references LIST_ITEM(id_item),
harga_item int,
jumlah_item int,
subtotal int
);

insert into DTRANS (id_nota, id_item, harga_item, jumlah_item, subtotal)
value
('171020230001', 'MA0001', '33000', '5', '165000'),
('171020230001', 'MA0002', '43000', '3', '129000')
;


create table HTRANS (
id_nota varchar(12) primary key,
id_karyawan varchar(8) references karyawan(id_karyawan),
tanggal_transaksi date,
nama_customer varchar(30),
nama_pegawai varchar(30),
harga_total int
);

insert into HTRANS (id_nota, id_karyawan, tanggal_transaksi, nama_customer, nama_pegawai, harga_total)
value
('171020230001', 'KA0001', '2023-10-17', 'Marvel Brody', 'Wilbert', '450000'),
('171020230002', 'KA0002', '2023-10-17' , 'Theo Indomaret', 'Vivi', '220000')
;


create table KARYAWAN (
id_karyawan varchar(8) primary key,
username varchar(20) references userdata(username),
nama_lengkap varchar(70),
gender varchar(1),
peran char(20),
gaji_per_bulan int,
nomer_hp varchar(20),
nik varchar(20),
shift varchar(20)
);

insert into KARYAWAN (id_karyawan, username, nama_lengkap, gender, peran, gaji_per_bulan, nomer_hp, nik)
value
('KA0001', 'Admin', 'Administrator', 'P', 'Manager', 10000000,'08123456789', '15928379832', 'Evening'),
('KA0002', 'JNugroho01', 'Josephine Nugroho', 'L', 'Kasir', '10000000', '0815766498', '273478942380', 'Morning')
;

create table USERDATA (
username varchar(20) primary key,
pasword varchar(32),
id_karyawan varchar(8) references karyawan(id_karyawan)
);

insert into USERDATA(username, pasword, id_karyawan) 
value 
('Admin', 'admin' , 'KA0001'),
('JNugroho01', 'bcde2345', 'KA0002');

create table EXPENSE (
id_pengeluaran varchar(8),
nama_pengeluaran varchar(50),
jenis_pengeluaran varchar(20),
tanggal_pengeluaran date,
total_pengeluaran int
);

insert into EXPENSE (id_pengeluaran, nama_pengeluaran, jenis_pengeluaran, tanggal_pengeluaran, total_pengeluaran)
value
('PE000001', 'barang belanjaaan', 'COGS', '2023-10-23', '400000'),
('PE000002', 'listrik bulan agustus 2023', 'Operational Cost', '2023-11-23', '2000000');
