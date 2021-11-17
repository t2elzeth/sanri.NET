namespace Sanri.Application.Models
{
    public class User
    {
        public virtual long Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}