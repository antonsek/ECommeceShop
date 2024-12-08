﻿using Shared;

namespace User.Domain.Entities;

public class User : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string MiddleName { get; private set; }
    public string Email { get; private set; }
    public string Login { get; private set; }
}