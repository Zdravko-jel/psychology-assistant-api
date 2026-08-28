using PsychologyAssistant.DTOs.Report;
using PsychologyAssistant.Interfaces;
using PsychologyAssistant.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace PsychologyAssistant.Service
{
    public class PDFCreator : IPdfCreator
    {
        private readonly IChartService _chartService;

        public PDFCreator(IChartService chartService)
        {
            _chartService = chartService;
        }

        public async Task<MonthlyReport> CreatePdf(User user, List<Patient> patients, List<PatientFile> diagnoses, List<Session> sessions, List<PatientFile> closedFiles)
        {
            var date = DateTime.Now.AddMonths(-1);
            var month = date.Month;
            var year = date.Year;

            var daysInMonth = DateTime.DaysInMonth(year, month);

            var patientData = patients.GroupBy(x => x.CreatedAt.Date).Select(x => new { Date = x.Key, Count = x.Count() }).OrderBy(x => x.Date).ToList();
            var patientPerDay = Enumerable
                .Range(1, daysInMonth)
                .Select(day => new DailyStatisticDto
                {
                    Date = new DateTime(year, month, day),
                    Count = patientData.FirstOrDefault(x => x.Date == new DateTime(year, month, day))?.Count ?? 0
                }).ToList();
            var patientImage = _chartService.CreatePatientsPerDayChart(patientPerDay);

            var diagnosesData = diagnoses.GroupBy(x => x.DiagnosisAdded).Select(x => new { Date = x.Key, Count = x.Count() }).OrderBy(x => x.Date).ToList();
            var diagnosesPerDay = Enumerable
                .Range(1, daysInMonth)
                .Select(day => new DailyStatisticDto
                {
                    Date = new DateTime(year, month, day),
                    Count = diagnosesData.FirstOrDefault(x => x.Date == new DateTime(year, month, day))?.Count ?? 0
                }).ToList();
            var diagnosesImage = _chartService.CreateDiagnosesPerDayChart(diagnosesPerDay);

            var sessionsData = sessions.GroupBy(x => x.BeginDateTime.Date).Select(x => new { Date = x.Key, Count = x.Count() }).OrderBy(x => x.Date).ToList();
            var sessionsPerDay = Enumerable
                .Range(1, daysInMonth)
                .Select(day => new DailyStatisticDto
                {
                    Date = new DateTime(year, month, day),
                    Count = sessionsData.FirstOrDefault(x => x.Date == new DateTime(year, month, day))?.Count ?? 0
                }).ToList();
            var sessionsImage = _chartService.CreateSessionsPerDayChart(sessionsPerDay);

            var closedFilesData = closedFiles.GroupBy(x => x.ClosedOn).Select(x => new { Date = x.Key, Count = x.Count() }).OrderBy(x => x.Date).ToList();
            var closedFilesPerDay = Enumerable
                .Range(1, daysInMonth)
                .Select(day => new DailyStatisticDto
                {
                    Date = new DateTime(year, month, day),
                    Count = closedFilesData.FirstOrDefault(x => x.Date == new DateTime(year, month, day))?.Count ?? 0
                }).ToList();
            var closedFilesImage = _chartService.CreateClosedFilesPerDayChart(closedFilesPerDay);

            var document = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);

                    page.Header().Text($"Monthly Report - {year}/{month:D2}").FontSize(24).Bold();

                    page.Content()
                        .Column(column =>
                        {
                            column.Item().Text($"Registered patients: {patients.Count}");
                            column.Item().Text($"Diagnoses assigned: {diagnoses.Count}");
                            column.Item().Text($"Sessions this month: {sessions.Count}");
                            column.Item().Text($"Closed files: {closedFiles.Count}");

                            column.Item()
                                .Text("Patients Registered Per Day")
                                .FontSize(16)
                                .Bold();

                            column.Item()
                                .Image(patientImage);

                            column.Item()
                                .Text("Diagnoses Assigned Per Day")
                                .FontSize(16)
                                .Bold();

                            column.Item()
                                .Image(diagnosesImage);

                            column.Item()
                                .Text("Sessions Per Day")
                                .FontSize(16)
                                .Bold();

                            column.Item()
                                .Image(sessionsImage);

                            column.Item()
                                .Text("Closed Files Per Day")
                                .FontSize(16)
                                .Bold();

                            column.Item()
                                .Image(closedFilesImage);
                        });

                    page.Footer().AlignCenter().Text(x => {
                        x.Span("Psychology Assistant Page ");
                        x.CurrentPageNumber();
                    });
                });
            });

            byte[] pdf = document.GeneratePdf();

            var reportDirectory = Path.Combine(
                Directory.GetCurrentDirectory(),
                "uploads",
                "reports"
            );

            Directory.CreateDirectory(reportDirectory);

            var fileName = $"report-{year}-{month:D2}.pdf";
            var filePath = Path.Combine(reportDirectory, fileName);

            await File.WriteAllBytesAsync(filePath, pdf);

            return new MonthlyReport { 
                storedFileName = filePath,
                FileName = fileName,
                UserId = user.Id
            };
        }
    }
}
