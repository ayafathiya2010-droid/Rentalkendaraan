List<Kendaraan> data_kendaraan = new List<Kendaraan>
{
   new Kendaraan("Vario", 150000, "AE 2345 N"),
   new Kendaraan("NMAx", 200000, "N 1234 B"),
   new Mobil("Civic", 100000, "B 2341 H"),
   new Mobil("Avanza", 400000, "H 3456 BC"),
   new MiniBus("Elf", 200000, "B 6789 N"),
   new MiniBus("HiAce", 500000, "N 7865 B")
};

class Kendaraan
{
    protected string _namaKendaraan;
    protected double _hargaSewaPerHari;
    protected string _nomorPolisi;
    protected bool _isAvailable;

    public Kendaraan(string nama_Kendaraan, double harga_Sewa, string nomor_Polisi)
    {
        _namaKendaraan = nama_Kendaraan;
        _hargaSewaPerHari = harga_Sewa;
        _nomorPolisi = nomor_Polisi;
        _isAvailable = true;
    }

    public string NamaKendaraan
    {
        get { return _namaKendaraan; }
        set { _namaKendaraan = value; }
    }

    public double HargaSewaPerHari
    {
        get { return _hargaSewaPerHari;}
        set { 
           if (value > 0)
            {
                _hargaSewaPerHari = value;
            }
           else
            {
                Console.WriteLine("Harga sewa harus lebih besar dari 0");
            }
        }
    }

    public string NomorPolisi
    {
        get { return _nomorPolisi; }
    }

    public bool IsAvailable
    {
        get { return _isAvailable; }
    }

    public void tampilkanInfo()
    {
        Console.WriteLine($"Nama kendaraan: {_namaKendaraan}");
        Console.WriteLine($"Harga sewa per hari: {_hargaSewaPerHari}");
        Console.WriteLine($"Nomor Polisi: {_nomorPolisi}");
        Console.WriteLine($"Ketersediaan: {(_isAvailable ? "Tersedia" : "Tidak tersedia")}");
    }

    public void UbahStatus()
    {
        _isAvailable = !_isAvailable;
    }

    public virtual double HitungTotal(int jumlahHari)
    {
        return _hargaSewaPerHari * jumlahHari;
    }
}

class Mobil : Kendaraan
{
    private double _biayaAsuransi;
    public Mobil(string nama_Kendaraan, double harga_Sewa, string nomor_Polisi) 
        :base(nama_Kendaraan, harga_Sewa, nomor_Polisi)
    {
        _biayaAsuransi = 50000;
    }

    public override double HitungTotal(int jumlahHari)
    {
        return base.HitungTotal(jumlahHari) + _biayaAsuransi;
    }
  
}

class MiniBus : Kendaraan
{
    private double _biayaSopir;
    public MiniBus(string nama_Kendaraan, double harga_Sewa, string nomor_Polisi)
        : base(nama_Kendaraan, harga_Sewa, nomor_Polisi)
    {
        _biayaSopir = 100000;
    }

    public override double HitungTotal(int jumlahHari)
    {
        return base.HitungTotal(jumlahHari) + _biayaSopir * jumlahHari;
    }

}


