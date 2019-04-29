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
using Ninject;

namespace NecromancyApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Thoughts")]
    public class ThoughtsController : ControllerBase
    {
        private readonly IThought _thought;
        private readonly IMapper _mapper;

        public ThoughtsController(IMapper mapper, IThought thought)
        {
            _thought = thought;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetThoughtsAsync()
        {
            var getThought = await _thought.GetThoughts();
            var response = _mapper.Map<ApiThoughtsModel>(getThought);
            return Ok(response);
        }

    }

}