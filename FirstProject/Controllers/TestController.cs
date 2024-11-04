// namespace FirstProject.Controllers;
// [Route("api/[controller]")]
// [ApiController]
// public class TestController : Controller
// {
//     private readonly IMessageService _messageService;
//     
//     public TestController(IMessageService messageService)
//     {
//        _messageService = messageService; 
//     }
//     [HttpGet("1")]1
//     public IActionResult Get1()
//     {
//         var message = _messageService.Send("message has been sent");
//         return Ok(message);
//     }
//     [HttpGet("2")]
//     public IActionResult Get2()
//     {
//         var message = _messageService.Send("message has been sent");
//         return Ok(message);
//     }
// }
//
// public interface IMessageService
// {
//     public int Send(string message);
// }
//
// public class EmailService : IMessageService
// {
//     private int count = 0; 
//     public int Send(string message)
//     {
//         count++;
//         return count;
//     }
// }