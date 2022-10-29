using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lotto
{
    internal class Program
    {
        static Int64 nyeremeny = 2500000000;
        static Int64 egyenleg = 10000;

        static void Main(string[] args)
        {
            Lottó();
            
        }
        static void Lottó()
        {
            Betoltes();


            do
            {
                Console.WriteLine("Szeretnél játszani? (igen vagy nem) :");
                string read = Console.ReadLine();
                

                
                if (read == "igen")
                {
                    Console.WriteLine("Oké!");
                    Console.WriteLine("A jelenlegi egyenleged: " + (egyenleg -= 500));
                    Console.WriteLine("A nyeremény ezen a héten: " + nyeremeny);
                    Mentes();
                    Jatek();
                    
                }
                else if (read == "nem")
                {
                    return;
                }
            }
            while (egyenleg > 500 && egyenleg < 500000000);


            
            
        }  
        private static void Jatek()
        {
            
            
            List<int> lottotippek = new List<int>();
            for (int n = 1; n <= 5; n++)
            {
                Console.WriteLine("Kérlek add meg a(z) " + n + ". számot:");
                string szamInput = Console.ReadLine();
                int szam = Int32.Parse(szamInput);
                lottotippek.Add(szam);

            }

            List<int> nyeroszamok = new List<int>();

            var lottoszamok = new Random();

            Console.WriteLine("A heti lottószámok: ");

            for (int i = 0; i <= 5; i++)
            {

                int random = lottoszamok.Next(1, 91);
                Console.WriteLine(random);
                nyeroszamok.Add(random);


            }

            int talalatok = 0;
            for (int i = 0; i < 5; i++)
            {
                if (nyeroszamok.Contains(lottotippek[i]))
                {
                    talalatok += 1;
                }
                    
            }
            Console.WriteLine(talalatok + " számot találtál el");

            //találatok száma alapján nyeremény (0;1 = semmi, stb.)
            if (talalatok == 0)
            {
                Console.WriteLine("Sajnos semmit sem kapsz 0 találatért!");
            }
            else if (talalatok == 1)
            {
                Console.WriteLine("Sajnos semmit sem kapsz 1 találatért!");
            }
            else if (talalatok == 2)
            {
                egyenleg += nyeremeny / 50000;
                nyeremeny -= nyeremeny / 50000;
                
            }
            else if (talalatok == 3)
            {
                egyenleg += nyeremeny / 5000;
                nyeremeny -= nyeremeny / 5000;
                

            }
            else if (talalatok == 4)
            {
                egyenleg += nyeremeny / 500;
                nyeremeny -= nyeremeny / 500;
                
            }
            else if (talalatok == 5)
            {
                egyenleg += nyeremeny;
                nyeremeny -= nyeremeny;
            }
            nyeremeny += 1234567;

            if (egyenleg < 500)
            {
                
                Console.WriteLine("elfogyott a pénzed, a játék itt véget ér");
                File.Delete("egyenleg.txt");
                File.Delete("nyeremeny.txt");
            }
            else if(egyenleg > 500000000)
            {
                Console.WriteLine("a pénzed nagyobb, mint 500 millió így megnyerted a játékot és itt véget ér!");
                File.Delete("nyeremeny.txt");
                File.Delete("egyenleg.txt");

            }

        }
        private static void Mentes()
        {
            Console.WriteLine("A játék el lett mentve!");

           
            File.WriteAllText("egyenleg.txt" , egyenleg.ToString());
            File.WriteAllText("nyeremeny.txt", nyeremeny.ToString());
            


        }

        private static void Betoltes()
        {
            if (File.Exists("egyenleg.txt") && File.Exists("nyeremeny.txt"))
            {
                string egyenlegtarolt = File.ReadAllText("egyenleg.txt");
                string nyeremenytarolt = File.ReadAllText("nyeremeny.txt");
                
                egyenleg = Int64.Parse(egyenlegtarolt);
                nyeremeny = Int64.Parse(nyeremenytarolt);
                
            }   
        }
        //mentes betoltes megcsinalasa (file torlese)
    }        
}
