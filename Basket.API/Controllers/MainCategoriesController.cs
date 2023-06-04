using Basket.Core;
using Basket.Core.DTOs.Store;
using Basket.Core.Entity;
using Basket.Core.Entity.Catogry;
using Basket.Core.Interfaces;
using Basket.EntityFramework.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Basket.API.Controllers
{
	[Route("api/mainCategory/")]
	[ApiController]
	public class MainCategoriesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public MainCategoriesController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet("getOne")]
		public async Task<IActionResult> GetById(int id)
		{
			var category = await _unitOfWork.mainCatogry.GetById(id);

			if (category == null)
				return NotFound(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Category not found." });


			var response = new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = category };

			return Ok(response);
		}

		[HttpGet("getAll")]
		public async Task<IActionResult> getMainCategory()
		{
			var category = await _unitOfWork.mainCatogry.GetAll();

			if (category == null)
				return NotFound(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "No Categoies found." });


			var response = new Generic<IEnumerable<MainCatogry>, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = category };

			return Ok(response);
		}

		[HttpPost("add")]
		public async Task<IActionResult> AddOne([FromBody] MainCategoryDTO mainCategoryDTO)
		{
			
			if (mainCategoryDTO.NameAr.IsNullOrEmpty())
				return NotFound(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Arabic name." });
			else if(mainCategoryDTO.NameEn.IsNullOrEmpty())
				return NotFound(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the English name." });
			else if (mainCategoryDTO.Image.IsNullOrEmpty())
				return NotFound(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Image URL." });
			else if (mainCategoryDTO.ColorHEX.IsNullOrEmpty())
				return NotFound(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Back color HEX." });

			var mainCategory = new MainCatogry
			{
				NameAr = mainCategoryDTO.NameAr,
				NameEn = mainCategoryDTO.NameEn,
				ColorHEX = mainCategoryDTO.ColorHEX,
				Image = mainCategoryDTO.Image
			};

			var result = await _unitOfWork.mainCatogry.AddOne(mainCategory);
			_unitOfWork.Complete();

			if (result == null)
				return BadRequest(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status400BadRequest, FailureMessage = "There is an issue. try again!" });


			return Ok(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = mainCategory });
		}

		[HttpPut("update")]
		public async Task<IActionResult> updateMainCategory([FromBody] MainCategoryDTO mainCategoryDTO, int Id)
		{

			var category = await _unitOfWork.mainCatogry.GetById(Id);

			if (category == null)
				return NotFound(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "No Categoies found." });

			if (!mainCategoryDTO.NameAr.IsNullOrEmpty())
				category.NameAr = mainCategoryDTO.NameAr;

			if (!mainCategoryDTO.NameEn.IsNullOrEmpty())
				category.NameEn = mainCategoryDTO.NameEn;

			if (!mainCategoryDTO.Image.IsNullOrEmpty())
				category.Image = mainCategoryDTO.Image;

			if (!mainCategoryDTO.ColorHEX.IsNullOrEmpty())
				category.ColorHEX = mainCategoryDTO.ColorHEX;

			var result = await _unitOfWork.mainCatogry.Update(category);
			_unitOfWork.Complete();

			return Ok(new Generic<string, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = "Main Category is updated." });
		}

		[HttpDelete("delete")]
		public async Task<IActionResult> deleteMainCategory(int Id)
		{

			var category = await _unitOfWork.mainCatogry.GetById(Id);

			if (category == null)
				return NotFound(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "No Categoies found." });

			_unitOfWork.mainCatogry.Delete(category);
			_unitOfWork.Complete();

			return Ok(new Generic<string, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = "Main Category is deleted." });
		}
	}
}
