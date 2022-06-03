using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://www.youtube.com/watch?v=GAq9QrBvVtw

/*Абстрактный класс
 
Если какой-то класс наследуется от абстрактного класса, и этот авбстрактный класс имеет абстрактные методы
то класс наследник в обязательном порядке должен реализовывать абстрактные методы авбстрактного класса.
(То есть, по анологии, все наследники класса Weapon будут иметь метод Fire)

Свойство это тот же самый метод но который маскируется под поле, пытается себя вести как переменная, сделанно это для упрощения работы с геттерами и сеттерами.
Так как свойство это по сути метод, то он также может быть абстрактным и виртуальным и его можно переопределить в наследниках
 */
namespace CSharp76_abstract_class
{
    /// <summary>
    /// Абстрактное оружие
    /// </summary>
    abstract class Weapon
    {
        /// <summary>
        /// Абстрактное свойство
        /// </summary>
        public abstract int Damage { get; }

        /// <summary>
        /// Абстрактный метод Fire 
        /// (абстрактные методы не имеют реализации, такие методы могут находится только в абстрактных классах)
        /// </summary>
        public abstract void Fire();

        /// <summary>
        /// 
        /// </summary>
        public void ShowInfo()
        {
            //Выводим в консоль имя типа данных и урон наносимый оружием
            //GetType метод типа Object
            Console.WriteLine($"{GetType().Name} Damage: {Damage}");
        }
    }

    class Gun : Weapon
    {
        public override int Damage { get { return 5; } }

        public override void Fire()
        {
            Console.WriteLine("Пыщ!");
        }
    }

    class LaserGun : Weapon
    {
        public override int Damage { get { return 8; } }
        public override void Fire()
        {
            Console.WriteLine("Пиу!");
        }
    }

    class Bow : Weapon
    {
        ///<summary>
        /// эта запись является лямбда выражением, она равнозначна записи: public override int Damage { get { return 3; } }
        /// </summary>
        public override int Damage => 3;

        public override void Fire()
        {
            Console.WriteLine("Чпуньк!");
        }
    }
    class Player
    {
        public void Fire(Weapon weapon)
        {
            weapon.Fire();
        }

        /// <summary>
        ///Проверка информации об оружии которое будет использоваться
        /// </summary>
        public void CheckInfo(Weapon weapon)
        {
            weapon.ShowInfo();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Player player = new Player();

            //Массив типа Weapon элементами которого являются объекты классов: Gun, LaserGun, Bow.
            //Так как эти классы унаследованы от класса Weapon, то мы можем их помещать в массив типа Weapon
            //Хоть мы не можем создавать экземпляр абстрактного класса Weapon, мы можем использовать его в качестве ссылки,
            //как тип данных, для того чтобы хранить в нем его наследников
            Weapon[] inventory = {new Gun(), new LaserGun(), new Bow() };

            foreach (var item in inventory)
            {
                player.CheckInfo(item);
                player.Fire(item);
                Console.WriteLine();
            }
        }
    }
}
