using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.PatientFile;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Mappers;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Repositories
{
    public class PatientFileRepo : IPatientFileRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _manager;

        public PatientFileRepo(ApplicationDbContext context, UserManager<User> manager)
        {
            _context = context;
            _manager = manager;
        }

        public async Task<bool> AddDiagnosisToFile(int id, UpdatePatientFileDto patientFileDto)
        {
            var file = await _context.PatientFiles.FindAsync(id);
            if (file == null)
                return false;

            if (patientFileDto.DiagnosisId == -1)
                return false;

            var diagnosis = await _context.Diagnoses.FindAsync(patientFileDto.DiagnosisId);
            if (diagnosis == null)
                return false;

            file.DiagnosisId = (int)patientFileDto.DiagnosisId;
            file.Diagnosis = diagnosis;
            file.DiagnosisAdded = DateTime.Now;
            _context.PatientFiles.Update(file);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddSessionToFile(int id, UpdatePatientFileDto patientFileDto)
        {
            var file = await _context.PatientFiles.FindAsync(id);
            if (file == null)
                return false;

            if (patientFileDto.SessionId == -1)
                return false;

            var session = await _context.Sessions.FindAsync(patientFileDto.SessionId);
            if (session == null)
                return false;

            file.Sessions.Add(session);
            file.MoodLevels.Add((int)session.MoodLevel);
            file.AnxietyLevels.Add((int)session.AnxietyLevel);
            file.DepressionLevels.Add((int)session.DepressionLevel);
            file.SleepQualityLevels.Add((int)session.SleepQualityLevel);
            file.StressLevels.Add((int)session.StressLevel);
            _context.PatientFiles.Update(file);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddSymptomToFile(int id, UpdatePatientFileDto patientFileDto)
        {
            var file = await _context.PatientFiles.FindAsync(id);
            if (file == null)
                return false;

            if (patientFileDto.SymptomId == -1)
                return false;

            var symptom = await _context.Symptoms.FindAsync(patientFileDto.SymptomId);
            if (symptom == null)
                return false;

            file.Symptoms.Add(symptom);
            _context.PatientFiles.Update(file);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeDiagnosisToFile(int id, UpdatePatientFileDto patientFileDto)
        {
            var file = await _context.PatientFiles.FindAsync(id);
            if (file == null)
                return false;

            if (patientFileDto.DiagnosisId == -1)
                return false;

            var diagnosis = await _context.Diagnoses.FindAsync(patientFileDto.DiagnosisId);
            if (diagnosis == null)
                return false;

            file.DiagnosisId = (int)patientFileDto.DiagnosisId;
            file.Diagnosis = diagnosis;
            file.DiagnosisAdded = DateTime.Now;
            _context.PatientFiles.Update(file);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CloseFileAndSummary(int id, UpdatePatientFileDto patientFileDto)
        {
            var file = await _context.PatientFiles.FindAsync(id);
            if (file == null)
                return false;

            if (string.IsNullOrEmpty(patientFileDto.Summary))
                return false;

            file.Summary = patientFileDto.Summary;
            file.Status = Enums.PatientFileStatus.Closed;
            file.ClosedOn = DateTime.Now;
            _context.PatientFiles.Update(file);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PatientFileDto> Create(CreatePatientFileDto createPatientFile)
        {
            var user = await _manager.FindByIdAsync(createPatientFile.UserId);
            if (user == null)
                return null;
            var patient = await _context.Patients.FindAsync(createPatientFile.PatientId);
            if (patient == null)
                return null;

            var patientFile = new PatientFile {
                PatientId = createPatientFile.PatientId,
                Patient = patient,
                User = user,
                CreatedAt = DateTime.Now,
                Summary = "empty",
                DiagnosisId = -1,
                Diagnosis = null,
                DiagnosisAdded = null,
                Status = Enums.PatientFileStatus.Open,
                ClosedOn = null,
                Sessions = new List<Session>(),
                Symptoms = new List<Symptom>(),
                MoodLevels = new List<int>(),
                AnxietyLevels = new List<int>(),
                DepressionLevels = new List<int>(),
                SleepQualityLevels = new List<int>(),
                StressLevels = new List<int>()
            };

            await _context.PatientFiles.AddAsync(patientFile);
            await _context.SaveChangesAsync();
            return patientFile.toFileDto();
        }

        public async Task<bool> Delete(int id)
        {
            var file = await _context.PatientFiles.FindAsync(id);
            if (file == null)
                return false;

            _context.PatientFiles.Remove(file);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PatientFileDto>> GetAll()
        {
            return await _context.PatientFiles.Select(x => x.toFileDto()).ToListAsync();
        }

        public async Task<List<PatientFileDto>> GetAllByPatient(int patientId)
        {
            return await _context.PatientFiles.Where(x => x.PatientId == patientId).Select(x => x.toFileDto()).ToListAsync();
        }

        public async Task<List<PatientFileDto>> GetAllByUser(string userId)
        {
            return await _context.PatientFiles.Where(x => x.User.Id == userId).Select(x => x.toFileDto()).ToListAsync();
        }

        public async Task<PatientFileDto> GetById(int id)
        {
            var file = await _context.PatientFiles.FindAsync(id);
            if (file == null)
            {
                return null;
            }
            return file.toFileDto();
        }

        public async Task<bool> RemoveSymptomToFile(int id, UpdatePatientFileDto patientFileDto)
        {
            var file = await _context.PatientFiles.FindAsync(id);
            if (file == null)
                return false;

            if (patientFileDto.SymptomId == -1)
                return false;

            var symptom = await _context.Symptoms.FindAsync(patientFileDto.SymptomId);
            if (symptom == null)
                return false;

            file.Symptoms.Remove(symptom);
            _context.PatientFiles.Update(file);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
