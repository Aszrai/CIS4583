using CIS4583.Model;

namespace CIS4583.IRepository
{
    public interface ISupplierRepository
    {
        bool Supplier_Delete(Supplier SupplierLine);
        bool Supplier_Insert(Supplier SupplierLine);
        Supplier Supplier_Select(Supplier _SupplierLine);
        List<Supplier> Supplier_SelectList();
        bool Supplier_Update(Supplier SupplierLine);
    }
}