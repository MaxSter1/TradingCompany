using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public interface IProductsDAL
    {
        UserDTO CreateUser(UserDTO User);

        List<ProductsDTO> GetAllProducts();
        ProductsDTO UpdatePrice(ProductsDTO Product);

        List<ProductsDTO> GetAllProductsSorted(int SortParameter);
        ProductsDTO GetProductById(int Id);

    }



}
