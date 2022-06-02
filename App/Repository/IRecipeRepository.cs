using DatabaseModel;
using Entprog.DataModel;

namespace App.Repository
{
    public interface IRecipeRepository : IGenRepository<Recipe>
    {
        //Implement specialized method contracts here!
        //Task PrepareIngredients();
        List<Recipe> FindAllSpecial();
    }
}
