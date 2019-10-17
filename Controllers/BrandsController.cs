using System;
using System.Collections.Generic;
using BrandShack.Services;
using Microsoft.AspNetCore.Mvc;

using ShoeShack.Models;

namespace Brandshack.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class BrandsController : ControllerBase
  {

    private readonly BrandsService _ss;
    public BrandsController(BrandsService ss)
    {
      _ss = ss;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Brand>> Get()
    {
      try
      {
        return Ok(_ss.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Brand> Get(int id)
    {
      try
      {
        return Ok(_ss.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Brand> Create([FromBody] Brand newBrand)
    {
      try
      {
        return Ok(_ss.Create(newBrand));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Brand> Edit([FromBody] Brand newBrand, int id)
    {
      try
      {
        newBrand.Id = id;
        return Ok(_ss.Edit(newBrand));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_ss.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
