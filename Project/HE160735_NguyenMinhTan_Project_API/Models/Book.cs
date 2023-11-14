using System;
using System.Collections.Generic;

namespace HE160735_NguyenMinhTan_Project_API.Models;

public partial class Book
{
    public int BookId { get; set; }

    public int UserId { get; set; }

    public DateTime BookDate { get; set; }

    public string BookTime { get; set; }

    public int NumberOfPeople { get; set; }

    public string Note { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
}
