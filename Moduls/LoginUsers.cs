namespace One_City_One_Pay.Moduls
{
    public class LoginUsers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public required string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }

    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
