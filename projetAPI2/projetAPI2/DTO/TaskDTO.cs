namespace projetAPI2.DTO
{
    public class TaskDTO
    {

        public string TasTitle { get; set; } = null!;

        public string TasDescription { get; set; } = null!;

        public DateTime TasStartDate { get; set; }

        public DateTime TasEndDate { get; set; }

        public int IdStatesTask { get; set; }

        public int IdEvent { get; set; }
    }
}
