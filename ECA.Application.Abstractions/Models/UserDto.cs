namespace ECA.Application.Futures.Users.Models;

public class UserDto
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StatusId { get; set; }
    public string Status { get; set; }
    public UserAddressDto Address { get; set; }
}