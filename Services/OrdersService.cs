using System;
using System.Collections.Generic;
using ShoeShack.Models;
using ShoeShack.Repositories;
using ShoeStore.Models;

namespace ShoeShack.Services
{
  public class OrdersService
  {
    private readonly OrdersRepository _repo;
    private readonly ShoesRepository _shoeRepo;
    public OrdersService(OrdersRepository repo, ShoesRepository shoeRepo)
    {
      _shoeRepo = shoeRepo;
      _repo = repo;
    }

    public IEnumerable<Order> Get()
    {
      return _repo.Get();
    }

    public Order Get(int id)
    {
      Order exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id Homie"); }
      return exists;
    }

    public Order Create(Order newOrder)
    {
      int id = _repo.Create(newOrder);
      newOrder.Id = id;
      return newOrder;
    }

    public Order Edit(Order newData)
    {
      Order order = _repo.Get(newData.Id);
      if (order == null) { throw new Exception("Invalid Id Homie"); }
      order.CustomerName = newData.CustomerName;
      _repo.Edit(order);
      return order;
    }

    public IEnumerable<Shoe> GetShoes(int orderId)
    {
      Order order = _repo.Get(orderId);
      if (order == null) { throw new Exception("Invalid Id Homie"); }
      return _repo.GetShoesByOrderId(orderId);
    }

    public string Delete(int id)
    {
      Order order = _repo.Get(id);
      if (order == null) { throw new Exception("Invalid Id Homie"); }
      _repo.Delete(id);
      return "Successfully Booted";
    }


    //SECTION SHOE ORDERS
    public string AddShoe(int id, string shoeId)
    {
      Order order = _repo.Get(id);
      if (order == null) { throw new Exception("Invalid Order Id Homie"); }
      Shoe shoeToAdd = _shoeRepo.Get(shoeId);
      if (shoeToAdd == null) { throw new Exception("Invalid Shoe Id Homie"); }
      _repo.AddShoe(id, shoeId);
      return "Successfully added Shoe to Order";
    }

    public string RemoveShoe(ShoeOrder so)
    {
      ShoeOrder exists = _repo.GetShoeOrder(so);
      if (exists == null) { throw new Exception("Invalid Info Homie"); }
      _repo.RemoveShoeFromOrder(exists.Id);
      return "Successfully Booted";
    }
  }
}