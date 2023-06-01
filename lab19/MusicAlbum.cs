using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lab19
{
    [DataContract]

    internal class MusicAlbum
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Maker { get; set; }

        [DataMember]
        public int PublicationYear { get; set; }

        [DataMember]
        public double DurationMin { get; set; }

        [DataMember]
        public string Studio { get; set; }

        public MusicAlbum(string name, string maker, int year, double dur, string studio)
        {
            Name = name;
            Maker = maker;
            PublicationYear = year;
            DurationMin = dur;
            Studio = studio;
        }

        public MusicAlbum() : this("", "", 0, 0, "")
        { }

        public void Init()
        {
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
            Console.Write("Enter Maker: ");
            Maker = Console.ReadLine();
            Console.Write("Enter Publication year: ");
            int.TryParse(Console.ReadLine(), out int year);
            PublicationYear = year;
            Console.Write("Enter duration(minuutes): ");
            double.TryParse(Console.ReadLine(), out double dur);
            DurationMin = dur;
            Console.Write("Enter studio: ");
            Studio = Console.ReadLine();
        }

        public void Save()
        {
            string path = "D:\\VisualStudio\\Projects C#\\lab19\\lab19\\text2.dat";
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(MusicAlbum));
                dcs.WriteObject(fs, this);
            }
            Console.WriteLine("Object serialized");
        }

        public static MusicAlbum Read()
        {
            MusicAlbum album;
            string path = "D:\\VisualStudio\\Projects C#\\lab19\\lab19\\text2.dat";
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                DataContractSerializer dcs = new DataContractSerializer(typeof(MusicAlbum));
                try
                {
                    album = (MusicAlbum)dcs.ReadObject(fs);
                }
                catch
                {
                    album = new MusicAlbum();
                }
            }
            return album;
        }

        public string ToLongString()
        {
            return $"Name: {Name}, Maker: {Maker}, Publiation year: {PublicationYear}, Duration(mins): {DurationMin}, Studio: {Studio}";
        }
    }
}