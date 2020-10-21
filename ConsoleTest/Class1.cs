using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Data Source=COMPUTER-SQLEXPRESS02;Initial Catalog=KursovaPZ;Integrated Security=True";
            ProductsDAL dal = new ProductsDAL(connStr);
            //UserDTO currentUser = null;
            ProductsDTO currentproduct = null;

            char menuItem;
            char menuUpdateItem;


            while (true)
            {
                ShowMenuItems();
                menuItem = char.Parse(Console.ReadLine());

                switch (menuItem)
                {
                    case 'l':
                        foreach (ProductsDTO pproduct in dal.GetAllProducts())
                        {
                            Console.WriteLine(pproduct.GetInfo());
                        }
                        break;
                    case 'f':

                        Console.Write("Enter Id : ");
                        int iD;
                        Int32.TryParse(Console.ReadLine(), out iD);
                        currentproduct = dal.GetProductById(iD);
                        Console.WriteLine(currentproduct.GetInfo());

                        break;

                    case 'u':

                        Console.Write("Enter Id : ");
                        int id;

                        Int32.TryParse(Console.ReadLine(), out id);
                        currentproduct = dal.GetProductById(id);
                        if (currentproduct != null)
                        {
                            Console.WriteLine(currentproduct.GetInfo());

                            ShowMenuUpdateItems();

                            while (true)
                            {

                                menuUpdateItem = Console.ReadLine()[0];
                                switch (menuUpdateItem)
                                {
                                    case '1':

                                        Console.Write("Enter Price : ");
                                        currentproduct.Price = Convert.ToInt32(Console.ReadLine());
                                        break;


                                }
                                Console.WriteLine("For save and exit press e ");

                                menuUpdateItem = Console.ReadLine()[0];
                                if (menuUpdateItem == 'e')
                                {

                                    dal.UpdatePrice(currentproduct);

                                    break;
                                }
                            }
                        }
                        else
                            Console.WriteLine("User not found");

                        break;

                    case 'e':
                        return;
                }

                Console.WriteLine("Pres any key to continue");
                Console.ReadKey();


            }
        }


        static void ShowMenuItems()
        {
            Console.Clear();
            Console.WriteLine("l: List of products");
            Console.WriteLine("f: Find product by Id");
            Console.WriteLine("u: update prodoct price");
            Console.WriteLine("e: Exit");
        }

        static void ShowMenuUpdateItems()
        {
            Console.WriteLine("1: Price");
        }
    }
}

