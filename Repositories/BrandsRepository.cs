using System;
using System.Collections.Generic;
using System.Data;
using ShoeShack.Models;
using Dapper;

namespace ShoeShack.Repositories
{
  public class BrandsRepository
  {
    private readonly IDbConnection _db;
    public BrandsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Brand> Get()
    {
      string sql = "SELECT * FROM brands";
      return _db.Query<Brand>(sql);
    }

    public Brand Get(int id)
    {
      string sql = "SELECT * FROM brands WHERE id = @id";
      return _db.QueryFirstOrDefault<Brand>(sql, new { id });
    }

    public int Create(Brand newBrand)
    {
      string sql = @"
            INSERT INTO brands
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
      return _db.ExecuteScalar<int>(sql, newBrand); //get the new id back from line 36 and return to service

    }

    public void Edit(Brand brand)
    {
      string sql = @"
            UPDATE brands
            SET
                name = @Name
            WHERE id = @Id";
      _db.Execute(sql, brand);

    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM brands WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}