using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointOfSale.Application.Models;
using PointOfSale.Application.Services;
using PointOfSale.DataAccess.Entities;

namespace PointOfSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleTransactionController : ControllerBase
    {
        private readonly ISaleTransactionService saleTransactionService;
        public SaleTransactionController(ISaleTransactionService transactionService)
        {
            saleTransactionService = transactionService;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(string), 401)]
        [ProducesResponseType(500)]
        [ProducesResponseType(typeof(string),401)]
        public async Task<Guid> Create(SaleTransactionDTO saleTransactionDTO)
        {
            
            return await saleTransactionService.Create(saleTransactionDTO);
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(List<SaleTransaction>), 200)]
        [ProducesResponseType(typeof(string), 401)]
        [ProducesResponseType(500)]
        public List<SaleTransaction> GetAllByStoreGLN(string GLN)
        {
            return saleTransactionService.GetAllByStoreGLN(GLN);
        }
    }
}