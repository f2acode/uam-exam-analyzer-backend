using ImagesExamProcess.Models;
using System.Web.Http;

namespace ImagesExamProcess.Controllers
{
    public class ExamsController : ApiController
    {
        [HttpPost]
        public Exam Post([FromBody] Exam exam)
        {
            return exam;
        }
    }
}
