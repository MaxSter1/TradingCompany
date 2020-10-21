using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Drawing;
using DTO;
namespace DAL
{
    public class ProductsDAL : IProductsDAL
    {
        private string connectionString;

        public ProductsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserDTO CreateUser(UserDTO User)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Users (FirstName,LastName, Gender, Address,RoleId,Mail,Tel,BankCard) output INSERTED.Id values (@FirstName,@LastName, @Gender, @Address,@RoleId,@Mail,@Tel,@BankCard)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@FirstName", User.FirstName);
                comm.Parameters.AddWithValue("@LastName", User.LastName);
                comm.Parameters.AddWithValue("@RoleId", User.RoleId);
                comm.Parameters.AddWithValue("@Login", User.Login);
                comm.Parameters.AddWithValue("@Phone", User.Phone);
                conn.Open();


                User.Id = Convert.ToInt32(comm.ExecuteScalar());
            }


            return User;
        }

        public List<ProductsDTO> GetAllProducts()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Products";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<ProductsDTO> items = new List<ProductsDTO>();
                while (reader.Read())
                {

                    items.Add(new ProductsDTO
                    {
                        Id = Convert.ToInt32(reader["ItemID"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToInt32(reader["Price"]),
                        CategoryId = Convert.ToInt32(reader["OnStock"])
                    });
                }

                return items;
            }
        }


        public ProductsDTO UpdatePrice(ProductsDTO Product)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "UPDATE  Products SET Price = @Price " + " WHERE Id = @Id ";
                comm.Parameters.Clear();

                comm.Parameters.AddWithValue("@Id", Product.Id);
                comm.Parameters.AddWithValue("@FirstName", Product.Price);

                conn.Open();

                Convert.ToInt32(comm.ExecuteScalar());

                return Product;
            }



        }


        public List<ProductsDTO> GetAllProductsSorted(int SortParameter)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {



                if (SortParameter == 1)
                {
                    comm.CommandText = "select * from Item order by Price ASC";
                }
                if (SortParameter == 2)
                {
                    comm.CommandText = "select * from Item order by Name DESC";

                }
                if (SortParameter == 3)
                { comm.CommandText = "select * from Item order by Id DESC"; }

                else
                { comm.CommandText = "select * from Item"; }





                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<ProductsDTO> products = new List<ProductsDTO>();
                while (reader.Read())
                {

                    products.Add(new ProductsDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = (reader["Name"]).ToString(),
                        CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        Price = Convert.ToInt32(reader["Price"])
                    });
                }
                return products;
            }
        }


        public ProductsDTO GetProductById(int Id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                ProductsDTO product = new ProductsDTO();

                comm.CommandText = "select * from [Products] where Id=@Id";

                comm.Parameters.AddWithValue("@Id", Id);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    product = new ProductsDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = (reader["Name"]).ToString(),
                        CategoryId = Convert.ToInt32(reader["CategoryId"]),
                        Price = Convert.ToInt32(reader["Price"])
                    };
                }

                return product;
            }
        }

        public void DeleteProduct(int Id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Products where Id = @Id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Id", Id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

    }
}