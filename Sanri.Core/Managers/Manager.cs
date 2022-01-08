namespace Sanri.Core.Managers;

public abstract class Manager
{
    public string FullName { get; protected set; }

    public string Username { get; protected set; }

    public string Password { get; protected set; }

    protected Manager(string fullName, string username, string password)
    {
        FullName = fullName;
        Username = username;
        Password = password;
    }
}