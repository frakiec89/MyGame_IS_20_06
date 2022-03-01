using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Gamer
    {
        #region поля и  свойства

        private string[] _nameBot = new string[]
        {
         "Карпов Иван Романович" , "Терехов Лука Ярославович" , "Мухина Мария Семёновна" , "Власова Полина Александровна"
        };

        public string NickName { get; private set; }

        /// <summary>
        /// уровень жизни 
        /// </summary>
        public double HP { get; private set; }
        /// <summary>
        /// Броня
        /// </summary>
        public double Armor { get; private set; }
        /// <summary>
        /// сила атаки
        /// </summary>
        public double Attack { get; private set; }
        private bool _isHuman;

        #endregion

        #region конструкторы
        public Gamer() // бот 
        {
            Random random = new Random();
            HP = random.Next(50, 100);// случайно от 50 до 100
            Attack = random.Next(1, 5);// случайно от 1 до 5
            Armor = random.Next(1, 5); // случайно от 1 до 5
            _isHuman = false; // не человек 

            NickName = _nameBot[random.Next(0, _nameBot.Length)]; // случайное  имя
        }
        public Gamer(string name) : this() // человек с случайными  параметрами 
        {
            if (string.IsNullOrWhiteSpace(name)) // если пустое  имя
            {
                throw new ArgumentException("Имя игрока не может  быть  пустым"); // исключение
            }
            NickName = name;
            _isHuman = true;
        }
        #endregion

        public bool IsLive ()
        {
            if (HP > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// получаем  статус  игрока 
        /// </summary>
        /// <returns></returns>
        public string IsStatus ()
        {
            if(IsLive())//если живой
            {
                return $"Игрок  - {NickName}\nУровень жизни - {HP}, броня -{Armor}, уровень атаки- {Attack}.";
            }
            else
            {
                return $"Игрок  - {NickName} мертв";
            }
        }

        public void TheBattle (double attackEnemy)
        {
            if(attackEnemy<=0)
            {
                return;
            }
            Random random = new Random();
            if(IsLive())
            {
                HP -= (attackEnemy + (double)random.Next(-1, 2)) / Armor;
            }
        }
    }
}
