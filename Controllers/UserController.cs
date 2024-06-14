using CRUD_application_2.Models;
using System;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            return View(userlist); // Returns the userlist to the Index view
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        // GET: User/Create
        public ActionResult Create()
        {
            return View(); // Returns the Create view to display the form for creating a new user
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userlist.Add(user); // Add the new user to the userlist
                    return RedirectToAction("Index"); // Redirect to the Index action to display the updated list of users
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(user); // Return the view with the user model to display any validation errors
        }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound(); // If no user is found with the specified ID, return a HttpNotFound result.
            }
            return View(user); // Return the Edit view, passing in the user to be edited.
        }


        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                var userToUpdate = userlist.FirstOrDefault(u => u.Id == id);
                if (userToUpdate == null)
                {
                    return HttpNotFound(); // If no user is found with the specified ID, return a HttpNotFound result.
                }

                if (ModelState.IsValid)
                {
                    // Update the user's information here
                    // This is a simplified example. In a real application, you might need to map properties manually or use a library like AutoMapper.
                    userToUpdate.Name = user.Name;
                    userToUpdate.Email = user.Email;
                    // Add any other fields that need to be updated

                    return RedirectToAction("Index"); // Redirect to the Index action to display the updated list of users
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(user); // Return the view with the user model to display any validation errors
        }


        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound(); // If no user is found with the specified ID, return a HttpNotFound result.
            }
            userlist.Remove(user); // Remove the user from the userlist
            return RedirectToAction("Index"); // Redirect to the Index action to display the updated list of users
        }


        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var user = userlist.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return HttpNotFound(); // If no user is found with the specified ID, return a HttpNotFound result.
                }
                userlist.Remove(user); // Remove the user from the userlist
                return RedirectToAction("Index"); // Redirect to the Index action to display the updated list of users
            }
            catch
            {
                return View(); // In case of an error, return to the same view to display any possible error messages.
            }
        }

    }
}
