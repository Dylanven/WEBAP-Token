using projetAPI2.Models;

namespace projetAPI2.Convert
{
    public class ConvertPlace
    {
        public static Place ConvertTokens(Place place)
        {

            /*recuperer le CouName de country via l'id de country */

           
            



            Place test = new Place
            {
                PlaAddress = place.PlaAddress,
                
                
            };
            return test;
        }
    }
}
