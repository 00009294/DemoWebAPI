﻿using DemoWebAPI.DataContext;
using DemoWebAPI.Models;

namespace DemoWebAPI.Repostories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext AppDbContext;
        public ProductRepository(AppDbContext AppDbContext)
        {
            this.AppDbContext = AppDbContext;
        }
        public Result Create(Product product)
        {
            if (product == null)
            {
                return new Result
                {
                    Status = false,
                    Message = "Product is not found"

                };
            }

            this.AppDbContext.Products.Add(product);
            this.AppDbContext.SaveChanges();

            return new Result
            {
                Status = true,
                Message = "Successfully created"
            };
        }

        public Result Delete(Guid id)
        {
            var product = this.AppDbContext.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                this.AppDbContext.Products.Remove(product);
                this.AppDbContext.SaveChanges();

                return new Result
                {
                    Status = true,
                    Message = "Successfully deleted"
                };

            }

            return new Result
            {
                Status = false,
                Message = "Failed at deleting"
            };
        }

        public List<Product> GetAll(string name)
        {
            if (name == null)
            {
                return new List<Product>();
            }

            List<Product> products = this.AppDbContext.Products.Where(p => p.Name == name).ToList();

            return products;
        }

        public List<Product> GetAll()
        {
            return this.AppDbContext.Products.ToList();
        }

        public Result Update(Guid id, Product product)
        {
            var oldproduct = this.AppDbContext.Products.First(p => p.Id == id);

            if (oldproduct != null)
            {
                Product newProduct = new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                };

                this.AppDbContext.Products.Update(newProduct);
                this.AppDbContext.SaveChanges();

                return new Result
                {
                    Status = true,
                    Message = "Successfully updated"
                };
            }

            return new Result
            {
                Status = false,
                Message = "Product not found"
            };

        }
    }
}
