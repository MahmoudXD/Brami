using Basket.Core;
using Basket.Core.Entity.Catogry;
using Basket.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Basket.Core.DTOs.Store;

namespace Basket.API.Controllers
{
    [Route("api/stores/")]
	[ApiController]
	public class StoresController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public StoresController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet("getOne")]
		public async Task<IActionResult> GetById(int id)
		{
			var store = await _unitOfWork.store.GetById(id);

			if (store == null)
				return NotFound(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Store not found." });


			var response = new Generic<Store, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = store };

			return Ok(response);
		}

		[HttpGet("getAll")]
		public async Task<IActionResult> getMainCategory()
		{
			var stores = await _unitOfWork.store.GetAll();

			if (stores == null)
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "No Stores found." });


			var response = new Generic<IEnumerable<Store>, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = stores };

			return Ok(response);
		}

		[HttpPost("add")]
		public async Task<IActionResult> AddOne([FromBody] StoreDTO store)
		{

			if (store.NameAr.IsNullOrEmpty())
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Arabic name." });
			else if (store.NameEn.IsNullOrEmpty())
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the English name." });
			if (store.DescriptionAr.IsNullOrEmpty())
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Description name." });
			else if (store.DescriptionEn.IsNullOrEmpty())
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Description name." });
			else if (store.Image.IsNullOrEmpty())
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Image URL." });
			else if (store.Cover.IsNullOrEmpty())
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "Please fill the Cover URL." });

			var _store = new Store
			{
				NameAr = store.NameAr,
				DescriptionAr = store.DescriptionAr,
				NameEn = store.NameEn,
				DescriptionEn = store.DescriptionEn,
				Image = store.Image,
				Cover = store.Cover,
				MainCatogryId = store.MainCatogryId ?? -1
			};

			var result = await _unitOfWork.store.AddOne(_store);
			_unitOfWork.Complete();

			if (result == null)
				return BadRequest(new Generic<Store, string> { StatusCode = StatusCodes.Status400BadRequest, FailureMessage = "There is an issue. try again!" });


			return Ok(new Generic<Store, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = _store });
		}

		[HttpPut("update")]
		public async Task<IActionResult> updateMainCategory([FromBody] StoreDTO store, int Id)
		{

			var _store = await _unitOfWork.store.GetById(Id);

			if (_store == null)
				return NotFound(new Generic<Store, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "No Stores found." });

			if (!store.NameAr.IsNullOrEmpty())
				_store.NameAr = store.NameAr;

			if (!store.NameEn.IsNullOrEmpty())
				_store.NameEn = store.NameEn;

			if (!store.DescriptionAr.IsNullOrEmpty())
				_store.DescriptionAr = store.DescriptionAr;

			if (!store.DescriptionEn.IsNullOrEmpty())
				_store.DescriptionEn = store.DescriptionEn;

			if (!store.Image.IsNullOrEmpty())
				_store.Image = store.Image;

			if (!store.Cover.IsNullOrEmpty())
				_store.Cover = store.Cover;

			if (store.MainCatogryId.HasValue)
				_store.MainCatogryId = store.MainCatogryId ?? -1;

			var result = await _unitOfWork.store.Update(_store);
			_unitOfWork.Complete();

			return Ok(new Generic<string, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = "Store is updated." });
		}

		[HttpDelete("delete")]
		public async Task<IActionResult> deleteMainCategory(int Id)
		{

			var store = await _unitOfWork.store.GetById(Id);

			if (store == null)
				return NotFound(new Generic<MainCatogry, string> { StatusCode = StatusCodes.Status404NotFound, FailureMessage = "No store found." });

			_unitOfWork.store.Delete(store);
			_unitOfWork.Complete();

			return Ok(new Generic<string, string> { StatusCode = StatusCodes.Status200OK, SuccessResult = "Store is deleted." });
		}
	}
}
