using HE160735_NguyenMinhTan_Project_API.ModelDTO;
using HE160735_NguyenMinhTan_Project_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HE160735_NguyenMinhTan_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        He160735NguyenMinhTanProjectContext _context;

        public FoodController(He160735NguyenMinhTanProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult ListFoods()
        {
            try
            {
                List<Food> foods = _context.Foods.ToList();
                if (foods == null)
                {
                    return NotFound();
                }
                return Ok(foods);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Get-food-by-id")]
        public IActionResult GetFoodById(int id)
        {
            try
            {
                Food food = _context.Foods.FirstOrDefault(u => u.FoodId == id);
                if (food == null)
                {
                    return NotFound();
                }
                return Ok(food);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("List-food-by-cateid")]
        public ActionResult ListFoodByCateId(int id)
        {
            try
            {
                List<Food> foods = _context.Foods.Where(f => f.FoodCategory == id).ToList();
                if (foods == null)
                {
                    return NotFound();
                }
                return Ok(foods);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Filter-Food")]
        public ActionResult ListFilterFoods(string? foodname, string? foodprice, string? category, string? fooddescription, string? foodpricefrom, string? foodpriceto)
        {
            try
            {
                List<Food> foods = _context.Foods.ToList();
                if (!string.IsNullOrEmpty(foodname))
                {
                    foods = foods.Where(f => f.FoodName.Contains(foodname)).ToList();
                }
                if (!string.IsNullOrEmpty(foodprice))
                {
                    foods = foods.Where(f => f.FoodPrice == int.Parse(foodprice)).ToList();
                }
                if (!category.Equals("All"))
                {
                    foods = foods.Where(f => f.FoodCategory == int.Parse(category)).ToList();
                }
                if (!string.IsNullOrEmpty(fooddescription))
                {
                    foods = foods.Where(f => f.FoodDescription.Contains(fooddescription)).ToList();
                }
                if (!string.IsNullOrEmpty(foodpricefrom))
                {
                    foods = foods.Where(f => f.FoodPrice >= int.Parse(foodpricefrom)).ToList();
                }
                if (!string.IsNullOrEmpty(foodpriceto))
                {
                    foods = foods.Where(f => f.FoodPrice <= int.Parse(foodpriceto)).ToList();
                }
                if (foods == null)
                {
                    return NotFound();
                }
                return Ok(foods);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update-food")]
        public IActionResult UpdateFood(FoodDTO food)
        {
            try
            {
                Food f = _context.Foods.FirstOrDefault(f => f.FoodId == food.FoodId);
                f.FoodName = food.FoodName;
                f.FoodDescription = food.FoodDescription;
                f.FoodPrice = food.FoodPrice;
                f.FoodCategory = food.FoodCategory;
                f.FoodImage = food.FoodImage;
                _context.Foods.Update(f);
                _context.SaveChanges();
                return Ok("Update Food Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete-Food")]
        public IActionResult DeleteFood(int id)
        {
            try
            {
                Food food = _context.Foods.FirstOrDefault(b => b.FoodId == id);
                _context.Foods.Remove(food);
                _context.SaveChanges();
                return Ok("Delete Food Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
