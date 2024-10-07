using System;

namespace FireAuth.Domain.Contracts.Entities;

public class UserRole
{
public int UserId { get; set; }
public ApplicationUser User { get; set; }
public int RoleId { get; set; }
public Role Role { get; set; }
}
