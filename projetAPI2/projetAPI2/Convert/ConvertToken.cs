using projetAPI2.DTO;
using projetAPI2.Models;

namespace projetAPI2
{
    public class ConvertToken
    {

        public static AspNetUserToken ConvertTokens(AspNetUser user)
        {

            AspNetUserToken test = new AspNetUserToken
            {
                UserId = user.Id,
                LoginProvider = "TEST",
                Name = "test",
                Value = "Tamere",
            };
            return test;
        }
    }
}
