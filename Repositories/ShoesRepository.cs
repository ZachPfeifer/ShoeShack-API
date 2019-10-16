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

    internal IEnumerable<Shoe> Get()
    {
      string sql = "SELECT * FROM shoes";
      //Dapper will call to database and all objects return will be cast to <Shoe>
      return _db.Query<Shoe>(sql);
    }

    internal Shoe Get(string id)
    {
      string sql = "SELECT * FROM shoes WHERE id = @id";
      //NOTE Dapper requires a second object that it can pull the properties off of and connects them through the @ symbol
      return _db.QueryFirstOrDefault<Shoe>(sql, new { id });
    }

    internal Shoe Exists(string property, string value)
    {
      string sql = "SELECT * FROM shoes WHERE @property = @value";
      return _db.QueryFirstOrDefault<Shoe>(sql, new { property, value });
    }

    internal void Create(Shoe shoeData)
    {
      string sql = @"
            INSERT INTO shoes
            (id, name, description, price)
            VALUES
            (@Id, @Name, @Description, @Price)
            ";
      _db.Execute(sql, shoeData);
    }

    internal void Edit(Shoe shoeData)
    {
      string sql = @"
            UPDATE shoes
            SET 
            name = @Name,
            color = @Color,
            size = @Size,
            price = @Price,
            description = @Description
            WHERE id = @Id; 
            ";
      _db.Execute(sql, shoeData);
    }

    internal void Remove(string id)
    {
      string sql = "DELETE FROM shoes WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}