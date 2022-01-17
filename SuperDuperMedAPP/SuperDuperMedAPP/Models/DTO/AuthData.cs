namespace SuperDuperMedAPP.Models.DTO
{
    public class AuthData
    {
        public string Token { get; set; } = null!;
        public long TokenExpirationTime { get; set; }
        public int Id { get; set; }
        public string UserRole { get; set; } = null!;
    }
}