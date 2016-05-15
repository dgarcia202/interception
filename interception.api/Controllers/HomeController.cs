namespace interception.api.Controllers
{
    using System.Web.Http;

    using interception.application;

    public class HomeController : ApiController
    {
        private readonly IMessageService messageService;

        public HomeController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [Route("hello")]
        public IHttpActionResult GetHello()
        {
            return this.Ok(this.messageService.GetHelloMessage());
        }
    }
}