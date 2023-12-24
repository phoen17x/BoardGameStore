﻿namespace BoardGameStore.BL.Users.Entities;

public class CreateUserModel
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}