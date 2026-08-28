using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PsychologyAssistant.Data;
using PsychologyAssistant.DTOs.Report;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Mappers;
using PsychologyAssistant.Models;

namespace PsychologyAssistant.Repositories
{
    public class ReportRepo : IReportRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _manager;
        private readonly IPdfCreator _pdfCreator;

        public ReportRepo(ApplicationDbContext context, UserManager<User> manager, IPdfCreator pdfCreator)
        {
            _context = context;
            _manager = manager;
            _pdfCreator = pdfCreator;   
        }

        public async Task<ReportDto> Create(CreateReportDto reportDto)
        {
            var user = await _manager.FindByIdAsync(reportDto.UserId);
            if (user == null)
                return null;

            var date = DateTime.Now;
            if (date.Month == 1)
            {
                date.AddMonths(-1);
                date.AddYears(-1);
            }
            else
            {
                date.AddMonths(-1);
            }

            var patients = await _context.Patients.Where(x => x.CreatedAt >= date).ToListAsync();
            var diagnoses = await _context.PatientFiles.Where(x => x.DiagnosisAdded >= date).ToListAsync();
            var closedFiles = await _context.PatientFiles.Where(x => x.ClosedOn >= date).ToListAsync();
            var sessions = await _context.Sessions.Where(x => x.BeginDateTime >= date).ToListAsync();

            var report = await _pdfCreator.CreatePdf(user, patients, diagnoses, sessions, closedFiles);

            if (report == null)
                return null;

            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();

            return report.ToReportDto();
        }

        public async Task<List<ReportDto>> GetAll()
        {
            return await _context.Reports.Select(x => x.ToReportDto()).ToListAsync();
        }

        public async Task<List<ReportDto>> GetAllForUser(string userId)
        {
            return await _context.Reports.Where(x=>x.UserId == userId).Select(x => x.ToReportDto()).ToListAsync();
        }

        public async Task<MonthlyReport> GetById(int id)
        {
            var document = await _context.Reports.FirstOrDefaultAsync(x => x.Id == id);
            if (document == null)
                return null;

            return document;
        }
    }
}
