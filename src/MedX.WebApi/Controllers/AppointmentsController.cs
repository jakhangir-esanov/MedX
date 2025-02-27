﻿using MedX.Domain.Configurations;
using MedX.Service.DTOs.Appointments;
using MedX.Service.Interfaces;
using MedX.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedX.WebApi.Controllers;

public class AppointmentsController : BaseController
{
    private readonly IAppointmentService appointmentService;
    public AppointmentsController(IAppointmentService appointmentService)
    {
        this.appointmentService = appointmentService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync([FromForm] AppointmentCreationDto dto)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await appointmentService.AddAsync(dto)
        });
    }

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await appointmentService.DeleteAsync(id)
        });
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync([FromForm] AppointmentUpdateDto dto)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await appointmentService.UpdateAsync(dto)
        });
    }

    [HttpPut("get/{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await appointmentService.GetAsync(id)
        });
    }

    [HttpPut("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params, string search)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await appointmentService.GetAllAsync(@params, search)
        });
    }

    [HttpPut("get-all-by-patient/{patientId:long}")]
    public async Task<IActionResult> GetAllByPatientIdAsync(long patientId)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await appointmentService.GetAllByPatientIdAsync(patientId)
        });
    }

    [HttpPut("get-all-by-doctor/{doctorId:long}")]
    public async Task<IActionResult> GetAllByDoctorIdAsync(long doctorId, PaginationParams @params, string search = null)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "OK",
            Data = await appointmentService.GetAllByDoctorIdAsync(doctorId, @params, search)
        });
    }
}
