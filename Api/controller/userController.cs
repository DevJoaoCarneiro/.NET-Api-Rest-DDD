using Application.Interfaces;
using Application.Request;
using Application.Response;
using Application.Service;
using Domain.entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.controller
{
    [ApiController]
    [Route("api/society")]
    public class userController : ControllerBase
    {

        private readonly IUserServices _userService;

        public userController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> registerUser([FromBody] UserRequestDTO userRequestDTO)
        {

            try
            {
                var result = await _userService.createUser(userRequestDTO);

                return result.status switch
                {
                    "invalid_argument" => BadRequest(500),
                    "not_found" => NotFound(404),
                    "internal_error" => StatusCode(500),
                    "error" => StatusCode(500),
                    _ => Ok(result)
                };
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
             
        }

    }
}
