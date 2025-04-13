using System;
using tpmodul8_103022300069;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig().ReadConfigFile();

        Console.Write($"Ubah satuan suhu? (y/n): ");
        string ubah = Console.ReadLine();
        if (ubah.ToLower() == "y")
        {
            config.UbahSatuan();
            Console.WriteLine($"Satuan suhu berhasil diubah ke {config.satuan_suhu}.");
        }

        Console.Write($"\nBerapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("\nBerapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = int.Parse(Console.ReadLine());

        bool suhuNormal = config.satuan_suhu == "celcius" ? suhu >= 36.5 && suhu <= 37.5 : suhu >= 97.7 && suhu <= 99.5;

        bool sehat = suhuNormal && hari < config.batas_hari_demam;

        Console.WriteLine();
        Console.WriteLine(sehat ? config.pesan_diterima : config.pesan_ditolak);
    }
}