using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public class Library
    {
        public int Totalbooks;
        public void Booksborrow(int count) {
            if (Totalbooks >= count)
            {
                Totalbooks -= count;
                Console.WriteLine($"Books borrowed is {count}\n Remaining books {Totalbooks}");

            }
            else { Console.WriteLine("Insufficient amount of books"); }
        }
        public void ReserveBooks(int count) {
            Console.WriteLine($"Books reserved by Teacher {count}");
        }
        public void Addbooks(int count) {
            Totalbooks += count;
            Console.WriteLine($"Books added by librarian {count}\n Remaining books{Totalbooks}");
        }
    }
}
