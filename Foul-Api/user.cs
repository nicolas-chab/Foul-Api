namespace Foul_Api
{
    public class user
    {
        public int id {  get; set; } 
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public byte[] passwordhash { get; set; } = new byte[32];
        public byte[] passwordsalt { get; set; } = new byte[32];
        public string? verificationtoken { get; set; }
        public DateTime? verifiedat { get; set; }
        public string? passwordresettoken { get; set; }
        public DateTime? resettokenexpires { get; set; }
        public string? subscribedteams { get; set; }
    }
    
}
