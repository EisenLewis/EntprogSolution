using DatabaseModel;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext con;
        public RecipeController(AppDbContext context)
        {
            con = context;
        }

        public IActionResult Index()
        {
            //Get all recipe records
            List<Recipe> rlist = con.Set<Recipe>().ToList();
            return View(rlist);
        }

        public IActionResult Add()
        {
            return View(new Recipe());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Recipe model)
        {
            //Make sure AddAsync completes before executing SaveChangesAsync
            await con.Set<Recipe>().AddAsync(model);
            await con.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
