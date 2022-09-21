CREATE TABLE gaji (
	Golongan int NOT NULL,
	GajiPokok varchar(255),
	TunjanganKesehatan varchar(255),
	TotalGaji varchar(255),
	CONSTRAINT gol_pk PRIMARY KEY (Golongan),
);

INSERT INTO gaji(Golongan,GajiPokok,TunjanganKesehatan,TotalGaji)
VALUES  (1,'Rp 3.000.000','Rp 300.000','Rp 3.300.000'),
		(2,'Rp 2.000.000','Rp 200.000','Rp 2.200.000'),
		(3,'Rp 1.000.000','Rp 100.000','Rp 1.100.000');


CREATE TABLE karyawan (	
	KaryawanID int IDENTITY(1,1) NOT NULL,
	NIK varchar(255),
	Golongan int NOT NULL,
	Nama varchar(255) NOT NULL,
	Jabatan varchar(255) NOT NULL,
	Alamat varchar(255) NOT NULL,
	CONSTRAINT kary_pk PRIMARY KEY (KaryawanID),
	CONSTRAINT gol_fk FOREIGN KEY (Golongan) REFERENCES gaji (Golongan),
	CONSTRAINT kary_nik UNIQUE (NIK),
);

INSERT INTO karyawan(NIK,Golongan,Nama,Jabatan,Alamat)
VALUES  ('3304015671889991',3,'Ayu Lestari','Administrasi','Yogyakarta'),
		('3304015671889994',1,'Agus Haryanto','Manajer','Bandung'),
		('3304015671889995',2,'Nur Hasna','Staff','Jakarta');

select*from gaji
select*from karyawan
