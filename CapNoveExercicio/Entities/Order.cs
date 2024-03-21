using CapNoveExercicio.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapNoveExercicio.Entities {
    internal class Order {


        public DateTime Moment { get; set; } 
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public Product Product { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() {
        }

        public Order(DateTime moment, OrderStatus status, Client client, Product product) {
            Moment = moment;
            Status = status;
            Client = client;
            Product = product;
        }

        public void AddItem(OrderItem item) {
            Items.Add(item);

        }

        public void RemoveItem(OrderItem item) {
            Items.Remove(item);

        }
        
        public double Total() {
            double valorFinal = 0.0;
            foreach (OrderItem item in Items) {
                valorFinal += item.SubTotal();

            }

            return valorFinal;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendLine();
            sb.AppendLine("ORDER SUMMARY: ");
            sb.Append("Order moment: ");
            sb.AppendLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items: ");

            foreach (OrderItem item in Items) {
                sb.Append(item.Product.Name);
                sb.Append(", $");
                sb.Append(item.Product.Price);
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);
                sb.Append(", Subtotal: ");
                sb.AppendLine(item.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.Append("Total Price: $");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));
            
            return sb.ToString();

        }






    }
}
