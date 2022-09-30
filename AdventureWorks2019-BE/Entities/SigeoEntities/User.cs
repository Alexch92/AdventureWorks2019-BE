using AdventureWorks2019BE.Entity;

namespace AdventureWorks2019BE.Entities.SigeoEntities
{
    public class User : BaseEntity<long>
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User()
        {
            this._Tabella = "pwa_user";
            this._ChiavePrimaria = new List<string>() { "_Id" };
        }
    }
}
