namespace Assessment.Application.Dtos
{
    public class AppSettings
    {
        public bool IsTestEnvironment { get; set; }
        public int ReservationTimeLimit { get; set; }
        public int PasswordHashIteration { get; set; }
        public int LoginFailedAttempt { get; set; }
        public int LockOutTime { get; set; }
        public short UserRoleId { get; set; }
        public string? PepperKey { get; set; }
        public string? JwtAudience { get; set; }
        public string? JwtIssuer { get; set; }
        public string? JwtSecret { get; set; }
        public int JwtTokenTimeout { get; set; }
    }

}
