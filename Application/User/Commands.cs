namespace Application.User;

public class Commands
{

    public class CreateUserCommand
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}
