using Shared;

namespace User.Domain.Entities;

public class User : Entity
{
    private User(string firstName, string lastName, string middleName, string login, string email) : base(Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        Login = login;
    }

    private User()
    {
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string MiddleName { get; private set; }
    public string Email { get; private set; }
    public string Login { get; private set; }

    public static User Create(string firstName, string lastName, string middleName, string login, string email)
    {
        return new User(firstName, lastName, middleName, login, email);
    }

    public void Update(string firstName, string lastName, string middleName, string login, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Login = login;
        Email = email;
    }
}