namespace StudentskaSluzbaAPI.Entities
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public int BrojIndeksa { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public int Godina { get; set; }
        public int StatusStudentaId { get; set; }
        public string? StatusNaziv { get; set; }
    }
}
