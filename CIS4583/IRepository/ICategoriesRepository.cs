using System.Collections.Generic;
using CIS4583.Model;

namespace CIS4583.IRepository
{
    public interface ICategoriesRepository
    {
        bool Categories_Delete(Categories CategoriesLine);
        bool Categories_Insert(Categories CategoriesLine);
        Categories Categories_Select(Categories _CategoriesLine);
        List<Categories> Categories_SelectList();
        bool Categories_Update(Categories CategoriesLine);
    }
}
