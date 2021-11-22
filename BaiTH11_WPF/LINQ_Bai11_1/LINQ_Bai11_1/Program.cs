using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Bai11_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var brands = new List<Brand>()
            {
                new Brand{ID = 1, Name = "VinGroup"},
                new Brand{ID = 2, Name = "Samsung"},
                new Brand{ID = 3, Name = "FPT"},
            };
            var products = new List<Product>()
            {
                new Product(1,"O to", 400, new string[] {"Do", "Trang", "Den"}, 1),
                new Product(2,"Dien thoai", 400, new string[] {"Den", "Xanh"}, 2),
                new Product(3,"May giat", 500, new string[] {"Trang"}, 2),
                new Product(4,"Tu lanh", 200, new string[] {"Trang", "Den"}, 2),
                new Product(5,"Laptop", 300, new string[] {"Do", "Trang", "Xam"}, 3),
                new Product(6,"Dieu hoa", 500, new string[] {"Trang", "Den"}, 2),
                new Product(7,"Xe may", 600, new string[] {"Trang", "Den"}, 1)
            };
            //---------------------------------------------------
            var ketqua1 = from Product in products
                          select Product;
            Console.WriteLine("\t\tIN DANH SACH SAN PHAM\n");
            foreach(var product in ketqua1)
                Console.WriteLine(product);
            Console.WriteLine();
            //---------------------------------------------------
            var ketqua2 = from Product in products
                          select Product.Name;
            var ketqua22 = products.Select(p => p.Name);
            Console.WriteLine("\t\tIN DANH SACH -NAME- SAN PHAM\n");
            foreach (var product in ketqua22)
                Console.WriteLine(product);
            Console.WriteLine();
            //---------------------------------------------------
            var ketqua3 = products.Select(p => new
            {
                ten = p.Name,
                mausau = string.Join(",", p.Colors)
            });
            Console.WriteLine("\t\tIN DANH SACH -NAME COLORS- SAN PHAM\n");
            foreach (var product in ketqua3)
                Console.WriteLine(product.ten + " - " + product.mausau);
            Console.WriteLine();
            //---------------------------------------------------
            var ketqua4 = products.Where(p => p.Price == 400);
            Console.WriteLine("\t\tIN DANH SACH -PRICE- SAN PHAM\n");
            foreach (var product in ketqua4)
                Console.WriteLine(product);
            Console.WriteLine();
            //---------------------------------------------------
            var ketqua5 = products.Where(p => (p.Price >= 500 && p.Price < 600) || p.Name.Contains("e"));
            Console.WriteLine("\t\tIN DANH SACH -Price >= 500 && < 600- SAN PHAM\n");
            foreach (var product in ketqua5)
                Console.WriteLine(product);
            Console.WriteLine();
            //---------------------------------------------------
            var ketqua6 = (products.Where(p => p.Price <= 400)).OrderByDescending(p => p.Price);
            Console.WriteLine("\t\tIN DANH SACH -PRICE DESC- SAN PHAM\n");
            foreach (var product in ketqua6)
                Console.WriteLine(product);
            Console.WriteLine();
            //---------------------------------------------------
            var ketqua7 = (products.Where(p => p.Price <= 500)).GroupBy(p => p.Brand);
            Console.WriteLine("\t\tIN DANH SACH -Brand GroupBy- SAN PHAM\n");
            foreach (var group in ketqua7)
            {
                Console.WriteLine(group.Key);
                foreach(var product in group)
                    Console.WriteLine(product);
            }
            Console.WriteLine();
            //---------------------------------------------------
            var ketqua8 = products.Join(brands, p => p.Brand, b => b.ID,
                (p, b) =>{
                    return new
                    {
                        name = p.Name,
                        price = p.Price,
                        brand = b.Name
                    };
                });
            Console.WriteLine("\t\tIN DANH SACH -Join- SAN PHAM\n");
            foreach (var product in ketqua8)
                Console.WriteLine($"{product.name, -10} {product.price, 5} {product.brand, -10}");
            Console.WriteLine();
        }
    }
}
