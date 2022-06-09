using StudentskaSluzbaAPI.Models;

namespace StudentskaSluzbaAPI.Service
{
    public class KorisnikService
    {
        public Korisnik GetKorisnik(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            var korisnik = new Korisnik() { Id=1, Email="admin@test.com", Name="Test", Password = "password" };

            if(korisnik != null)
            {
                korisnik.Password = string.Empty;
            }
            return korisnik;
        }
    }
}
