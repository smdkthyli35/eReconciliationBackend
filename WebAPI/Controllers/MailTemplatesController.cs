﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailTemplatesController : ControllerBase
    {
        private readonly IMailTemplateService _mailTemplateService;

        public MailTemplatesController(IMailTemplateService mailTemplateService)
        {
            _mailTemplateService = mailTemplateService;
        }

        [HttpPost("add")]
        public IActionResult Add(MailTemplate mailTemplate)
        {
            var result = _mailTemplateService.Add(mailTemplate);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
    }
}