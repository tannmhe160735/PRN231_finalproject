using System;
using System.Collections.Generic;

namespace HE160735_NguyenMinhTan_Project.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
}
