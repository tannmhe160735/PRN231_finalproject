using System;
using System.Collections.Generic;

namespace HE160735_NguyenMinhTan_Project_API.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Phone { get; set; }

    public int Role { get; set; }
}
