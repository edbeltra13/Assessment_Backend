using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts;
using WebApi.Model;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {

        private readonly IUsers _users;
        public UserController(IUsers users)
        {
            _users = users;
        }

        [HttpGet]
        public IActionResult Index()       
        {
            
            return View();
        }


        ////Fetch Data From Database to show in Datatable
        public IActionResult GetData()
        {
            var Users = new List<User>();
            Users = _users.GetAllUsers();
            return new JsonResult(new { data = Users });
        }

        ////Create Method for Insert and Update
        [HttpGet]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new User());
            else
            {
                var user = _users.GetUserById(id);
                return View(user);
                
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(User User)
        {
            if (User.Id == 0)
            {
                _users.AddUser(User);
                return new JsonResult(new { success = true, message = "Saved Successfully" });
            }
            else
            {
                _users.UpdateUser(User.Id, User);
                return new JsonResult(new { success = true, message = "Updated Successfully" });

            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _users.DeleteUser(id);
            return new JsonResult(new { success = true, message = "Deleted Successfully"});
        }


    }
}
