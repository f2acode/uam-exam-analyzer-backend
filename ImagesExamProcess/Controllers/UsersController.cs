using ImagesExamProcess.Models;
using System.Web.Http;

namespace ImagesExamProcess.Controllers
{
    public class UsersController : ApiController
    {

        [HttpPost]
        public User Post([FromBody]User user)
        {
            // register user
            return user;
        }

        public bool Get([FromBody]User user)
        {
            return false;
        }
    }
}
