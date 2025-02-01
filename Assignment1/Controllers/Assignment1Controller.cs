using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;



namespace Assignment1.Controllers
{
    [Route("api/Assignment1")]
    [ApiController]
    public class Assignment1Controller : ControllerBase
    {

        ///TASK 1
        /// <summary>
        /// Returns a welcome message
        /// </summary>
        /// <returns>Welcome to 5125!</returns>
        /// GET: https://localhost:7206/api/Assignment1/Welcome
        [HttpGet("Welcome")]
        public string Welcome()
        {
            return "Welcome to 5125!";
        }

       ///TASK 2
        /// <summary>
        /// Returns a greeting with a name.
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>A greeting message containing the users name</returns>
        /// GET: https://localhost:7206/api/Assignment1/{name}
        /// Example cURL command : 
        /// curl https://localhost:7206/api/Assignment1/Ren%C3%A9e
        [HttpGet("{name}")]
        public string Get(string name)
        {
            return $"Hi {name}!";
        }

        ///TASK 3
        /// <summary>
        /// Returns the cube of a number.
        /// </summary>
        /// <param name="number">The base number.</param>
        /// <returns>The cube of the number.</returns>
        /// GET: https://localhost:7206/api/Assignment1/cube/{number}
        /// Example cURL command:
        /// curl "https://localhost:7206/api/Assignment1/cube/-4"

        [HttpGet("cube/{number}")]
        public int Cube(int number)
        {
            return number * number * number;
        }

        ///TASK 4
        /// <summary>
        /// Returns the start of a knock-knock joke.
        /// </summary>
        /// <returns>"Who's There?"</returns>
        /// POST: https://localhost:7206/api/Assignment1/knockknock
        [HttpPost("knockknock")]
        public string KnockKnock()
        {
            return "Who’s there?";
        }


        ///TASK 5
        /// <summary>
        /// Returns an acknowledgment of the secret number.
        /// </summary>
        /// <param name="secret">Secret number.</param>
        /// <returns>A secret message.</returns>
        /// POST: https://localhost:7206/api/Assignment1/secret
        /// Example cURL command:
        /// curl -H "Content-Type: application/json" -d "5" https://localhost:7206/api/Assignment1/secret
        [HttpPost("secret")]
        public string Secret([FromBody] int secret)
        {
            return $"Shh.. the secret is {secret}";
        }

        ///TASK 6
        /// <summary>
        /// Returns the area of a hexagon with side length {S}
        /// </summary>
        /// <param name="S">The length of a side </param>
        /// <returns>The area of the hexagon</returns>
        /// GET: https://localhost:7206/api/Assignment1/hexagon?side={S}
        /// Example cURL command:
        /// curl "https://localhost:7206/api/Assignment1/hexagon?side=1.5"

        [HttpPost("hexagon")]
        public double Hexagon([FromBody] double side)
        {
            return (3 * Math.Sqrt(3) / 2) * Math.Pow(side, 2);
        }

        ///TASK 7
        /// <summary>
        /// Returns a date.
        /// </summary>
        /// <param name="days">Number of days to add </param>
        /// <returns>Formatted date (yyyy-MM-dd)</returns>
        /// GET: https://localhost:7206/api/Assignment1/timemachine?days={days}
        /// 
        /// Example cURL command:
        /// curl "https://localhost:7206/api/Assignment1/timemachine?days=5"
        [HttpGet("timemachine")]
        public string TimeMachine([FromQuery] int days)
        {
            return DateTime.Today.AddDays(days).ToString("yyyy-MM-dd");
        }

        /// TASK 8
        /// <summary>
        /// Returns the checkout summary for an order.
        /// </summary>
        /// <param name="Small">How many of small plushies there are</param>
        /// <param name="Large">How many large plushies there are</param>
        /// <returns>Order summary including subtotal, tax, and total</returns>
        /// POST: https://localhost:7206/api/Assignment1/squashfellows
        /// Example cURL command:
        /// curl -X POST -d "Small=2&Large=1" "https://localhost:7206/api/Assignment1/squashfellows"
        [HttpPost("squashfellows")]
        public string SquashFellows([FromForm] int Small, [FromForm] int Large)
        {
            const double SmallPrice = 25.50;
            const double LargePrice = 40.50;
            const double TaxRate = 0.13;
            double subtotal = (Small * SmallPrice) + (Large * LargePrice);
            double tax = Math.Round(subtotal * TaxRate, 2);
            double total = subtotal + tax;

            return $"{Small} Small @ ${SmallPrice} = ${Small * SmallPrice:F2}; " +
                   $"{Large} Large @ ${LargePrice} = ${Large * LargePrice:F2}; " +
                   $"Subtotal = ${subtotal:F2}; Tax = ${tax:F2} HST; Total = ${total:F2}";
        }

    }
}