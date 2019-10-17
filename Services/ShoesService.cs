using System;
using System.Collections.Generic;
using ShoeShack.Models;
using ShoeShack.Repositories;

namespace ShoeShack.Services
{

  public class ShoesService
  {
    private readonly ShoesRepository _repo;
    public ShoesService(ShoesRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Shoe> Get()
    {
      return _repo.Get();
    }

    public Shoe Get(string id)
    {
      Shoe exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id Homie"); }
      return exists;
    }

    public Shoe Create(Shoe newShoe)
    {
      newShoe.Id = Guid.NewGuid().ToString();
      _repo.Create(newShoe);
      return newShoe;
    }

    public Shoe Edit(Shoe newData)
    {
      Shoe shoe = _repo.Get(newData.Id);
      if (shoe == null) { throw new Exception("Invalid Id Homie"); }
      shoe.Color = newData.Color;
      shoe.Name = newData.Name;
      shoe.Price = newData.Price;
      shoe.Size = newData.Size;
      _repo.Edit(shoe);
      return shoe;
    }

    public string Delete(string id)
    {
      Shoe shoe = _repo.Get(id);
      if (shoe == null) { throw new Exception("Invalid Id Homie"); }
      _repo.Delete(id);
      return "Successfully Booted";
    }
  }
}