namespace Sanri.Core.Clients;

public class Sanri
{
    public static Client Instance { get; set; } = new Client(fullName: "Sanrijapan",
                                                             password: "admin12345",
                                                             username: "sanrijapan",
                                                             country: "Japan",
                                                             email: "sanri@email.com",
                                                             phoneNumber: "",
                                                             fobSize: 0);
}