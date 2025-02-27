﻿using MedX.WebApi.Models;
using MedX.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedX.Domain.Configurations;
using MedX.Service.DTOs.ServiceItems;

namespace MedX.WebApi.Controllers;

public class AffairItemController : BaseController
{
    private readonly IAffairItemService service;
    public AffairItemController(IAffairItemService service)
    {
        this.service = service;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync([FromBody] AffairItemCreationDto dto)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await service.AddAsync(dto)
        });
    }

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await service.DeleteAsync(id)
        });
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(AffairItemUpdateDto dto)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await service.UpdateAsync(dto)
        });
    }

    [HttpPut("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await service.GetAsync(id)
        });
    }

    [HttpPut("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await service.GetAllAsync(@params, search)
        });
    }

    [HttpPut("get-all-by-service/{serviceId:long}")]
    public async Task<IActionResult> GetAllByAffairIdAsync([FromQuery] long affairId, PaginationParams @params, [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await service.GetAllByAffairIdAsync(affairId, @params, search)
        });
    }

    [HttpPut("get-all-by-patient/{patientId:long}")]
    public async Task<IActionResult> GetAllByPatientIdAsync([FromQuery] long patientId, PaginationParams @params, [FromQuery] string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await service.GetAllByPatientIdAsync(patientId, @params, search)
        });
    }
}
