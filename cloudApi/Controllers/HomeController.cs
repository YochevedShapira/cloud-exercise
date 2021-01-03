using cloudApi.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace cloudApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly cloudDBContext cloudDBContext;

        public HomeController(cloudDBContext cloudDBContext)
        {
            this.cloudDBContext = cloudDBContext;
        }
        [HttpGet("Items")]
        public ActionResult< IEnumerable<Item>> Get()
        {
            
            try
            {
  
                    List<Item> lst = cloudDBContext.Items.ToList();
                    return Ok(lst );
                
            }
            catch(Exception ex)
            {
                
                ///writing to log....
               

                return Problem("problems in our side!! " , ex.Message);
            }
        }
        [HttpGet("Items/count")]
        public ActionResult<int> NumOfItems()
        {
            try
            {
               
                    return Ok( cloudDBContext.Items.Count());
                
            }
            catch (Exception ex)
            {
                ///writing to log....
                return Problem("problems in our side!! ", ex.Message);
            }
        }
        [HttpPost("Items")]
        public ActionResult<IEnumerable<Item>> AddItem([FromBody] Item item)
        {
            try
            {
               
               
                cloudDBContext.Items.Add(item);
                cloudDBContext.SaveChanges();
                    return Ok(cloudDBContext.Items.ToList());
                
            }
            catch (Exception ex)
            {
                ///writing to log....
                return Problem("problems in our side!! ", ex.Message);
            }
        }
    }
}
