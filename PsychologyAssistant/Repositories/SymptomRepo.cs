using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.Symptom;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Repositories
{
    public class SymptomRepo : ISymptomRepo
    {
        private readonly ApplicationDbContext _context;

        public SymptomRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Symptom> CreateAsync(Symptom symptom)
        {
            await this._context.Symptoms.AddAsync(symptom);
            await this._context.SaveChangesAsync();
            return symptom;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var symptom = await this._context.Symptoms.FindAsync(id);
            if (symptom == null)
            {
                return false;
            }
            this._context.Symptoms.Remove(symptom);
            await this._context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Symptom>> GetAllAsync()
        {
            return await this._context.Symptoms.ToListAsync();
        }

        public async Task<Symptom> GetOneAsync(int id)
        {
            return await this._context.Symptoms.FindAsync(id);
        }

        public async Task<Symptom> UpdateAsync(int id, UpdateSymptomDto symptomDto)
        {
            var symptom = await this._context.Symptoms.FindAsync(id);
            if (symptom == null)
            {
                return null;
            }
            symptom.Name = symptomDto.Name;
            await this._context.SaveChangesAsync();
            return symptom;
        }
    }
}
