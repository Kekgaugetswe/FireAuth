using System;

namespace FireAuth.Domain.Contracts.Entities;

public class Role
{
    public int Id { get; set; } // Primary Key
    public string Name { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}
