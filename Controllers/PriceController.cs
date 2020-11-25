using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PriceService.Models;
using PriceService.Repository;

namespace PriceService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceRepository _priceRepository;
        private readonly ILogger<PriceController> _logger;
        private readonly IMapper _mapper;

        public PriceController(IPriceRepository priceRepository, ILogger<PriceController> logger, IMapper mapper)
        {
            _priceRepository = priceRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Price>> Get(CancellationToken token)
        {
            var priceDbModels = await _priceRepository.GetAll(token);
            var prices = _mapper.Map<IEnumerable<Price>>(priceDbModels);

            return prices;
        }
    }
}
