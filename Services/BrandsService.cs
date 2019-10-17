using System;
using System.Collections.Generic;
using ShoeShack.Models;
using ShoeShack.Repositories;

namespace BrandShack.Services
{
  public class BrandsService
  {
    private readonly BrandsRepository _repo;
    public BrandsService(BrandsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Brand> Get()
    {
      return _repo.Get();
    }

    public Brand Get(int id)
    {
      Brand exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id Homie"); }
      return exists;
    }

    public Brand Create(Brand newBrand)
    {
      //checkname
      int id = _repo.Create(newBrand);
      newBrand.Id = id;
      return newBrand;
    }

    public Brand Edit(Brand newData)
    {
      Brand brand = _repo.Get(newData.Id);
      if (brand == null) { throw new Exception("Invalid Id Homie"); }
      brand.Name = newData.Name;
      _repo.Edit(brand);
      return brand;
    }

    public string Delete(int id)
    {
      Brand brand = _repo.Get(id);
      if (brand == null) { throw new Exception("Invalid Id Homie"); }
      _repo.Delete(id);
      return "Successfully Booted";
    }
  }
}