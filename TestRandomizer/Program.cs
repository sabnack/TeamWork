﻿using System;
using System.Threading;
using IMarket.DAL;
using IMarket.Models.Models;
using IMarket.Models.Models.Enums;

namespace TestRandomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            new Randomizer().Start();
        }

        class Creator
        {

        }

        class Randomizer
        {

            public void Start()
            {
                var threadBuy = new Thread(Buy);
                var threadSell = new Thread(Sell);
                threadBuy.Start();
                threadSell.Start();

                ConsoleKeyInfo key;

                do
                {
                    key = Console.ReadKey();

                    if (key.Key != ConsoleKey.Escape) continue;
                    threadBuy.Interrupt();
                    threadSell.Interrupt();
                } while (key.Key != ConsoleKey.Escape);

            }

            private static void Buy()
            {
                var rnd = new Random();
                while (true)
                {
                    var color = ((Color) rnd.Next(3)).ToString();
                    switch (rnd.Next(5))
                    {
                        case 1:
                            var closeType = (ClothesType) rnd.Next(3);
                            Storage.AddToStorage(new ClothesModel
                            {
                                ClothesType = closeType,
                                Color = color,
                                DeliveryTime = DateTime.Now,
                                //Material = "Cotton",
                                Name = $"{color} {closeType}",
                                Size = rnd.Next(36,58).ToString(),
                                Weight = (double)rnd.Next(1,10)/10,
                                Type = ItemType.Clothes
                            });
                            break;
                        case 2:
                            var ballType = (BallType) rnd.Next(4);
                            Storage.AddToStorage(new BallModel
                            {
                                BallType = ballType,
                                Color = color,
                                DeliveryTime = DateTime.Now,
                                Name = $"{color} {ballType}",
                                Diameter = rnd.Next(18,28),
                                Weight = (double)rnd.Next(1,10) / 10,
                                Type = ItemType.Ball
                            });
                            break;
                        case 3:
                            var sportsAccessoriesType = (SportsAccessoriesType)rnd.Next(3);
                            Storage.AddToStorage(new SportsAccessoriesModel
                            {
                                SportsAccessoriesType = sportsAccessoriesType,
                                Color = color,
                                DeliveryTime = DateTime.Now,
                                Name = $"{color} {sportsAccessoriesType}",
                                Weight = (double)rnd.Next(1,10) / 10,
                                Type = ItemType.SportAccessories
                            });
                            break;
                        case 4:
                            var winterSportsType = (WinterSportsType) rnd.Next(3);
                            Storage.AddToStorage(new WinterSportsModel
                            {
                                WinterSportsType = winterSportsType,
                                Color = color,
                                DeliveryTime = DateTime.Now,
                                Name = $"{color} {winterSportsType}",
                                Lenght = (double)rnd.Next(10,15) / 10,
                                Weight = (double)rnd.Next(1,20) / 10,
                                Type = ItemType.WinterSport
                            });
                            break;
                    }
                    Thread.Sleep(rnd.Next(15000));
                }
            }

            //private void GetEnum()


            private static void Sell()
            {
                var rnd = new Random();
                while (true)
                {
                    var test = Storage.GetAll();
                    foreach (var c in test)
                    {
                        Console.WriteLine($"{c.Name} {c.Color} {c.DeliveryTime} {c.Weight:F} {c.Type}");
                    }

                    Console.WriteLine("Sell");
                    Thread.Sleep(rnd.Next(15000));
                }
            }

        }
    }
}