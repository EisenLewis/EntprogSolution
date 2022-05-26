using App.ViewModels;
using AutoMapper;
using DatabaseModel;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext con;
        private readonly IMapper mapper;

        public RecipeController(AppDbContext context, IMapper mapper)
        {
            con = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            //Get all recipe records
            return View(mapper.Map<List<RecipeVM>>(con.Set<Recipe>().ToList()));
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
                //Make sure AddAsync completes before executing SaveChangesAsync
                await con.Set<Recipe>().AddAsync(mapper.Map<Recipe>(model));
                await con.SaveChangesAsync();

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
            return RedirectToAction("Index");
        }
    }
}
