using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Game
    {
        private Gamer _gamer;
        public Gamer[] gamers;
        private int step; // ход 

        public Game (string name , int  countBot)
        {
           if(string.IsNullOrWhiteSpace(name))
           {
                throw new Exception("Имя не  может  быть  пустым");
           }

           if(countBot <=0)
           {
                throw new Exception("кол-во  ботов  не может  быть отрицательным");
           }

            try
            {
                _gamer = new Gamer(name);
                gamers = new Gamer[countBot];
                for (int i = 0; i < gamers.Length; i++)
                {
                    gamers[i] = new Gamer();
                }
                step = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void NextStep ()
        {
            step++;
            Console.WriteLine("ход №" + step);
            Console.WriteLine(_gamer.IsStatus());
            Gamer enemy = GetRandomEnyme();

            if (_gamer.IsLive()== false)
            {
                Console.WriteLine("Игра окончена");
                return; 
            }
            
            if(RandomGamerAtack())
            {
                _gamer.TheBattle(enemy.Attack);

                if(_gamer.IsLive() == true)
                {
                    enemy.TheBattle(_gamer.Attack);
                }
            }
            else
            {
                 enemy.TheBattle(_gamer.Attack);
                 if (enemy.IsLive() == true)
                {
                    _gamer.TheBattle(enemy.Attack);
                }
            }
            Console.WriteLine(_gamer.IsStatus());
            Console.WriteLine(enemy.IsStatus());
        }

        private Gamer GetRandomEnyme()
        {
            Random random = new Random();
            Gamer gamer =   gamers[random.Next(0, gamers.Length)];

            if (gamer.IsLive() ==false)
            {
                return GetRandomEnyme();
            }
            return gamer;
        }

        private bool RandomGamerAtack()
        {
            Random random = new Random();
            if(random.Next(0,2) >1)
            { return true; }
            else
            { return false; }
        }

    }
}
