using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TruckAPI.Data;
using TruckAPI.Models;

namespace TruckAPI.Controllers
{
    [Route("truck")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        //Injecting the DataContext into the controller
        private readonly DataContext _context;

        public TruckController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/trucks")] //Get all trucks
        public async Task<ActionResult> GetAllTrucks()
        {
            var trucks = await _context.Trucks.ToListAsync();

            return Ok(trucks);
        }

        [HttpGet("{id}")] //Get a specific truck
        public async Task<ActionResult> GetOneTruck(Guid id)
        {
            var truck = await _context.Trucks.FindAsync(id);
            if (truck == null)
                return BadRequest("Entry not found!");

            return Ok(truck);
        }

        [HttpPost] //Adds a new truck entry
        public async Task<ActionResult> AddEntry(Truck truck)
        {

            //Automatically calculates the netweight given the TareWeight and GrossWeight
            truck.NetWeight = truck.TareWeight + truck.GrossWeight;

            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync();

            return Ok(await _context.Trucks.ToListAsync());

        }

        [HttpPut]//Updates a truck entry
        public async Task<ActionResult> UpdateEntry(Truck updatedTruck)
        {
            var truckEntry = await _context.Trucks.FindAsync(updatedTruck.Id);
            if (truckEntry == null)
                return BadRequest("Entry not found!");

            truckEntry.Registration = updatedTruck.Registration;
            truckEntry.GrossWeight = updatedTruck.GrossWeight;
            truckEntry.TareWeight = updatedTruck.TareWeight;
            truckEntry.NetWeight = updatedTruck.NetWeight;
            truckEntry.Haulier = updatedTruck.Haulier;

            await _context.SaveChangesAsync();

            return Ok(await _context.Trucks.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTruck(Truck truck)
        {
            var toDelete = await _context.Trucks.FindAsync(truck.Id);
            if(toDelete == null)
            {
                return BadRequest("Entry not found!");
            }

            _context.Trucks.Remove(toDelete);
            await _context.SaveChangesAsync();

            return Ok(await _context.Trucks.ToListAsync());
        }

    }
}
