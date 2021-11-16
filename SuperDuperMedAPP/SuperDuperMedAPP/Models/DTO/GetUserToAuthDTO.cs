namespace SuperDuperMedAPP.Models.DTO
{
    public class GetUserToAuthDTO
    {
        public int Id { get; set; }
        public string HashPassword { get; set; }
        public string Role { get; set; }
    }
}