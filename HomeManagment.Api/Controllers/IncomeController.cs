﻿using HomeManagment.Application.DTOs.Incomes;
using HomeManagment.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace HomeManagment.Api.Controllers;


[Authorize]                     
[Route("api/[controller]")]
public class IncomeController : ControllerBase
{
    private readonly IIncomeService _incomeService;
    public IncomeController(IIncomeService incomeService)
    {
        _incomeService = incomeService;
    }
    [HttpGet]
    public IActionResult GetIncomes()
    {
        var incomes = _incomeService.GetIncomesAsync();
        return Ok(incomes);
    }
    [HttpPost]
    public async Task<IActionResult> CreateIncome([FromBody] CreateIncomeDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var incomeId = await _incomeService.CreateIncome(dto);
            return CreatedAtAction(nameof(GetIncomes), new { id = incomeId }, dto);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateIncome(Guid id, [FromBody] UpdateIncomeDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _incomeService.UpdateIncome(id, dto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    [HttpDelete("{id}")]
    
    public async Task<IActionResult> DeleteIncome(Guid id)
    {
        try
        {
            await _incomeService.DeleteIncome(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
