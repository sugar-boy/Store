using System;
using System.Collections.Generic;

namespace ConsoleApp10
{
    public class Product
    {
        public string Name;
        public decimal Price;

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Print()
        {
            Console.WriteLine($"{Name} {Price}");
        }
    }

    public class Order
    {
        public List<Product> Products;
        public decimal FullPrice;

        public Order(List<Product> products)
        {
            Products = products;

            FullPrice = 0;

            foreach (var product in products)
            {
                FullPrice += product.Price;
            }
        }
    }

    public class Store
    {
        public List<Product> Products;
        public List<Product> Basket;
        public List<Order> Orders;

        public Store()
        {
            Products = new List<Product>
            {
            new Product("Хлеб", 25),
            new Product("Молоко", 50),
            new Product("Мороженное", 45),
            new Product("Сок", 100),
            new Product("Яблоко", 15),
            new Product("Масло", 30)
            };

            Basket = new List<Product>();
            Orders = new List<Order>();
        }

        public void ShowCatalog()
        {
            Console.WriteLine("Каталог продуктов: ");
            ShowProducts(Products);
        }

        public void ShowBasket()
        {
            Console.WriteLine("Корзина продуктов: ");
            ShowProducts(Basket);
        }


        public void ShowProducts(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i}. {products[i].Name} {products[i].Price}");
            }
        }

        public void AddToBasket(int numberProduct)
        {
            Basket.Add(Products[numberProduct]);
            Console.WriteLine($"{Products[numberProduct].Name} успешно добавлен в корзину.");
            Console.WriteLine($"В корзине {Basket.Count} продуктов.");
        }

        public void CreateOrder()
        {
            Order order = new Order(Basket);
            Orders.Add(order);
            Basket.Clear();
            Console.WriteLine($"К оплате {order.FullPrice}.");
        }
    }
        
    class Program
    {
        static void Main(string[] args)
        {

            Store onlineStore = new Store();

            Console.WriteLine("Здравствуйте, выберите действие:");

            while(true)
            {
                Console.WriteLine("______________________________________________");
                Console.WriteLine("1. Показать каталог продуктов.");
                Console.WriteLine("2. Добавление продукта в коризну.");
                Console.WriteLine("3. Просмотр корзины.");
                Console.WriteLine("4. Оформление заказа.");
                Console.WriteLine("______________________________________________");
                int numberAction = int.Parse(Console.ReadLine());
                switch (numberAction)
                {
                    case 1:
                        onlineStore.ShowCatalog();
                        break;
                    case 2:
                        onlineStore.ShowCatalog();
                        Console.WriteLine("Напишите номер продукта, который нужно добавить в корзину. " +
                            "\nЕсли хотите прекратить добавлять продукты в корзину напишите - -1.");
                        int productNumber = 0;
                        do
                        {
                            productNumber = Convert.ToInt32(Console.ReadLine());
                            if (productNumber != -1)
                            {
                                onlineStore.AddToBasket(productNumber);
                            }
                        } while (productNumber != -1);
                        break;
                    case 3:
                        onlineStore.ShowBasket();
                        break;
                    case 4:
                        onlineStore.CreateOrder();
                        break;
                    default:
                        Console.WriteLine("Вы ничего не выбрали, выберите номер действия");
                        break;
                }
            }
            
        }
    }
}
