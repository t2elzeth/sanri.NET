namespace Sanri.Tests.AppFaker
{
    public class User
    {
        public static string Password()
        {
            return $"{Faker.Internet.UserName()}{Faker.RandomNumber.Next(0, 2500)}";
        }
        
        public static string FullName() => Faker.Name.FullName();
    }
}