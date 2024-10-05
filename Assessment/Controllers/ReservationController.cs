using Asp.Versioning;
using Assessment.Application.Dtos;
using Assessment.Application.Implementation;
using Assessment.Application.Interfaces;
using Assessment.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;

namespace Assessment.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [EnableRateLimiting("fixedLimit")]
    public class ReservationController : BaseController
    {
        public IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [Authorize(Policy = "ReserveBook")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<List<BookViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<List<BookViewModel>>))]
        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBook([FromBody] BookReservationViewModel model)
        {
            return ReturnResponse(await _reservationService.ReserveBook(model));
        }

        [Authorize(Policy = "ReservationNotification")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<List<BookViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<List<BookViewModel>>))]
        [HttpPost("-")]
        public async Task<IActionResult> ReservationNotification([FromBody] BookReservationViewModel model)
        {
            return ReturnResponse(await _reservationService.ReservationNotification(model));
        }

        [Authorize(Policy = "ReservationNotifications")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PaginationResult<List<ReservationNotificationViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(PaginationResult<List<ReservationNotificationViewModel>>))]
        [HttpPost("notifications")]
        public async Task<IActionResult> GetAllReservationNotifications([FromBody] SearchFilter model)
        {
            return ReturnResponse(await _reservationService.GetAllReservationNotifications(model));
        }

        [Authorize(Policy = "GetAllReservations")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PaginationResult<List<ReservationViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(PaginationResult<List<ReservationViewModel>>))]
        [HttpPost("reservations")]
        public async Task<IActionResult> GetAllReservations([FromBody] SearchFilter model)
        {
            return ReturnResponse(await _reservationService.GetAllReservations(model));
        }

        [Authorize(Policy = "GetReservation")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<ReservationViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<ReservationViewModel>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            return ReturnResponse(await _reservationService.GetReservation(id));
        }



        //Task<PaginationResult<List<ReservationViewModel>>> GetAllReservations(SearchFilter param);
        //Task<Result<PaginationResult<ReservationNotificationViewModel>>> GetAllReservationNotifications(SearchFilter param);
        //Task<Result<ReservationViewModel>> GetReservation(BookReservationViewModel entity);
    }
}
