﻿using Microsoft.AspNetCore.Mvc;
using SurfsUpAPI.Models;

namespace SurfsUpAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class SurfboardsController : ControllerBase
    {
        [HttpGet]
        public string GetSurfboards()
        {
            return "Reading all Surfboards";
        }

        [HttpGet("{id}")]
        public string GetSurfboard(int id)
        {
            return $"Reading Surfboard with id {id}";
        }

        [HttpPost]
        public string CreateSurfboard([FromBody] Surfboard surfboard)
        {
            return $"Creating Surfboard";

        }

        [HttpPatch("{id}")]
        public string UpdateSurfboard(int id)
        {
            return $"Updating Surfboard with id {id}";
        }

        [HttpDelete]
        public string DeleteSurfboard(int id)
        {
            return $"Deleting Surfboard with id {id}";
        }



    }
}
