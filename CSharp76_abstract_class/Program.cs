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
 */
namespace CSharp76_abstract_class
{
    /// <summary>
    /// Абстрактное оружие
    /// </summary>
    abstract class Weapon
    {
        /// <summary>
        /// Абстрактный метод Fire 
        /// (абстрактные методы не имеют реализации, такие методы могут находится только в абстрактных классах)
        /// </summary>
        public abstract void Fire();
    }

    class Gun : Weapon
    {
      
        public override void Fire()
        {
            Console.WriteLine("Пыщ!");
        }
    }

    class LaserGun : Weapon
    {
        public override void Fire()
        {
            Console.WriteLine("Пиу!");
        }
    }

    class Bow : Weapon
    {
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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Player player = new Player();

            Gun gun = new Gun();

            //Передаем объект класса Gun в метод Fire обекту типа Player
            player.Fire(gun);
        }
    }
}
