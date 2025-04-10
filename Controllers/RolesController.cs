﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelReservationFinal.Data;
using HotelReservationFinal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RolesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Roles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    // GET: api/Roles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Roles>> GetRole(int id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        return role;
    }

    // POST: api/Roles
    [HttpPost]
    public async Task<ActionResult<Roles>> PostRole(Roles role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetRole", new { id = role.RoleId }, role);
    }

    // PUT: api/Roles/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRole(int id, Roles role)
    {
        if (id != role.RoleId)
        {
            return BadRequest();
        }
        _context.Entry(role).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Roles.Any(e => e.RoleId == id))
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

    // DELETE: api/Roles/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var role = await _context.Roles.FindAsync(id);
        if (role == null)
        {
            return NotFound();
        }
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
