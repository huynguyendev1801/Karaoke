using System;

namespace WordColorKaraokeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const float DO = 261.63f; // Frequency of Middle C
            const float RE = 293.66f;
            const float MI = 329.63f;
            const float FA = 349.23f;
            const float SOL = 392.00f;
            const float LA = 440.00f;
            const float SI = 493.88f;

            string conBuomVangLyrics = "Kia con buom vang, kia con buom vang. \n" +
                                        "Xoe doi canh, xoe doi canh. \n" +
                                        "Buom buom bay doi ba vong. \n" +
                                        "Buom buom bay doi ba vong. \n" +
                                        "Em ngoi xem, em ngoi xem";

            string happyBirthdayLyrics = "Hap py birth day to you, \n" +
                                          "Hap py birth day to you, \n" +
                                          "Hap py birth day happy birth day, \n" +
                                          "Hap py birth day to you!";

            string conCoBeBeLyrics = "Con co be be, no dau canh tre \n" +
                                      "Di khong hoi me, biet di duong nao \n" +
                                      "Khi di em hoi, khi ve em chao \n" +
                                      "Mieng em chum chim, me co yeu khong nao";

            string chauLenBaLyrics = "Chau len ba, chau di mau giao \n" +
                                      "Co thuong chau, thi chau khong khoc nhe \n" +
                                      "Khong khoc nhe, de me trong cay trai \n" +
                                      "Ba vao nha may, ong ba vui cay cay \n" +
                                      "La la la la, la la la la la";

            float[][] notes = {
                new float[] { DO, RE, MI, DO, DO, RE, MI, DO, MI, FA, SOL, MI, FA, SOL, SOL, LA, SOL, FA, MI, DO, SOL, LA, SOL, FA, MI, DO, DO, SOL, DO, DO, SOL, DO },
                new float[] { DO, DO, RE, DO, FA, MI, DO, DO, RE, DO, SOL, FA, DO, DO, DO * 2, LA, FA, MI, RE, LA, LA, LA, FA, SOL, FA },
                new float[] { SOL, RE, DO, DO, DO, MI, SOL, LA, LA, LA, MI, MI, RE, DO, LA, LA, DO, DO, DO, MI, DO, LA, DO, RE, RE, SOL, LA, DO, RE, LA, SOL, SOL, FA },
                new float[] { LA, SOL, FA, SOL, FA, SOL, LA, SOL, SOL, LA, FA, LA, SOL, LA, FA, SOL, LA, FA, DO, DO, FA, SOL, LA, SOL, FA, FA, FA, SOL, FA, SOL, LA, FA, DO, LA, SOL, FA, DO, DO, LA, SOL, FA }
            };

            string[] songTitles = { "Con buom vang", "Happy birthday", "Con co be be", "Chau len ba" };
            string[] songLyrics = { conBuomVangLyrics, happyBirthdayLyrics, conCoBeBeLyrics, chauLenBaLyrics };

            while (true)
            {
                Console.WriteLine("Chon bai hat:");
                for (int i = 0; i < songTitles.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {songTitles[i]}");
                }
                Console.WriteLine($"{songTitles.Length + 1}. Ket thuc");

                // Nhập lựa chọn của người dùng
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > songTitles.Length + 1)
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                }

                // Kiểm tra xem người dùng đã chọn kết thúc hay chưa
                if (choice == songTitles.Length + 1)
                {
                    break;
                }

                // Phát nhạc và xuất chữ
                Console.WriteLine("Bắt đầu phát nhạc...");
                Console.Clear();
                PlaySong(songLyrics[choice - 1], notes[choice - 1]);
            }

            Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
        }

        static void PlaySong(string song, float[] musicNote)
        {
            string[] splitSong = song.Split(' ');

            Console.Write(song);
            Console.CursorLeft = 0;
            Console.CursorTop = 0;

            for (int i = 0; i < splitSong.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(splitSong[i] + " ");
                Console.Beep((int)musicNote[i], 1000);
                Console.ResetColor();

                if (i < splitSong.Length - 1)
                {
                    Console.Write(" ");
                    Console.CursorLeft -= 1;
                }
            }

            Console.WriteLine("\nKet thuc phat nhac.");
            Console.WriteLine("\nCo muon choi nua khong");
            Console.WriteLine("Nhap 1: De choi nua");
            Console.WriteLine("Nhap 2: De ket thuc");

            int loop;
            while (!int.TryParse(Console.ReadLine(), out loop) || loop < 1 || loop > 2)
            {
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
            }

            if (loop == 1)
            {
                Console.Clear();
                PlaySong(song, musicNote);
            }
            else
            {
                Console.Clear();
            }
        }
    }
}
