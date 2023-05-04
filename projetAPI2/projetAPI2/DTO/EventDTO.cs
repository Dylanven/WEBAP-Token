using projetAPI2.Models;

namespace projetAPI2.DTO
{
    public class EventDTO
    {

        public string EveTitle { get; set; } = null!;

        public string EvePublic { get; set; } = null!;

        public string EveDescription { get; set; } = null!;

        public DateTime EveStartDate { get; set; }

        public DateTime EveEndDate { get; set; }

        public short? EveMaxParticipant { get; set; }

        public int IdStatesEvent { get; set; }

        public int IdCountry { get; set; }

    }
}
