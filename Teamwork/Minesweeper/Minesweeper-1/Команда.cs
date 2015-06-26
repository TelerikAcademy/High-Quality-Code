using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mini
{
    internal static class Команда
    {
        internal static int x { get; set; }
        internal static int y { get; set; }
        internal static bool Izlez;


        internal static bool IsGetStatistic;
        internal static bool NeMojesh;
        internal static bool Nanovo;

        internal static void Прочети()
        {
            Clear();
            string command = Console.ReadLine();
            command = command.Trim();
            if (command == "exit")
            {
                Izlez = true;
                return;


            }
            if (command == "top")
            {
                IsGetStatistic = true;
                return;
            }
            if (command == "restart")
            {
                Nanovo = true;
                return;
            }

            string[] tochka = command.Split(' ');
            if (tochka.Length != 2)
                NeMojesh = true;
            else
            {
                try
                {
                    x = Convert.ToInt32(tochka[0]);
                    y = Convert.ToInt32(tochka[1]);
                }
                catch (FormatException)
                {
                    //opa grymna...

                    NeMojesh = true;
                }


            }
        }

        internal static void Clear()
        {
            x = 0;
            y = 0;
            Izlez = false;
            IsGetStatistic = false;
            NeMojesh = false;
            Nanovo = false;


        }


    }
}
