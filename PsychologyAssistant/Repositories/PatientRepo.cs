using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.Patient;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Mappers;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Repositories
{
    public class PatientRepo : IPatientRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public PatientRepo(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<PatientDto> Create(CreatePatientDto patientDto)
        {
            var patient = new Patient
            {
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                BirthDate = patientDto.BirthDate,
                IdNumber = patientDto.IdNumber,
                EmailAddress = patientDto.EmailAddress,
                Gender = patientDto.Gender,
                PhoneNumber = patientDto.PhoneNumber,
                Address = patientDto.Address,
                EmContactPhone = patientDto.EmContactPhone,
                EmergencyContact = patientDto.EmergencyContact
            };
            var user = await _userManager.FindByIdAsync(patientDto.CreatorId);
            patient.Creator = user;
            patient.CreatedAt = DateTime.Now;
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient.toDto();
        }

        public async Task<List<PatientDto>> GetAll()
        {
            return await _context.Patients.Include(x=>x.Creator).Select(x=>x.toDto()).ToListAsync();
        }

        public async Task<List<PatientDto>> GetAllForUser(string userId)
        {
            return await _context.Patients.Include(x => x.Creator).Where(x => x.Creator.Id == userId).Select(x => x.toDto()).ToListAsync();
        }

        public async Task<PatientDto> GetById(int id)
        {
            var patient = await _context.Patients.Include(x => x.Creator).FirstOrDefaultAsync(x => x.Id == id);
            if(patient == null)
                return null;
            return patient.toDto();
        }

        public async Task<PatientDto> Update(int id, UpdatePatientDto patientDto)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patient == null)
                return null;

            patient.FirstName = patientDto.FirstName;
            patient.LastName = patientDto.LastName;
            patient.BirthDate = patientDto.BirthDate;
            patient.EmailAddress = patientDto.EmailAddress;
            patient.Gender = patientDto.Gender;
            patient.PhoneNumber = patientDto.PhoneNumber;
            patient.Address = patientDto.Address;
            patient.EmergencyContact = patientDto.EmergencyContact;
            patient.EmContactPhone = patientDto.EmContactPhone;

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

            return patient.toDto();
        }
    }
}
