using System;
using System.Collections.Generic;

namespace HE160735_NguyenMinhTan_Project_API.Models;

public partial class Food
{
    public int FoodId { get; set; }

    public string FoodName { get; set; }

    public string FoodDescription { get; set; }

    public double FoodPrice { get; set; }

    public int FoodCategory { get; set; }

    public string FoodImage { get; set; }

    public virtual Category FoodCategoryNavigation { get; set; }
}
