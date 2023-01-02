using Microsoft.AspNetCore.Mvc;

namespace _145233.SweetBase.Views.Shared.Components.SearchBar
{
    public class SearchBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke (SPager SearchPager)
        {
            return View("Default", SearchPager);
        }
    }
}
