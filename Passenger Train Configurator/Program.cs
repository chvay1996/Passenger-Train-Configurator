using System;
using System.Collections.Generic;

namespace Passenger_Train_Configurator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Trains trains = new Trains();
            Van van = new Van();

            Console.CursorVisible = false;
            bool isTrains = true;
            byte repetitions = 15;

            while (isTrains)
            {
                Console.SetCursorPosition(0, 0);
                dispatcher.SendTrain(trains, van);

                Console.SetCursorPosition(0, repetitions);
                dispatcher.Direction();
                van.TrainClass();
                dispatcher.PassengersNum();
                trains.Wagons(dispatcher, van);

                Console.Clear();
            }
        }
    }

    class Van
    {
        private int _economyClass = 60;
        private int _secondClass = 40;
        private int _firstClass = 30;
        public int Capacity { get; private set; }

        public void TrainClass()
        {
            Console.Write("Выберите класс поезда. 1)Эконом - 60 мест в вагоне. 2)Купе - 40 мест в вагоне. 3)Люкс - 30 мест в вагоне\t");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Capacity = _economyClass;
                    break;
                case 2:
                    Capacity = _secondClass;
                    break;
                case 3:
                    Capacity = _firstClass;
                    break;
                default:
                    Console.WriteLine("ввод неверный");
                    break;
            }
        }

        public void RestartVan()
        {
            Capacity = 0;
        }
    }

    class Dispatcher
    {

        Random random = new Random();
        private string _start;
        private string _finish;

        public int Passengers { get; private set; }

        public void Direction()
        {
            Console.Write("Введите пункт отправления ");
            _start = Convert.ToString(Console.ReadLine());

            Console.Write("Введите пункт прибытия ");
            _finish = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Маршрут {_start} - {_finish} построен");
        }

        public void PassengersNum()
        {
            int minPerss = 400;
            int maxPerss = 900;
            Passengers = random.Next(minPerss, maxPerss);
        }

        public void SendTrain(Trains trains, Van van)
        {
            if (Passengers > 0)
            {
                Console.WriteLine($"По маршруту {_start} - {_finish} едет поезд на {trains.Wagon} вагонов\n");
                Console.WriteLine($"Продано билетов {Passengers}, вместительность вагонов {van.Capacity}\n");
                Console.WriteLine("Нажмите любую кнопку для построения нового маршрута...\n");
                Restart(trains, van);
            }

            else Console.WriteLine("Маршутов нет");
        }

        private void Restart(Trains trains, Van van)
        {
            trains.WagonsRestart();
            Passengers = 0;
            van.RestartVan();
        }
    }

    class Trains
    {
        public byte Wagon { get; private set; }

        public byte Wagons(Dispatcher dispatcher, Van van)
        {
            bool isWagons = true;
            int numberPassengers = dispatcher.Passengers;

            while (isWagons)
            {
                if (numberPassengers >= 0)
                {
                    numberPassengers -= van.Capacity;
                    Wagon += 1;
                }
                else isWagons = false;
            }
            return Wagon;
        }

        public void WagonsRestart()
        {
            Wagon = 0;
        }
    }
}
/*Задача:
У вас есть программа, которая помогает пользователю составить план поезда.
Есть 4 основных шага в создании плана:
-Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
-Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
-Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
-Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии.*/
