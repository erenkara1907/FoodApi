using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : Controller
    {
        private IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("getall")]
        [Authorize]
        public IActionResult GetAll()
        {
            var result = _foodService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getfood")]
        [Authorize]
        public IActionResult GetById(int foodId)
        {
            var result = _foodService.GetById(foodId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getfoodbyuser")]
        [Authorize]
        public IActionResult GetFoodByUser(int userId)
        {
            var result = _foodService.GetFoodByUser(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getlistbyuser")]
        [Authorize]
        public IActionResult GetListByUser(int userId)
        {
            var result = _foodService.GetListByUser(userId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult Add(Food food)
        {
            var result = _foodService.Add(food);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize]
        public IActionResult Delete(Food food)
        {
            var result = _foodService.Delete(food);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize]
        public IActionResult Update(Food food)
        {
            var result = _foodService.Update(food);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
