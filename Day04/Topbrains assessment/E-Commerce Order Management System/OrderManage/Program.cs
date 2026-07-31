// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         string[] orders =
//         {
//             "ORD1001|John Smith|Laptop|2|$1200|Delivered",
//             "ORD1002|Alice Brown|Mobile|1|$800|Pending",
//             "ORD1003|David Wilson|Keyboard|3|$150|Shipped",
//             "ORD1004|Emma Davis|Monitor|2|$350|Delivered",
//             "ORD1005|James Miller|Mouse|5|$50|Pending"
//         };

//         // display all order details
//         foreach (string order in orders)
//         {
//             string[] details = order.Split('|');

//             Console.WriteLine("Order ID : " + details[0]);
//             Console.WriteLine("Customer : " + details[1]);
//             Console.WriteLine("Product  : " + details[2]);
//             Console.WriteLine("Quantity : " + details[3]);
//             Console.WriteLine("Price    : " + details[4]);
//             Console.WriteLine("Status   : " + details[5]);
//             Console.WriteLine();
//         }

//         // convert customer names to upper case
//         Console.WriteLine("Converted Customer names to upper case");
//         foreach (string order in orders)
//         {
//             string[] details = order.Split('|');
//             Console.WriteLine(details[1].ToUpper());
//         }
//         Console.WriteLine();

//         // display customer initials
//         Console.WriteLine("Displaying initials of Customer names: ");
//         foreach (string order in orders)
//         {
//             string[] details = order.Split('|');
//             string[] name = details[1].Split(' ');

//             Console.WriteLine(details[1] + " -> " + name[0][0] + name[1][0]);
//         }
//         Console.WriteLine();

//         // display delivered orders
//         Console.WriteLine("Displaying delivered orders: ");
//         foreach (string order in orders)
//         {
//             if (order.Contains("Delivered"))
//             {
//                 string[] details = order.Split('|');
//                 Console.WriteLine(details[0]);
//             }
//         }
//         Console.WriteLine();

//         // count total orders
//         Console.WriteLine("Total Orders = " + orders.Length);
//         Console.WriteLine();

//         //  Search Order by Order ID
//         Console.Write("Enter Order ID: ");
//         string orderId = Console.ReadLine();

//         foreach (string order in orders)
//         {
//             string[] details = order.Split('|');

//             if (details[0] == orderId)
//             {
//                 Console.WriteLine("Customer : " + details[1]);
//                 Console.WriteLine("Product  : " + details[2]);
//                 Console.WriteLine("Status   : " + details[5]);
//                 break;
//             }
//         }
//         Console.WriteLine();

//         // extract price
//         foreach (string order in orders)
//         {
//             string[] details = order.Split('|');
//             Console.WriteLine(details[4].Replace("$", ""));
//         }


//     }
// }







