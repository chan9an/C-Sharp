using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace First_WebAPI_Demo.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        public static List<string> cityList = null;
        public CitiesController()
        {
            if (cityList == null)
            {
                cityList = new List<string>() { "Shimla", "Delhi", "Pune", "Mumbai", "Hamirpur" };
            }
            
        }
        [Route("/JoiningCities")]
        //[Route("/Cg")] can have as many as Routes for one 
        //if we remove '/'[Route("/JoiningCities")]  in the route it creates a new route , if we dont and do as this [Route("JoiningCities")] then we 
        // then we have to work undermain controller so like here is lc/Cities/JoiningCities otherwise lc/JoiningCities
        public List<string> ShowAllCities(){
            return cityList;

        }

    }
}
