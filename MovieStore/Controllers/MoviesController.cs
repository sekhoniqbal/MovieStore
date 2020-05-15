using MovieStore.Models;
using MovieStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStore.Controllers
{
    public class MoviesController : Controller
    {
        //GET: Movies/Random
       public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Shrek" };
            //ViewData["Movie"] = movie;
            //ViewData.Model = movie;
            var customers = new List<Customer>() {
                new Customer(){ Id=1, Name="Iqbal" },
                new Customer(){ Id=2, Name="Singh"}
             };

            var viewModel = new RandomMovieViewModel() { Movie = movie, Customers=customers };
           
            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) pageIndex = 1;
            return Content("pageIndex=" + pageIndex + "sortby" + sortBy);
        }
        public ActionResult ByReleaseDate(int year, int month) {
            return Content(year + "/" + month);
        }

        /*learning- we can define one or more conditions for route parameters 
         here, we have two conditions, month must be 2 characers and must be in range 1-12*/
        [Route(@"movies/actor/{name}/{month:regex(\d{2}):range(1,12)}")]
        public ActionResult ByActorName(string name)
        {
            return Content("tesst");
        
        }
    }
}