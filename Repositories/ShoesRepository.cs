using System;
using System.Collections.Generic;
using System.Data;
using ShoeShack.Models;
using Dapper;

namespace ShoeShack.Repositories
{
  public class ShoesRepository
  {
    private readonly IDbConnection _db;
    public ShoesRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Shoe> Get()
    {
      string sql = "SELECT * FROM shoes";
      return _db.Query<Shoe>(sql);
    }

    public Shoe Get(string id)
    {
      string sql = "SELECT * FROM shoes WHERE id = @id";
      return _db.QueryFirstOrDefault<Shoe>(sql, new { id });
    }

    public void Create(Shoe newShoe)
    {
      string sql = @"
            INSERT INTO shoes
            (id, name, price, size, color, brandId)
            VALUES
            (@Id, @Name, @Price, @Size, @Color, @BrandId)";
      _db.Execute(sql, newShoe);
    }

    public void Edit(Shoe shoe)
    {
      string sql = @"
            UPDATE shoes
            SET
                name = @Name,
                color = @Color,
                size = @Size,
                price = @Price
            WHERE id = @Id";
      _db.Execute(sql, shoe);

    }

    public void Delete(string id)
    {
      string sql = "DELETE FROM shoes WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    public IEnumerable<Shoe> GetOrdersByShoeId(string shoeId)
    {
      string sql = @"
                SELECT * FROM shoesorders so
                INNER JOIN orders o ON o.id = so.orderId
                WHERE so.shoeId = @shoeId
            ";
      return _db.Query<Shoe>(sql, new { shoeId });
    }
  }
}