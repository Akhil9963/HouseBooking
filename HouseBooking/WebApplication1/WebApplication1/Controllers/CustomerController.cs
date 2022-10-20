using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[Customer]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly BookingDbContext _db;
        public CustomerController(BookingDbContext context)
        {
            _db = context;
        }
        [HttpGet("GetAllCustomer")]
        public async Task<List<Customer>> GetAllCustomer()
        {
            try
            {
                var list = await _db.Customers.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("GetCustomerById")]
        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                return await _db.Customers.SingleOrDefaultAsync(x => x.CustId == id);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> Post([FromBody] Customer obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _db.Customers.Add(obj);
                await _db.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Customer obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var oldRec = await _db.Customers.SingleOrDefaultAsync(x => x.CustId == id);
                oldRec.Firstname = obj.Firstname;
                oldRec.Lastname = obj.Lastname;
                oldRec.Address = obj.Address;
                await _db.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete("DeleteCustomer")]
        public async Task<int> Delete(int id)
        {
            try
            {
                var rec = await _db.Customers.SingleOrDefaultAsync(x => x.CustId == id);
                _db.Customers.Remove(rec);
                await _db.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}