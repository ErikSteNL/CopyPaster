using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIEBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPartOfDirectory = Directory.GetCurrentDirectory();
            string secondPartOfDirectory = "Config.txt";

            string[] config = null;

            string timeStamp = DateTime.UtcNow.ToString();
            string correctTimeStamp = null;

            foreach(char c in timeStamp)
            {
                if(c.ToString() == "/" || c.ToString() == ":")
                {
                    correctTimeStamp = correctTimeStamp + "-";
                }
                else
                {
                    correctTimeStamp = correctTimeStamp + c.ToString();
                }
            }
           
            try
            {

                config = File.ReadAllLines(firstPartOfDirectory + "\\" + secondPartOfDirectory);
                config[1] = config[1] + correctTimeStamp + " " + config[2];
                Console.WriteLine("Config geimporteerd.");

                Console.WriteLine(config[1]);
            }

            catch (Exception e)
            {
                Console.WriteLine("Configbestand is niet gevonden.");
                Console.WriteLine(e.ToString());
            }



            try
            {
                Console.WriteLine();
                File.Copy(config[0], config[1], true);

                Console.WriteLine("Aan het kopieeren van    " + config[0]);
                Console.WriteLine("Naar                     " + config[1]);

                Console.WriteLine();

                Console.WriteLine("Bestand gekopieerd");
            }
            catch (Exception e)
            {
                Console.WriteLine();

                Console.WriteLine("Er is iets fout gegaan, neem contact op met Erik");
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();

            Console.WriteLine("Klik op een knop om programma te sluiten");
            Console.ReadKey();
        }
    }
}
