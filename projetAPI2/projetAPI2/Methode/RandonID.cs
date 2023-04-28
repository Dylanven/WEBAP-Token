namespace projetAPI2.Methode
{
    public class RandonID
    {
        public static int randonId()
        {
            Random rand = new Random();
            return rand.Next();
        }
    }
}
