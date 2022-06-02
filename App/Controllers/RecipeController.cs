using App.Repository;
using App.ViewModels;
using AutoMapper;
using DatabaseModel;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository repo;
        private readonly IMapper mapper;

        public RecipeController(IRecipeRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            //Get all recipe records
            List<RecipeVM> vmList = mapper.Map<List<RecipeVM>>(
                await repo.GetAllAsync());

            return View(vmList);
        }

        public IActionResult Add()
        {
            return View(new RecipeVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RecipeVM model)
        {
            if (ModelState.IsValid == true)
            {
                await repo.AddAsync(mapper.Map<Recipe>(model));

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await repo.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
