//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace SurfsUpv3.Controllers
//{
//    public class User
//    {
//        public string username { get; set; }
//        public string email { get; set; }
//    }
//    public class LoginController : Controller
//    {
//        private readonly IHttpClientFactory _httpClientFactory;
//        private readonly UserManager<User> _userManager;

//        public LoginController(IHttpClientFactory httpClientFactory)
//        {
//            _httpClientFactory = httpClientFactory;
//        }
//        public async Task<IActionResult> Index()
//        {

//            string UserId = "ef460940-0962-41da-85ab-1816030459fa";
//            string email = "hej@hej.dk";

//            var user = new User { username = UserId, email = email };
//            var result = await _userManager.CreateAsync(user, "Admin123!");
//            if (result.Succeeded)
//            {

//                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                var confirmationlink = Url.Action("ConfirmEmail", "Account", new
//                {
//                    UserId = UserId,
//                    token = token
//                }, protocol: HttpContext.Request.Scheme);
//                return View("views/Udlejning/Index");


//                //var response = await client.GetAsync("https://localhost:7137/confirmEmail" "Admin123!");
//            }
//            return View();
//        }
//    }
//}
