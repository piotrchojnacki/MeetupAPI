﻿using AutoMapper;
using MeetupAPI.Contexts;
using MeetupAPI.Entities;
using MeetupAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MeetupAPI.Controllers
{
    [Route("api/meetup")]
    public class MeetupController : ControllerBase
    {
        private readonly MeetupContext _meetupContext;
        private readonly IMapper _mapper;

        public MeetupController(MeetupContext meetupContext, IMapper mapper)
        {
            _meetupContext = meetupContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<MeetupDetailsDto>> Get()
        {
            var meetups = _meetupContext.Meetups
                .Include(m => m.Location)
                .ToList();

            var meetupDtos = _mapper.Map<List<MeetupDetailsDto>>(meetups);

            return Ok(meetupDtos);
        }

        [HttpGet("{name}")]
        public ActionResult<MeetupDetailsDto> Get(string name)
        {
            var meetup = _meetupContext.Meetups
                .Include(m => m.Location)
                .FirstOrDefault(m => m.Name.Replace(" ", "-").ToLower() == name.Replace(" ", "-").ToLower());

            if(meetup == null)
            {
                return NotFound();
            }

            var meetupDto = _mapper.Map<MeetupDetailsDto>(meetup);            

            return Ok(meetupDto);
        }

        [HttpPost]
        public ActionResult Post([FromBody]MeetupDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meetup = _mapper.Map<Meetup>(model);

            _meetupContext.Meetups.Add(meetup);
            _meetupContext.SaveChanges();

            var key = meetup.Name.Replace(" ", "-").ToLower();

            return Created("api/meetup/" + key, null);
        }
    }
}
