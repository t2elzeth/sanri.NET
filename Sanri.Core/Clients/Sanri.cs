namespace Sanri.Core.Clients;

public class Sanri
{
    public static Client Instance { get; set; } = new Client(country: "Japan",
                                                             email: "sanri@email.com",
                                                             phoneNumber: "",
                                                             balance: 0,
                                                             fullName: "Sanrijapan",
                                                             password: "admin12345",
                                                             username: "sanrijapan");
}