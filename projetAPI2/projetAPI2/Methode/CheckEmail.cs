using projetAPI2.DTO;
using System.Net.Mail;

namespace projetAPI2.Methode
{
    public class CheckEmail
    {
        
        public bool checkEmails(string email) {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
