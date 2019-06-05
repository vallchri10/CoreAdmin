namespace CoreAdmin.Data.Entities
{
    public class UserEntity
    {
        public string UserID { get; set; }
        public string UserRole{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}