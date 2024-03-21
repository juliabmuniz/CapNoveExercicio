using CapNoveExercicio.Entities.Enum;
using System;
using CapNoveExercicio.Entities;
using System.Globalization;

namespace CapNoveExercicio
{
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date: ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());
        
            Client c1 = new Client(name, email, birthdate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status (PendingPayment/ Processing/ Shipped/ Delivered): ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            Product p2 = new Product();
            Order o = new Order(DateTime.Now, status, c1, p2);

            for (int i = 1; i <= n; i++) {
                Console.WriteLine("Enter #{0} item data: ", i);
                Console.Write("Product name: ");
                string productname = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
               
                Product p1 = new Product(productname, price);
                OrderItem o1 = new OrderItem(quantity, price, p1);
                o.AddItem(o1);

            }

           
           
            Console.WriteLine(o);








        }
    }
}