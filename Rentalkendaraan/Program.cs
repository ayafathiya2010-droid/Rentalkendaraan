//List sepeti array namun lebih dinamis
List<Kendaraan> data_kendaraan = new List<Kendaraan>()
{
   new Kendaraan("Vario", 150000, "AE 2345 N"),
   new Kendaraan("NMAx", 200000, "N 1234 B"),
   new Mobil("Civic", 100000, "B 2341 H"),
   new Mobil("Avanza", 400000, "H 3456 BC"),
   new MiniBus("Elf", 200000, "B 6789 N"),
   new MiniBus("HiAce", 500000, "N 7865 B")
};

while (true)
{
    Console.Clear();

    Console.WriteLine("\n===Rental kendaraan murah===");
    Console.WriteLine("\nDaftar kendaraan");

    // Mendeklarasikan sebuah kata kunci atau objek yang tidak diketahui
    foreach (var dk in data_kendaraan)
    {
        dk.tampilkanInfo();
    }

    Console.WriteLine("Pilihan menu:");
    Console.WriteLine("1. Sewa\n2.Kembali\n3.Keluar");
    Console.Write("Pilihan Anda: ");
    string pilihan = Console.ReadLine();

    if(pilihan == "1")
    {
        //Proses sewa
        Console.Write("\nInput nama kendaraan: ");
        string nama_kendaraan = Console.ReadLine();

        var cari_kendaraan = data_kendaraan.FirstOrDefault(ck => string.Equals(ck.NamaKendaraan, nama_kendaraan, StringComparison.OrdinalIgnoreCase));

        if (cari_kendaraan == null)
        {
            Console.WriteLine("\nKedaraan tidak ditemukan");
        }
        else if( cari_kendaraan.IsAvailable)
        {
            Console.Write("\nInput hasil sewa: ");
                int hari = int.Parse(Console.ReadLine());

            double total_sewa = cari_kendaraan.HitungTotal(hari);

            cari_kendaraan.UbahStatus();

            Console.Write($"Total pembayaran sewa: Rp {total_sewa}");
        }
        else
        {
            Console.WriteLine("\nKendadraan tidak tersedia");
        }
    }
    else if (pilihan == "2")
    {
        //Proses kembali
        Console.Write("\nInput nama kendaraan: ");
        string nama_kendaraan = Console.ReadLine();

        var cari_kendaraan = data_kendaraan.FirstOrDefault(ck => string.Equals(ck.NamaKendaraan, nama_kendaraan, StringComparison.OrdinalIgnoreCase));

        if (cari_kendaraan == null)
        {
            Console.WriteLine("\nKedaraan tidak ditemukan");
        }
        else if (!cari_kendaraan.IsAvailable)
        {
            cari_kendaraan.UbahStatus();

            Console.WriteLine("\nKendaraan berhasil dikembalikan!");
        }
        else
        {
            Console.WriteLine("\nProses pengembalian tidak bisa dilakukan");
        }
    }
    else if (pilihan == "3")
    {
        Console.WriteLine("Tekan ENTER untuk keluar aplikasi...");
        Console.ReadLine();
        break;
    }
    else
    {
        Console.WriteLine("\nPilihan Invalid");
    }

    Console.WriteLine("\nTekan ENTER untuk mengulang");
    Console.ReadLine();
 
}

class Kendaraan
{
    //bisa diakses class sendiri atau class lain namun harus sama-saa memilki akses modifier
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

    //Property
    public string NamaKendaraan
    {
        //Jika  ada get dan set tandanya bisa dilihat dan bisa diubah
        get { return _namaKendaraan; }
        set { _namaKendaraan = value; }
    }

    public double HargaSewaPerHari
    {
        //Adanya validasi data
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
        //Jika hanya ada salah satunya, maka .... hanya akan menuruti sesuai dengan yang diberikan get atau set
        get { return _nomorPolisi; }
    }

    public bool IsAvailable
    {
        get { return _isAvailable; }
    }

    public void tampilkanInfo()
    {
        Console.WriteLine($"{_namaKendaraan} | {_nomorPolisi} | Rp {_hargaSewaPerHari} / hari | {(_isAvailable ? "Tersedia" : "Tidak tersedia")} ");
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
 //method yang ingin ditulis ulang maka menggunakan method overidding (virtual dan overide)
 // base: memanggil yang ada di class parent

