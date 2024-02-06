﻿using System;
using System.Collections.Generic;

namespace PhoneBook.Models;

public partial class PhoneBook
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
