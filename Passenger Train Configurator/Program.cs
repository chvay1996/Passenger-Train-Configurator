using System;

namespace Passenger_Train_Configurator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Trains trains = new Trains();
            bool isTrains = true;
            byte repetitions = 15;

            while (isTrains)
            {
                Console.SetCursorPosition(0, repetitions);
                trains.Direction();
                trains.TrainClass();
                trains.PassengersNum();
                trains.Wagons();

                Console.SetCursorPosition(0, 0);
                trains.SendTrain();
            }
        }
    }

    class Trains
    {
        Random random = new Random();

        private int _capacity;
        private int _economyClass = 60;
        private int _secondClass = 40;
        private int _firstClass = 30;
        private string _start;
        private string _finish;
        private int _passengers;
        private byte _wagons = 0;

        public void Direction()
        {
            Console.Write("Введите пункт отправления ");
            _start = Convert.ToString(Console.ReadLine());

            Console.Write("Введите пункт прибытия ");
            _finish = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Маршрут {_start} - {_finish} построен");
        }

        public void TrainClass()
        {
            Console.Write("Выберите класс поезда. 1)Эконом - 60 мест в вагоне. 2)Купе - 40 мест в вагоне. 3)Люкс - 30 мест в вагоне\t");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    _capacity = _economyClass;
                    break;
                case 2:
                    _capacity = _secondClass;
                    break;
                case 3:
                    _capacity = _firstClass;
                    break;
                default:
                    Console.WriteLine("ввод неверный");
                    break;
            }
        }

        public void PassengersNum()
        {
            int minPerss = 400;
            int maxPerss = 900;
            _passengers = random.Next(minPerss, maxPerss);
        }

        public byte Wagons()
        {
            bool isWagons = true;
            int numberPassengers = _passengers;

            while (isWagons)
            {
                if (numberPassengers >= 0)
                {
                    numberPassengers -= _capacity;
                    _wagons += 1;
                }
                else isWagons = false;
            }
            return _wagons;
        }

        public void SendTrain()
        {
            Console.WriteLine($"По маршруту {_start} - {_finish} едет поезд на {_wagons} вагонов\n");
            Console.WriteLine($"Продано билетов {_passengers}, вместительность вагонов {_capacity}\n");
            Console.WriteLine("Нажмите любую кнопку для построения нового маршрута...\n");
            Console.ReadLine();
            Console.Clear();
            Restart();
        }

        private void Restart()
        {
            _wagons = 0;
            _passengers = 0;
            _capacity = 0;
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
