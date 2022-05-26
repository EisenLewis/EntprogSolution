using App.ViewModels;
using AutoMapper;
using DatabaseModel;

namespace App.Configuration
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<Recipe, RecipeVM>().ReverseMap();
        }
    }
}
