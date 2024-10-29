// See https://aka.ms/new-console-template for more information
using DependencyInversionPrinciple;


namespace DependencyInversionPrinciple {
    public class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Console.WriteLine("Books added are : \n");
            library.Addbooks(10);

            Console.WriteLine("Books borrowed are : \n");
            library.Booksborrow(5);

            Console.WriteLine("Books reserved are : \n");
            library.ReserveBooks(2);

            Console.ReadLine();
            

        }
    }
}