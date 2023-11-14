using HE160735_NguyenMinhTan_Project_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HE160735_NguyenMinhTan_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        He160735NguyenMinhTanProjectContext _context;

        public CategoryController(He160735NguyenMinhTanProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetCategories() 
        {
            try
            {
                List<Category> categories = _context.Categories.ToList();
                if(categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-category-by-id")]
        public ActionResult GetCategoryById(int id)
        {
            try
            {
                Category category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-category-by-category-name")]
        public ActionResult GetCategoryByCategoryName(string categoryName)
        {
            try
            {
                Category category = _context.Categories.FirstOrDefault(c => c.CategoryName == categoryName);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create-category")]
        public ActionResult CreateCategory(string categoryName)
        {
            try
            {
                Category category = new Category();
                category.CategoryName = categoryName.Trim();
                _context.Categories.Add(category);
                _context.SaveChanges();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update-category")]
        public ActionResult UpdateCategory(int id, string categoryName)
        {
            try
            {
                Category category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (category == null)
                {
                    return NotFound();
                }
                category.CategoryName = categoryName;
                _context.Categories.Update(category);
                _context.SaveChanges();
                return Ok("Update Sucessful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete-category")]
        public ActionResult DeleteCategory(int id) 
        {
            try
            {
                Category category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (category == null)
                {
                    return NotFound();
                }
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return Ok("Delete Sucessful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
