using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShoeShack.Models;
using ShoeShack.Services;
using ShoeStore.Models;

namespace ShoeStore.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class OrdersController : ControllerBase
  {

    private readonly OrdersService _ss;
    public OrdersController(OrdersService ss)
    {
      _ss = ss;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Order>> Get()
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
    public ActionResult<Order> Get(int id)
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


    [HttpGet("{id}/shoes")]
    public ActionResult<Order> GetShoes(int id)
    {
      try
      {
        return Ok(_ss.GetShoes(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Order> Create([FromBody] Order newOrder)
    {
      try
      {
        return Ok(_ss.Create(newOrder));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    public ActionResult<Order> Edit([FromBody] Order newOrder, int id)
    {
      try
      {
        newOrder.Id = id;
        return Ok(_ss.Edit(newOrder));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}/addShoe")]
    public ActionResult<string> AddShoeToOrder([FromBody] Shoe shoe, int id)
    {
      try
      {
        return Ok(_ss.AddShoe(id, shoe.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}/removeShoe")]
    public ActionResult<string> RemoveShoeFromOrder([FromBody] ShoeOrder so, int id)
    {
      try
      {
        so.OrderId = id;
        return Ok(_ss.RemoveShoe(so));
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