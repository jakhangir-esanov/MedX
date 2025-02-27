﻿using MedX.Domain.Configurations;
using MedX.Service.DTOs.Appointments;
using MedX.Service.DTOs.MedicalRecords;

namespace MedX.Service.Interfaces;

public interface IMedicalRecordService
{
    Task<MedicalRecordResultDto> AddAsync(MedicalRecordCreationDto dto);
    Task<MedicalRecordResultDto> UpdateAsync(MedicalRecordUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<MedicalRecordResultDto> GetAsync(long id);
    Task<IEnumerable<MedicalRecordResultDto>> GetAllAsync(PaginationParams @params, string search = null);
    Task<IEnumerable<MedicalRecordResultDto>> GetAllByPatientIdAsync(long patientId);
    Task<IEnumerable<MedicalRecordResultDto>> GetAllByDoctorIdAsync(long doctorId, PaginationParams @params, string search = null);
}