using projetAPI2.Models;
using projetAPI2.DTO;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.Intrinsics.Arm;
using projetAPI2.Methode;

namespace projetAPI2.Convert
{
    public class ConvertUser
    {
        public static AspNetUser ConvertToDTO(NewUser user)
        {

          


            AspNetUser test = new AspNetUser
            {
            Id = Guid.NewGuid().ToString(),
            Email = user.Email,
               UserName = user.UserName,
                /* PasswordHash = HashPasword.hashPasword(user.Password),*/
                PasswordHash = user.Password,
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false
            };
            return test;
        }
    }
}

