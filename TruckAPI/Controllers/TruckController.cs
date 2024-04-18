using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TruckAPI.Data;
using TruckAPI.Models;
using System;
using System.Threading.Tasks;

namespace TruckAPI.Controllers
{
    // Define a controller for handling truck-related operations
    [Route("truck")] // Base route for all actions within this controller
    [ApiController] // Specifies that this controller responds to HTTP API requests
    public class TruckController : ControllerBase
    {
        // Injecting the DataContext into the controller for database operations
        private readonly DataContext _context;

        // Constructor for the TruckController class, accepting DataContext as a parameter
        public TruckController(DataContext context)
        {
            _context = context;
        }

        // HTTP GET method for retrieving all trucks
        [HttpGet("/trucks")] // Route for getting all trucks
        public async Task<ActionResult> GetAllTrucks()
        {
            // Retrieve all trucks from the database
            var trucks = await _context.Trucks.ToListAsync();

            // Return a response with the retrieved trucks
            return Ok(trucks);
        }

        // HTTP GET method for retrieving a specific truck by ID
        [HttpGet("{id}")] // Route for getting a specific truck by ID
        public async Task<ActionResult> GetOneTruck(Guid id)
        {
            // Find a truck in the database by its ID
            var truck = await _context.Trucks.FindAsync(id);

            // If the truck is not found, return a BadRequest response
            if (truck == null)
                return BadRequest("Entry not found!");

            // Return a response with the retrieved truck
            return Ok(truck);
        }

        // HTTP POST method for adding a new truck entry
        [HttpPost] // Route for adding a new truck entry
        public async Task<ActionResult> AddEntry(Truck truck)
        {
            // Automatically calculate the net weight given the tare weight and gross weight
            truck.NetWeight = truck.TareWeight + truck.GrossWeight;

            // Add the new truck entry to the database
            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync();

            // Return a response with all trucks after the new entry has been added
            return Ok(await _context.Trucks.ToListAsync());
        }

        // HTTP PUT method for updating an existing truck entry
        [HttpPut] // Route for updating a truck entry
        public async Task<ActionResult> UpdateEntry(Truck updatedTruck)
        {
            // Find the existing truck entry in the database by its ID
            var truckEntry = await _context.Trucks.FindAsync(updatedTruck.Id);

            // If the truck entry is not found, return a BadRequest response
            if (truckEntry == null)
                return BadRequest("Entry not found!");

            // Update the properties of the existing truck entry with the values from the updated truck
            truckEntry.Registration = updatedTruck.Registration;
            truckEntry.GrossWeight = updatedTruck.GrossWeight;
            truckEntry.TareWeight = updatedTruck.TareWeight;
            truckEntry.NetWeight = updatedTruck.NetWeight;
            truckEntry.Haulier = updatedTruck.Haulier;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return a response with all trucks after the update has been applied
            return Ok(await _context.Trucks.ToListAsync());
        }

        // HTTP DELETE method for deleting a truck entry
        [HttpDelete] // Route for deleting a truck entry
        public async Task<ActionResult> DeleteTruck(Truck truck)
        {
            // Find the truck entry in the database by its ID
            var toDelete = await _context.Trucks.FindAsync(truck.Id);

            // If the truck entry is not found, return a BadRequest response
            if (toDelete == null)
            {
                return BadRequest("Entry not found!");
            }

            // Remove the truck entry from the database
            _context.Trucks.Remove(toDelete);
            await _context.SaveChangesAsync();

            // Return a response with all trucks after the deletion
            return Ok(await _context.Trucks.ToListAsync());
        }
    }
}
