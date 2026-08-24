using PsychologyAssistant.DTOs.PatientFile;

namespace PsychologyAssistant.Interfaces
{
    public interface IPatientFileRepo
    {
        Task<List<PatientFileDto>> GetAll();
        Task<List<PatientFileDto>> GetAllByPatient(int patientId);
        Task<List<PatientFileDto>> GetAllByUser(string userId);
        Task<PatientFileDto> GetById(int id);
        Task<PatientFileDto> Create(CreatePatientFileDto createPatientFile);
        Task<bool> Delete(int id);
        Task<bool> AddSymptomToFile(int id, UpdatePatientFileDto patientFileDto);
        Task<bool> RemoveSymptomToFile(int id, UpdatePatientFileDto patientFileDto);
        Task<bool> AddDiagnosisToFile(int id, UpdatePatientFileDto patientFileDto);
        Task<bool> ChangeDiagnosisToFile(int id, UpdatePatientFileDto patientFileDto);
        Task<bool> AddSessionToFile(int id, UpdatePatientFileDto patientFileDto);
        Task<bool> CloseFileAndSummary(int id, UpdatePatientFileDto patientFileDto);
    }
}
