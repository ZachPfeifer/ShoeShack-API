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
      if (exists == null) { throw new Exception("Bad ID"); }
      return exists;
    }

    public Shoe Create(Shoe newShoe)
    {
      Shoe exists = _repo.Exists("name", newShoe.Name);
      newShoe.Id = Guid.NewGuid().ToString();
      _repo.Create(newShoe);
      return newShoe;
    }

    public Shoe Edit(Shoe editShoeData)
    {
      Shoe shoe = _repo.Get(editShoeData.Id);
      if (shoe == null) { throw new Exception("Invalid Id"); }
      shoe.Name = editShoeData.Name;
      shoe.Description = editShoeData.Description;
      shoe.Price = editShoeData.Price;
      _repo.Edit(editShoeData);
      return editShoeData;
    }

    public string Delete(string id)
    {
      Shoe shoe = _repo.Get(id);
      if (shoe == null) { throw new Exception("Bad ID"); }
      _repo.Remove(id);
      return "successfully deleted";
    }
  }
}