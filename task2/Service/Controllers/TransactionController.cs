using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Configuration.Repositories;
using Service.Models;
using Service.Models.Dto;

namespace Service.Controllers
{
    [ApiController]
    [Route("/api/service/transaction")]
    public class TransactionController : ControllerBase
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;

        public TransactionController(
            ITransactionRepository transactionRepository,
            IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction([FromBody] TransactionDto transactionDto)
        {
            var transaction = _mapper.Map<TransactionDto, Transaction>(transactionDto);
            return Ok(await _transactionRepository.Create(transaction));
        }

        [HttpPatch]
        public async Task<ActionResult<Transaction>> UpdateTransactionStatus(ChangeStatusDto transactionStatus)
        {
            return Ok(await _transactionRepository.UpdateStatus(transactionStatus.Id, transactionStatus.Status));
        }
    }
}