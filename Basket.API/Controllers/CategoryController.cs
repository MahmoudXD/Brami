using Basket.Core.DTOs.Store;
using Basket.Core.Entity.Catogry;
using Basket.Core.Entity;
using Basket.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Basket.API.Controllers
{
	[Route("api/category/")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public CategoryController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet("getOne")]
		public async Task<IActionResult> GetById(int id)
		{
			var category = await _unitOfWork.category.GetById(id);

			if (category == null)
				return NotFound(new Generic<Category, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Category not found." });


			var response = new Generic<Category, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = category };

			return Ok(response);
		}

		[HttpGet("getAll")]
		public async Task<IActionResult> getMainCategory()
		{
			var categories = await _unitOfWork.category.GetAll();

			if (categories == null)
				return NotFound(new Generic<Category, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "No Stores found." });


			var response = new Generic<IEnumerable<Category>, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = categories };

			return Ok(response);
		}

		[HttpPost("add")]
		public async Task<IActionResult> AddOne([FromBody] CategoryDTO categoryDTO)
		{

			if (categoryDTO.NameAr.IsNullOrEmpty())
				return NotFound(new Generic<Category, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Arabic name." });
			else if (categoryDTO.NameEn.IsNullOrEmpty())
				return NotFound(new Generic<Category, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the English name." });
			if (categoryDTO.DescriptionAr.IsNullOrEmpty())
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Description name." });
			else if (categoryDTO.DescriptionEn.IsNullOrEmpty())
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Description name." });
			else if (categoryDTO.Image.IsNullOrEmpty())
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Image URL." });
			
			var category = new Category
			{
				NameAr = categoryDTO.NameAr,
				DescriptionAr = categoryDTO.DescriptionAr,
				NameEn = categoryDTO.NameEn,
				DescriptionEn = categoryDTO.DescriptionEn,
				Image = categoryDTO.Image,
				StoreId = categoryDTO.StoreId ?? 0,
				MainCatogryId = categoryDTO.MainCatogryId ?? 0
			};

			var result = await _unitOfWork.category.AddOne(category);
			_unitOfWork.Complete();

			if (result == null)
				return BadRequest(new Generic<Category, string> { StatusCode = StatusCodes.Status400BadRequest, FailureMessage = "There is an issue. try again!" });


			return Ok(new Generic<Category, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = category });
		}

		[HttpPut("update")]
		public async Task<IActionResult> updateMainCategory([FromBody] CategoryDTO categoryDTO, int Id)
		{

			var category = await _unitOfWork.category.GetById(Id);

			if (category == null)
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "No Stores found." });

			if (!categoryDTO.NameAr.IsNullOrEmpty())
				category.NameAr = categoryDTO.NameAr;

			if (!categoryDTO.NameEn.IsNullOrEmpty())
				category.NameEn = categoryDTO.NameEn;

			if (!categoryDTO.DescriptionAr.IsNullOrEmpty())
				category.DescriptionAr = categoryDTO.DescriptionAr;

			if (!categoryDTO.DescriptionEn.IsNullOrEmpty())
				category.DescriptionEn = categoryDTO.DescriptionEn;

			if (!categoryDTO.Image.IsNullOrEmpty())
				category.Image = categoryDTO.Image;

			if (categoryDTO.MainCatogryId.HasValue)
				category.MainCatogryId = categoryDTO.MainCatogryId ?? 0;
			
			if (categoryDTO.StoreId.HasValue)
				category.StoreId = categoryDTO.StoreId ?? 0;

			var result = await _unitOfWork.category.Update(category);
			_unitOfWork.Complete();

			return Ok(new Generic<string, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = "Category is updated." });
		}

		[HttpDelete("delete")]
		public async Task<IActionResult> deleteMainCategory(int Id)
		{

			var category = await _unitOfWork.category.GetById(Id);

			if (category == null)
				return NotFound(new Generic<Category, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "No store found." });

			_unitOfWork.category.Delete(category);
			_unitOfWork.Complete();

			return Ok(new Generic<string, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = "Store is deleted." });
		}
	}
}
