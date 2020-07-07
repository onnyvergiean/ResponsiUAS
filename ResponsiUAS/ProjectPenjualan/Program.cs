using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;

namespace ProjectPenjualan
{
    class Program
    {
        static List<Penjualan> daftarPenjualan = new List<Penjualan>();

        static void Main(string[] args)
        {
            Console.Title = "Responsi UAS Matakuliah Pemrograman";

            while (true)
            {
                TampilMenu();

                Console.Write("\nNomor Menu [1..4]: ");
                int nomorMenu = Convert.ToInt32(Console.ReadLine());

                switch (nomorMenu)
                {
                    case 1:
                        TambahPenjualan();
                        break;

                    case 2:
                        HapusPenjualan();
                        break;

                    case 3:
                        TampilPenjualan();
                        break;

                    case 4: // keluar dari program
                        return;

                    default:
                        break;
                }
            }
        }

        static void TampilMenu()
        {
            Console.Clear();
            Console.WriteLine("Pilih Menu Aplikasi");
            Console.WriteLine();
            Console.WriteLine("1. Tambah Penjualan");
            Console.WriteLine("2. Hapus Penjualan");
            Console.WriteLine("3. Tampilkan Penjualan");
            Console.WriteLine("4. Keluar");

        }

        static void TambahPenjualan()
        {
            Console.Clear();
            
            Penjualan penjualan = new Penjualan();
            Console.WriteLine("Tambah Data Penjualan");
            Console.WriteLine();
            Console.Write("Nota : ");
            penjualan.nota = Console.ReadLine();
            Console.Write("Tanggal : ");
            penjualan.tanggal = Console.ReadLine();
            Console.Write("Customer : ");
            penjualan.customer = Console.ReadLine();
            back:
            Console.Write("Jenis [T/K] : ");
            char jenis = Convert.ToChar(Console.ReadLine());
            if(jenis == 'T' || jenis == 't')
            {
                penjualan.jenis = "Tunai";
            }
            else if (jenis == 'K' || jenis == 'k')
            {
                penjualan.jenis = "Kredit";
            }
            else
            {
                Console.WriteLine("Inputan Anda Salah!");
                goto back;
            }
            Console.Write("Total Nota : ");
            penjualan.total = Convert.ToDouble(Console.ReadLine());

            daftarPenjualan.Add(penjualan);
            Console.WriteLine("\nTekan ENTER untuk kembali ke menu");
            Console.ReadKey();


        }

        static void HapusPenjualan()
        {
            Console.Clear();
            bool cari = false;
            Console.WriteLine("Hapus Data Pejualan");
            Console.WriteLine();
            Console.Write("Nota: ");
            string note = Console.ReadLine();

            for(int i = 0; i < daftarPenjualan.Count; i++)
            {
                if(note == daftarPenjualan[i].nota)
                {
                    daftarPenjualan.Remove(daftarPenjualan[i]);
                    cari = true;
                }
                else
                {
                    cari = false;
                }
            }

            if(cari == true)
            {
                Console.WriteLine("Data Penjualan Berhasil di Hapus");
            }
            else
            {
                Console.WriteLine("Nota Tidak Ditemukan");
            }
          
            Console.WriteLine("\nTekan ENTER untuk kembali ke menu");
            Console.ReadKey();
        }

        static void TampilPenjualan()
        {
            Console.Clear();
            int noUrut = 1;
            Console.WriteLine("Data Penjualan");
            Console.WriteLine();
            foreach(Penjualan penjualan in daftarPenjualan)
            {
                Console.WriteLine("{0}. {1}, {2}, {3}, {4}, {5}",noUrut, penjualan.nota, penjualan.tanggal, penjualan.customer, penjualan.jenis, penjualan.total);
                noUrut++;
            }
            
            Console.WriteLine("\nTekan enter untuk kembali ke menu");
            Console.ReadKey();
        }
    }
}
