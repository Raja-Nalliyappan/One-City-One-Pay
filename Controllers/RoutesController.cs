using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using One_City_One_Pay.Data;

namespace One_City_One_Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly RoutesRepository _routesRepository;

        public RoutesController(RoutesRepository routesRepository)
        {
            _routesRepository = routesRepository;
        }

        [HttpGet("BikeRoute")]
        public IActionResult GetAllBikeRoutes()
        {
            try
            {
                var routes = _routesRepository.GetAllBikeRoutes();
                return Ok(routes);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Error fetching bike routes", error = ex.Message });
            }
        }

        [HttpGet("AutoRoute")]
        public IActionResult GetAllAutoRoutes()
        {
            try
            {
                var routes = _routesRepository.GetAllAutoRoutes();
                return Ok(routes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error fetching auto routes", error = ex.Message });
            }
        }

        [HttpGet("CarRoute")]
        public IActionResult GetAllCarRoutes()
        {
            try
            {
                var routes = _routesRepository.GetAllCarRoutes();
                return Ok(routes);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Error fetching car routes", error = ex.Message });
            }
        }

        [HttpGet("BusRoute")]
        public IActionResult GetAllBusRoutes()
        {
            try
            {
                var routes = _routesRepository.GetAllBusRoutes();
                return Ok(routes);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Error fetching bus routes", error = ex.Message });
            }
        }

        [HttpGet("MetroRoute")]
        public IActionResult GetAllMetroRoutes()
        {
            try
            {
                var routes = _routesRepository.GetAllMetroRoutes();
                return Ok(routes);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Error fetching metro routes", error = ex.Message });
            }
        }

        [HttpGet("LocalTrainRoute")]
        public IActionResult GetAllLocalTrainRoutes()
        {
            try
            {
                var routes = _routesRepository.GetAllLocalTrainRoutes();
                return Ok(routes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error fetching local-train routes", error = ex.Message });
            }
        }
    }
}
