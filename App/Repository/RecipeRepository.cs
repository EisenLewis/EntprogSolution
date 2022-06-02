using DatabaseModel;
using Entprog.DataModel;

namespace App.Repository
{
    public class RecipeRepository :
        GenRepository<Recipe>, IRecipeRepository
    {
        private readonly AppDbContext Context;
        public RecipeRepository(AppDbContext context) : base(context)
        {
            Context = context;
        }

        public List<Recipe> FindAllSpecial()
        {
            return Context.Set<Recipe>()
                .Where(r => r.Id > 3).ToList();
        }

    }
}
