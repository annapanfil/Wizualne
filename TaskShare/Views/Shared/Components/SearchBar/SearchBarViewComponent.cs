using Microsoft.AspNetCore.Mvc;

namespace TaskShare.Views.Shared.Components.SearchBar
{
    public class SearchBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke (SPager SearchPager)
        {
            return View("Default", SearchPager);
        }
    }
}
