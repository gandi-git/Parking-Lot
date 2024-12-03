using System;
using System.Collections.Generic;

class Program
{
    static List<Vehicle> lotMobil = new List<Vehicle>();
    static List<Vehicle> lotMotor = new List<Vehicle>();
    const int hargaMobil = 5000;
    const int hargaMotor = 2000;

    class Vehicle
    {
        public string Plat { get; set; }
        public string Jenis { get; set; }
        public int Harga { get; set; }
        public bool Status { get; set; }

        public Vehicle(string plat, string jenis, int harga, bool status)
        {
            Plat = plat;
            Jenis = jenis;
            Harga = harga;
            Status = status;
        }
    }

    class Check
    {
        public void CheckIn(string plat, string jenis, int jam)
        {
            int harga = jenis.ToLower() == "motor" ? hargaMotor * jam : hargaMobil * jam;
            if (jenis.ToLower() == "motor")
            {
                lotMotor.Add(new Vehicle(plat, jenis, harga, false));
            }
            else if (jenis.ToLower() == "mobil")
            {
                lotMobil.Add(new Vehicle(plat, jenis, harga, false));
            }
            else
            {
                Console.WriteLine("Jenis kendaraan tidak dikenali.");
            }
        }

        public void CheckOut(string plat, string jenis)
        {
            if (jenis.ToLower() == "motor")
            {
                lotMotor.RemoveAll(v => v.Plat == plat);
            }
            else if (jenis.ToLower() == "mobil")
            {
                lotMobil.RemoveAll(v => v.Plat == plat);
            }
            else
            {
                Console.WriteLine("Jenis kendaraan tidak dikenali.");
            }
        }

        public void CheckFull()
        {
            if (lotMobil.Count >= 20 && lotMotor.Count >= 20)
            {
                Console.WriteLine("Lot parkir penuh!");
            }
            else
            {
                Console.WriteLine("Masih ada slot parkir tersedia.");
            }
        }
    }

    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.WriteLine("\nPilih Menu:");
        Console.WriteLine("1. Check-in Kendaraan Anda");
        Console.WriteLine("2. Check-out Kendaraan Anda");
        Console.WriteLine("3. Laporan Kendaraan");
        Console.WriteLine("4. Keluar");
        Console.Write("Input: ");
        
        string input = Console.ReadLine();
        int pilihan;

        if (int.TryParse(input, out pilihan))
        {
            switch (pilihan)
            {
                case 1:
                    CheckIn();
                    break;

                case 2:
                    CheckOut();
                    break;

                case 3:
                    LaporanKendaraan();
                    break;

                case 4:
                    Console.WriteLine("Terima kasih!");
                    return;

                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    Menu();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Input tidak valid.");
            Menu();
        }
    }

    static void CheckIn()
    {
        Console.Write("Jenis Kendaraan (Mobil/Motor): ");
        string jenis = Console.ReadLine();
        Console.Write("Plat Kendaraan: ");
        string plat = Console.ReadLine().ToUpper();
        Console.Write("Berapa Jam Parkir: ");
        string jamInput = Console.ReadLine();
        int jam;

        if (int.TryParse(jamInput, out jam))
        {
            Check kendaraan = new Check();
            kendaraan.CheckIn(plat, jenis, jam);
            Console.WriteLine("Check-in berhasil!");
            Menu();
        }
        else
        {
            Console.WriteLine("Input jam tidak valid.");
            Menu();
        }
    }

    static void CheckOut()
    {
        Console.Write("Plat Kendaraan: ");
        string plat = Console.ReadLine().ToUpper();
        Console.Write("Jenis Kendaraan (Mobil/Motor): ");
        string jenis = Console.ReadLine();
        Check kendaraan = new Check();
        kendaraan.CheckOut(plat, jenis);
        Console.WriteLine("Check-out berhasil!");
        Menu();
    }

    static void LaporanKendaraan()
    {
        Console.WriteLine("Laporan Kendaraan:");
        Console.WriteLine("Lot Mobil:");
        foreach (var mobil in lotMobil)
        {
            Console.WriteLine($"Plat: {mobil.Plat}, Harga: {mobil.Harga}");
        }

        Console.WriteLine("Lot Motor:");
        foreach (var motor in lotMotor)
        {
            Console.WriteLine($"Plat: {motor.Plat}, Harga: {motor.Harga}");
        }
        Menu();
    }
}