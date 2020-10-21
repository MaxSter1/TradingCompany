using System;

namespace DTO
{
    public class ProductsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public int Price { get; set; }

        public string GetInfo()
        {
            string info = Id.ToString() + " " + Name + " " + CategoryId.ToString()+ " " + Price;
            return info;
        }
    }

}