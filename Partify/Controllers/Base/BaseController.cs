using Azure;
using Microsoft.AspNetCore.Mvc;
using Partify.Application.Common;

namespace Partify.API.Controllers.Base
{
    public class BaseController:ControllerBase

    {
        public IActionResult HandleResponse<T>(Result<T> response)
        {
            try
            {
                if (response.Success && response.Value == null)
                {
                    return NotFound();
                }
                else if (response.Success && response.Value != null)
                {
                    return Ok(response.Value);
                }
                else if (!response.Success && response.Errors != null)
                {
                    return BadRequest(response.Errors);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult<T> HandleResultResponse<T>(Result<T> response) // Fully qualify Result<T>
        {
            try
            {
                if (response.Success && response.Value == null)
                {
                    return NotFound(response.Errors);
                }
                else if (response.Success && response.Value != null)
                {
                    return Ok(response.Value);
                }
                else if (!response.Success && response.Errors != null)
                {
                    return BadRequest(response.Errors);
                }
                else
                {
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
