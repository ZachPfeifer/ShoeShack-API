using System.Collections.Generic;
using System.Data;
using Dapper;
using ShoeShack.Models;
using ShoeStore.Models;

namespace ShoeShack.Repositories
{
  public class OrdersRepository
  {
    private readonly IDbConnection _db;
    public OrdersRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Order> Get()
    {
      string sql = "SELECT * FROM orders";
      return _db.Query<Order>(sql);
    }

    public Order Get(int id)
    {
      //FIXME get the relational data
      string sql = "SELECT * FROM orders WHERE id = @id";
      return _db.QueryFirstOrDefault<Order>(sql, new { id });
    }

    public int Create(Order newOrder)
    {
      string sql = @"
            INSERT INTO orders
            (customerName)
            VALUES
            (@CustomerName);
            SELECT LAST_INSERT_ID();
            ";
      return _db.ExecuteScalar<int>(sql, newOrder); //get the new id back from line 36 and return to service

    }

    public void Edit(Order order)
    {
      string sql = @"
            UPDATE orders
            SET
                customerName = @CustomerName
            WHERE id = @Id";
      _db.Execute(sql, order);

    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM orders WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    public void AddShoe(int orderId, string shoeId)
    {
      string sql = @"
            INSERT INTO shoesorders
            (orderId, shoeId)
            VALUES
            (@orderId, @shoeId)";
      _db.Execute(sql, new { orderId, shoeId });
    }

    public IEnumerable<Shoe> GetShoesByOrderId(int orderId)
    {
      string sql = @"
                SELECT * FROM shoesorders so
                INNER JOIN shoes s ON s.id = so.shoeId
                WHERE so.orderId = @orderId
            ";
      return _db.Query<Shoe>(sql, new { orderId });
    }

    internal ShoeOrder GetShoeOrder(ShoeOrder so)
    {
      string sql = "SELECT * FROM shoesorders WHERE orderId = @OrderId AND shoeId = @ShoeId";
      return _db.QueryFirstOrDefault<ShoeOrder>(sql, so);
    }

    public void RemoveShoeFromOrder(int id)
    {
      string sql = "DELETE FROM shoesorders WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}