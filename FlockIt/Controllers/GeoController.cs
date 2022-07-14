using AutoMapper;
using FlockIt.Dtos;
using FlockIt.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FlockIt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeoController : ControllerBase
    {
        private readonly ILogger<GeoController> _logger;
        private readonly IGeoService _geoService;
        private readonly IMapper _mapper;

        public GeoController(ILogger<GeoController> logger, IGeoService geoService, IMapper mapper)
        {
            _logger = logger;
            _geoService = geoService;
            _mapper = mapper;
        }

        [HttpGet("state")]
        public async Task<ActionResult<StateDto>> GetGeoStateData(string state)
        {
            var result = await _geoService.GetStateGeo(state);

            var stateDto = _mapper.Map<StateDto>(result);

            return Ok(stateDto);

        }



    }
        
           
        
    
}
