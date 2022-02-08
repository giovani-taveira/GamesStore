using AutoMapper;
using GamesStore.Application.Interface;
using GamesStore.Authentication.Services;
using GamesStore.Data;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(saleService.GetAll());
        }

        [HttpPost("{gameId}")]
        public IActionResult AddNewSale(Guid gameId, AddSaleInputModel model)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            return Ok(saleService.AddNewSale(gameId, model));
        }

        [HttpDelete("{saleId}")]
        public IActionResult DeleteSale(Guid saleId)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            saleService.DeleteSale(saleId);
            return NoContent();
        }

        /// <remarks>
        /// Promoçao é deletada se tiver passado da data limite de duração
        /// </remarks>
        [HttpDelete]
        public async Task<IActionResult> DeleteSale()
        {
            saleService.DeleteSale();
            return NoContent();
        }
    }
}
