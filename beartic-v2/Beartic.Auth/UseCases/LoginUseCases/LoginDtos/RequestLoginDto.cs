namespace Beartic.Auth.UseCases.LoginUseCases.LoginDtos
{
    public class RequestLoginDto
    {
        public RequestLoginDto(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
