﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project4.Models;
using Project4.Services;

namespace Project4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DBContext _context;

        public ProductsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Products> GetProducts()
        {
            return _context.Products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts([FromRoute] int id, [FromBody] Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products.Id)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProducts([FromBody] Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetProductByName(string search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var c = await _context.Products.ToListAsync();
            var data = c.FindAll(x => x.Name.ToLower().Contains(search.ToLower()));

            if (c == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("sort")]
        public async Task<IActionResult> GetCouponByName(string sort,string type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var c = await _context.Products.ToListAsync();
            var data = c.ToList();
            if(sort == "salePrice")
            {
                if(type == "ASC")
                {
                    data = c.OrderBy(x => x.SalePrice).ToList();
                }
                else
                {
                    data = c.OrderByDescending(x => x.SalePrice).ToList();
                }
            }
            if(sort == "sold")
            {
                if (type == "ASC")
                {
                    data = c.OrderBy(x => x.Sold).ToList();
                }
                else
                {
                    data = c.OrderByDescending(x => x.Sold).ToList();
                }
            }
            if (sort == "name")
            {
                if (type == "ASC")
                {
                    data = c.OrderBy(x => x.Name).ToList();
                }
                else
                {
                    data = c.OrderByDescending(x => x.Name).ToList();
                }
            }

            if (c == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}