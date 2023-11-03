namespace ECA.Application.Futures.Users.Models;

public record UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int StatusId { get; set; }
    public string Status { get; set; }
    public UserAddressDto Address { get; set; }
}