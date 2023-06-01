using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lab19
{
    internal class Task2
    {
        public static void Run()
        {
            MusicAlbum musicAlbum = new MusicAlbum();
            int choice;
            do
            {
                Console.WriteLine("Enter what to do(1-show, 2-init, 3-save, 4-load):");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(musicAlbum.ToLongString());
                        break;
                    case 2:
                        musicAlbum.Init();
                        break;
                    case 3:
                        musicAlbum.Save();
                        break;
                    case 4:
                        musicAlbum = MusicAlbum.Read();
                        break;
                }
            } while (choice != 0);
        }
    }
}
