using System;

namespace FireAuth.Domain.Contracts.Entities;

public class ApplicationUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? LastLogin { get; set; }
    public string FirebaseUid { get; set; }

    // Relationship to rolesß
    public ICollection<UserRole> UserRoles { get; set; }
}
