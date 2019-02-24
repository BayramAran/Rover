using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverOrnegi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Harita boyutlarını girin");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            //İlk konum
            Arac arac = new Arac();
            int ilkx = 1;
            int ilky = 2;
            arac.yon = Yonler.North;

            //rota belirleme
            Console.WriteLine("Aracın rotasını giriniz");
            string rota = Console.ReadLine();
            for (int i = 0; i < rota.Length; i++)
            {
                //Left geldikten sonraki yonler
                if (rota[i] == 'L')
                {
                    if (arac.yon == Yonler.East)
                        arac.yon = Yonler.North;
                    if (arac.yon == Yonler.South)
                        arac.yon = Yonler.East;
                    if (arac.yon == Yonler.North)
                        arac.yon = Yonler.West;
                    if (arac.yon == Yonler.West)
                        arac.yon = Yonler.South;
                }
                //right geldikten sonraki yonler
                else if (rota[i] == 'R')
                {
                    if (arac.yon == Yonler.East)
                        arac.yon = Yonler.South;
                    if (arac.yon == Yonler.South)
                        arac.yon = Yonler.West;
                    if (arac.yon == Yonler.North)
                        arac.yon = Yonler.East;
                    if (arac.yon == Yonler.West)
                        arac.yon = Yonler.North;

                }
                //Move gelince kordinat ayarları
                else if (rota[i] == 'M')
                {
                    if (arac.yon == Yonler.East)
                    {
                        ilkx++;

                    }

                    if (arac.yon == Yonler.North)
                    {
                        ilky++;

                    }
                    if (arac.yon == Yonler.South)
                    {
                        ilky--;

                    }

                    if (arac.yon == Yonler.West)
                    {
                        ilkx--;

                    }


                }


            }
            //Koşullar
            if (ilky > 0 && ilkx > 0 && y > ilky && x > ilkx)
            {
                Console.WriteLine("Arac su an " + ilkx + " x kordinatında " + ilky + " y kordinatında " + arac.yon + " yönüne bakıyor");
            }
            else
            {
                Console.WriteLine("Harita dışına çıktınız");
            }
        }
    }

    public enum Yonler
    {
        North,
        East,
        West,
        South
    }
    public class Arac
    {
        public Yonler yon { get; set; }
    }

}
