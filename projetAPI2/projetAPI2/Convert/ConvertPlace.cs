using projetAPI2.DTO;
using projetAPI2.Models;

namespace projetAPI2.Convert
{
    public class ConvertPlace
    {
        public static Place ConvertPlaces(PlaceDTO place, int id)
        {

            /*recuperer le CouName de country via l'id de country */

            
            Place newPlace = new Place
            {
                IdCountry = id,
                PlaAddress = place.PlaAddress,
                


            };
            return newPlace;
        }
    }
}
