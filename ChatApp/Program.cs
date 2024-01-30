﻿using ChatNetwork;
using System;
using System.Net;

namespace ChatApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                var s = new Server<IPEndPoint>(new NetMQMessageSource());
                s.Work();
            }
            else
            if (args.Length == 3)
            {
                var c = new Client<IPEndPoint>(args[0], new NetMQMessageSourceClient(int.Parse(args[2]), args[1], 5555));
                c.Start();
            }
            else
            {

                Console.WriteLine("Для запуска сервера введите ник-нейм как параметр запуска приложения");
                Console.WriteLine("Для запуска клиента введите ник-нейм и IP сервера как параметры запуска приложения");
            }
        }
    }
}
