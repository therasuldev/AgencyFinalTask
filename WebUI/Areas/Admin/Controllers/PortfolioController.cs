using Core.Entities;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels.PortfolioItem;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioRepository _repository;

        public PortfolioController(IPortfolioRepository repository)
        {
            _repository = repository;
        }

		public async Task<IActionResult> Index()
		{
			return View(await _repository.GetAllAsync());
		}

		public async Task<IActionResult> Detail(int id)
		{
			var model = await _repository.FindAsync(id);
			if (model == null) { return NotFound(); }
			return View(model);
		}

		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(PortfolioVM model)
		{
			if (!ModelState.IsValid) return View(model);

			PortfolioModel teamModel = new()
			{
				Image = model.Image,
				Title = model.Title,
				Subtitle = model.Subtitle,
			};
			await _repository.CreateAsync(teamModel);
			await _repository.SaveAsync();
			return RedirectToAction(nameof(Index));
		}



		public async Task<IActionResult> Update(int id)
		{
			var model = await _repository.FindAsync(id);
			if (model == null) return NotFound();
			PortfolioModel updateModel = new()
			{
				Image = model.Image,
				Title = model.Title,
				Subtitle = model.Subtitle,
			};

			return View(updateModel);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id, PortfolioVM teamModel)
		{
			if (id != teamModel.Id) return BadRequest();
			if (!ModelState.IsValid) return View(teamModel);
			var model = await _repository.FindAsync(id);
			if (model == null) return NotFound();
			model.Image = teamModel.Image;
			model.Title = teamModel.Title;
			model.Subtitle = teamModel.Subtitle;
			_repository.UpdateAsync(model);
			await _repository.SaveAsync();
			return RedirectToAction(nameof(Index));

		}

		public async Task<IActionResult> Delete(int id)
		{
			var model = await _repository.FindAsync(id);
			if (model == null) return NotFound();
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public async Task<IActionResult> DeletePost(int id, PortfolioVM teamModel)
		{
			var model = await _repository.FindAsync(id);
			if (model == null) return NotFound();
			_repository.DeleteAsync(model);
			await _repository.SaveAsync();
			return RedirectToAction(nameof(Index));
		}

	}
}
