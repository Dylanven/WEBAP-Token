using projetAPI2.DTO;
using projetAPI2.Models;
using projetAPI2.Methode;

namespace projetAPI2.Convert
    
{
    public class ConvertCategory
    {
        public static Category ConvertCategories(Categorie cat)
        {
            Category category = new Category
            {
               
            IdCategory = RandonID.randonId(),
                CatName = cat.CatName,
            };
            return category;
        }


    }
}
