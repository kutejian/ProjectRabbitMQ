using Microsoft.AspNetCore.Mvc;
using WebApplication1.Api;

namespace WebApplication1
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public ProducerSI _producerSI { get; set; }
        public ConsumerSI _consumerSI { get; set; }
        public HomeController(ProducerSI producerSI, ConsumerSI consumerSI)
        { 
            _producerSI = producerSI;
            _consumerSI = consumerSI;

        }
        [HttpGet]
        public IActionResult Index()
        {
            //_producerSI.ProducerExchangeFanout();
            //_consumerSI.ConsumerExchangeFanout();
            /*_producerSI.ProducerExchangeDirect();
            _consumerSI.ConsumerExchangeDirect();*/

            _producerSI.ProducerExchangeTopic();
            var message = _consumerSI.ConsumerExchangeTopic();
            return Ok(message);
        }
    }
}
