using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Szotar
{
    class Program
    {

        static Dictionary<string, string> dic = new Dictionary<string, string>();
        static Dictionary<string, string> bad_answer_list = new Dictionary<string, string>();
        static int word_number;
        static int good_answer;
        static int bad_answer;
        static int menu;

        static void read()
        {
            StreamReader sr = new StreamReader("sima angol.txt",Encoding.UTF8,true);
            string row = "";
            while (!sr.EndOfStream)
            {
                row = sr.ReadLine();
                string[] split_array = row.Split(';');
                dic.Add(split_array[0],split_array[1]);
            }
            sr.Close();
        }

        static void randomize()
        {
            Console.WriteLine();
            Random rnd = new Random();
            for (int i = 0; i < word_number; i++)
            {
                int randomnumber = rnd.Next(dic.Count);
                Console.Write(i+1 + ". " + dic.ElementAt(randomnumber).Key + " - ");
                string answer = Console.ReadLine().ToString().ToLower();
                if (answer == dic.ElementAt(randomnumber).Value)
                {
                    good_answer++;
                }
                else
                {
                    bad_answer++;
                    bad_answer_list.Add(dic.ElementAt(randomnumber).Key, dic.ElementAt(randomnumber).Value);
                }
            }
            Console.WriteLine();
        }

        static void rating()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Összesen {0} szópárt tudtál és {1} szópárt kell átismételni.",good_answer,bad_answer);
            Console.WriteLine();
            Console.WriteLine("Az alábbi szópárokat nem tudtad:");
            foreach (var item in bad_answer_list)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
            Console.WriteLine();
            Console.WriteLine("A továbblépéshez nyomj 'Entert'!");
            Console.ReadLine();
        }

        static void welcome()
        {
            Console.WriteLine();
            Console.WriteLine("Üdv a programban!");
            Console.WriteLine();
            Console.WriteLine("Menü:");
            Console.WriteLine("1 - Tanulás");
            Console.WriteLine("2 - Szópár hozzáadás");
            Console.WriteLine("0 - Kilépés");
            Console.Write("Kérlek válassz a menükből: ");
            
            do
            {
                menu = int.Parse(Console.ReadLine());
            } while (menu != 1 && menu != 2 && menu != 0);
            
        }

        static void word_piece()
        {
            Console.WriteLine();
            Console.Write("Mennyi szót szeretnél tanulni? ");
            bool tryparse = true;
            do
            {
                word_number = int.Parse(Console.ReadLine());
            } while (tryparse != true && word_number >= dic.Count);
        }

        static void write()
        {
            StreamWriter sw = new StreamWriter("sima angol.txt",true);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Új szó hozzáadása a szótárhoz!");
            Console.WriteLine();
            Console.Write("Magyar szó: ");
            string hun = Console.ReadLine();
            Console.Write("Angol szó: ");
            string en = Console.ReadLine();
            sw.Write(hun + ";" + en);
            Console.WriteLine();
            Console.Clear();
            sw.Close();
        }

        static void Main(string[] args)
        {
            read();
            do
            {
                Console.Clear();
                welcome();
                switch (menu)
                {
                    case 1:
                        word_piece(); randomize(); rating();
                        break;
                    case 2: write();
                        break;
                    default:
                        break;
                }
            } while (menu != 0);
            Console.ReadKey();
        }
    }
}
