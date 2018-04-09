using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    class Program {
        

        static void Main(string[] args) {

            Action a = new Action();
            a.Read();

            Console.ReadKey();
        }


    }

    public class Action {
        ModelContext db = new ModelContext();
        public void Read() {
            Console.WriteLine(db.Kullanici.SingleOrDefault().Isim);
        }

    }

}
