using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using One_City_One_Pay.Data;
using One_City_One_Pay.Moduls;

namespace One_City_One_Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingCountAndAmountController : ControllerBase
    {
        public readonly BookingCountAndAmountRepository _bookingCountAndAmountRepository;
        public BookingCountAndAmountController(BookingCountAndAmountRepository bookingCountAndAmountRepository)
        {
            _bookingCountAndAmountRepository = bookingCountAndAmountRepository;
        }

        //Posting Booking Count and Amount for All Vehicles

        [HttpPost("BookingCountAndAmountBike")]

        public IActionResult BookingCountAndAmountBike([FromBody] BikeBookingCountAndAmount request)
        {
            if (request == null)
                return BadRequest("Request data is null.");
            try
            {
                _bookingCountAndAmountRepository.AddBikeBookingCountAndAmount(request.BookingAmount, request.VehicleType, request.UserName);
                return Ok("Booking Count and Amount Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("BookingCountAndAmountAuto")]
        public IActionResult BookingCountAndAmountAuto([FromBody] AutoBookingCountAndAmount request)
        {
            if (request == null)
                return BadRequest("Request data is null.");
            try
            {
                _bookingCountAndAmountRepository.AddAutoBookingCountAndAmount(request.BookingAmount, request.VehicleType, request.UserName);
                return Ok("Booking Count and Amount Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("BookingCountAndAmountCar")]
        public IActionResult BookingCountAndAmountCar([FromBody] CarBookingCountAndAmount request)
        {
            if (request == null)
                return BadRequest("Request data is null.");
            try
            {
                _bookingCountAndAmountRepository.AddCarBookingCountAndAmount(request.BookingAmount, request.VehicleType, request.UserName);
                return Ok("Booking Count and Amount Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("BookingCountAndAmountBus")]
        public IActionResult BookingCountAndAmountBus([FromBody] BusBookingCountAndAmount request)
        {
            if (request == null)
                return BadRequest("Request data is null.");
            try
            {
                _bookingCountAndAmountRepository.AddBusBookingCountAndAmount(request.BookingAmount, request.VehicleType, request.UserName);
                return Ok("Booking Count and Amount Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("BookingCountAndAmountMetro")]
        public IActionResult BookingCountAndAmountMetro([FromBody] MetroBookingCountAndAmount request)
        {
            if (request == null)
                return BadRequest("Request data is null.");
            try
            {
                _bookingCountAndAmountRepository.AddMetroBookingCountAndAmount(request.BookingAmount, request.VehicleType, request.UserName);
                return Ok("Booking Count and Amount Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("BookingCountAndAmountLocalTrain")]
        public IActionResult BookingCountAndAmountLocalTrain([FromBody] LocalTrainBookingCountAndAmount request)
        {
            if (request == null)
                return BadRequest("Request data is null.");
            try
            {
                _bookingCountAndAmountRepository.AddLocalTrainBookingCountAndAmount(request.BookingAmount, request.VehicleType, request.UserName);
                return Ok("Booking Count and Amount Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




        // Get Booking Count and Amount for All Vehicles

        [HttpGet("GetBikeBookingCountAndAmount")]

        public IActionResult GetBikeBookingCountAndAmount()
        {
            try
            {
                var bookings = _bookingCountAndAmountRepository.GetBikeBookingCountAndAmount();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching bike booking counts and amounts.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("GetAutoBookingCountAndAmount")]
        public IActionResult GetAutoBookingCountAndAmount()
        {
            try
            {
                var bookings = _bookingCountAndAmountRepository.GetAutoBookingCountAndAmount();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching auto booking counts and amounts.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("GetCarBookingCountAndAmount")]
        public IActionResult GetCarBookingCountAndAmount()
        {
            try
            {
                var bookings = _bookingCountAndAmountRepository.GetCarBookingCountAndAmount();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching car booking counts and amounts.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("GetBusBookingCountAndAmount")]
        public IActionResult GetBusBookingCountAndAmount()
        {
            try
            {
                var bookings = _bookingCountAndAmountRepository.GetBusBookingCountAndAmount();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching bus booking counts and amounts.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("GetMetroBookingCountAndAmount")]
        public IActionResult GetMetroBookingCountAndAmount()
        {
            try
            {
                var bookings = _bookingCountAndAmountRepository.GetMetroBookingCountAndAmount();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching metro booking counts and amounts.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("GetLocalTrainBookingCountAndAmount")]
        public IActionResult GetLocalTrainBookingCountAndAmount()
        {
            try
            {
                var bookings = _bookingCountAndAmountRepository.GetLocalTrainBookingCountAndAmount();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An error occurred while fetching local train booking counts and amounts.",
                    error = ex.Message
                });
            }
        }
    }
}
