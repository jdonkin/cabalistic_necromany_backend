using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NecromancyApi.Models;
using PdqNecromancyService.Interfaces;
using PdqNecromancyService.Services;

namespace NecromancyApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Thoughts")]
    public class ThoughtsController : ControllerBase
    {
        private readonly IThought _thought; //todo: setting IOC to handle this
        private readonly IMapper _mapper;

        public ThoughtsController(IMapper mapper)
        {
            _thought = new Thoughts();
            _mapper = mapper;
        }
        [HttpGet]
        [Route("")]
        public async Task<ApiThoughtsModel> GetThoughtsAsync()
        {
            var getThought = await _thought.GetThoughts();
            return _mapper.Map<ApiThoughtsModel>(getThought);
        }


        [Route("api/Thoughts/Bad")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [Route("api/Thoughts/internal")]
        public ActionResult GetInternalError()
        {
            return StatusCode(500);
        }
    }

}