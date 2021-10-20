namespace SuperDuperMedAPP.Models
{
    public struct SessionData
    {
        public string Username { get; private set; }
        public int ID { get; private set; }
        public string HashPassword { get; private set; }
    }
}