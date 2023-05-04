using projetAPI2.DTO;
using projetAPI2.Models;
using projetAPI2.Methode;
using System.Diagnostics;

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
            Debug.WriteLine("--------------------------------------------------------------------------------------------"+category.IdCategory+"     "+ category.CatName);
            return category;
        }


    }
}
