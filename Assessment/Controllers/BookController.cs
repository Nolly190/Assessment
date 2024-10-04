using Asp.Versioning;
using Assessment.Application.Dtos;
using Assessment.Application.Interfaces;
using Assessment.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Assessment.Controllers
{

    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BookController : BaseController
    {
        public IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<int>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<int>))]
        [HttpPost]
        [Authorize(Policy ="AddBook")]
        public async Task<IActionResult> AddBook([FromBody] AddBookViewModel model)
        {
            return ReturnResponse(await _bookService.AddBook(model));
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<BookViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<BookViewModel>))]
        [HttpGet("{id}")]
        [Authorize(Policy = "GetBook")]
        public async Task<IActionResult> GetBook(int id)
        {
            return ReturnResponse(await _bookService.GetBook(id));
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<List<BookViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<List<BookViewModel>>))]
        [HttpPost("search")]
        [Authorize(Policy = "SearchBook")]
        public async Task<IActionResult> GetAllBook([FromBody] SearchFilter model)
        {
            return ReturnResponse(await _bookService.SearchBooks(model));
        }

        [Authorize(Policy = "ReserveBook")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<List<BookViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<List<BookViewModel>>))]
        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBook([FromBody] BookReservationViewModel model)
        {
            return ReturnResponse(await _bookService.ReserveBook(model));
        }

        [Authorize(Policy = "BookReturn")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<List<BookViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<List<BookViewModel>>))]
        [HttpPost("returned")]
        public async Task<IActionResult> BookReturn([FromBody] BookReservationViewModel model)
        {
            return ReturnResponse(await _bookService.BookReturn(model));
        }


        [Authorize(Policy = "BookCollection")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<List<BookViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<List<BookViewModel>>))]
        [HttpPost("collection")]
        public async Task<IActionResult> ReserveBook([FromBody] BookCollectionViewModel model)
        {
            return ReturnResponse(await _bookService.BookCollection(model));
        }

        [Authorize(Policy = "ReservationNotification")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<List<BookViewModel>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<List<BookViewModel>>))]
        [HttpPost("reservation-notification")]
        public async Task<IActionResult> ReservationNotification([FromBody] BookReservationViewModel model)
        {
            return ReturnResponse(await _bookService.ReservationNotification(model));
        }
    }
}
