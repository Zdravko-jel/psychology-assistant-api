using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.Diagnosis;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Mappers;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Repositories
{
    public class DiagnosisRepo : IDiagnosisRepo
    {
        private readonly ApplicationDbContext _context;

        public DiagnosisRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddSymptomAsync(int diagnosisId, int symptomId)
        {
            var diagnosis = await _context.Diagnoses.Include(d => d.Symptoms).FirstOrDefaultAsync(d => d.Id == diagnosisId);
            if (diagnosis == null)
                return false;

            var symptom = await _context.Symptoms.FindAsync(symptomId);
            if (symptom == null)
                return false;

            if (diagnosis.Symptoms == null)
            {
                diagnosis.Symptoms = new List<Symptom>();
            }

            diagnosis.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<DiagnosisDto> CreateAsync(CreateDiagnosisDto diagnosis)
        {
            var diagnosisEntity = new Diagnosis
            {
                Name = diagnosis.Name,
                Symptoms = new List<Symptom>()
            };
            _context.Diagnoses.Add(diagnosisEntity);
            await _context.SaveChangesAsync();
            return diagnosisEntity.ToDTO();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if (diagnosis == null)
                return false;

            _context.Diagnoses.Remove(diagnosis);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DiagnosisDto>> GetAllAsync()
        {
            return await _context.Diagnoses.Include(d => d.Symptoms).Select(x => x.ToDTO()).ToListAsync();
        }

        public async Task<DiagnosisDto> GetOneAsync(int id)
        {
            var diagnosis = await _context.Diagnoses
                .Include(d => d.Symptoms)
                .FirstOrDefaultAsync(d => d.Id == id);
            return diagnosis?.ToDTO();
        }

        public async Task<bool> RemoveSymptomAsync(int diagnosisId, int symptomId)
        {
            var diagnosis = await _context.Diagnoses.Include(d => d.Symptoms).FirstOrDefaultAsync(d => d.Id == diagnosisId);
            if (diagnosis == null)
                return false;

            var symptom = diagnosis.Symptoms?.FirstOrDefault(s => s.Id == symptomId);
            if (symptom == null)
                return false;

            diagnosis.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateDiagnosisDto diagnosis)
        {
            var diagnosisEntity = await _context.Diagnoses.FindAsync(id);
            if (diagnosisEntity == null)
                return false;

            diagnosisEntity.Name = diagnosis.Name;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
