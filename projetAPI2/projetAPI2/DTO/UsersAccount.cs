namespace projetAPI2.DTO
{
    public class UsersAccount
    {

        public int IdUser { get; set; }

        public string UseEmail { get; set; } = null!;

        public string UseFirstName { get; set; } = null!;

        public string UseLastName { get; set; } = null!;

        public int IdCountry { get; set; }
    }
}
