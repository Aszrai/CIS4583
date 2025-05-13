using CIS4583.Model;

namespace CIS4583.IRepository
{
    public interface IProductRepository
    {
        List<Product> Product_Categories_SelectList(Product _ProductLine);
        bool Product_Delete(Product ProductLine);
        bool Product_Insert(Product ProductLine);
        Product Product_Select(Product _ProductLine);
        List<Product> Product_SelectList();
        List<Product> Product_Supplier_SelectList(Product _ProductLine);
        bool Product_Update(Product ProductLine);
    }
}