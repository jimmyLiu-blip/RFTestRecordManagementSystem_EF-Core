using RFTestRecordManagementSystem.Domain;

namespace RFTestRecordManagementSystem.Service
{
    public interface IRFTestRecordService
    {
        int AddRecord(string regulation, string radioTechnology, string band, decimal powerDbm, string result, DateTime testDate);
        void UpdateRecord(int recordId, string regulation, string radioTechnology, string band, decimal powerDbm, string result, DateTime testDate);
        //void DeleteRecord(int recordId);
        RFTestRecord? GetRecordById(int recordId);
        List<RFTestRecord> GetAllRecords();
        List<RFTestRecord> SearchRecords(string regulation, string radioTechnology);

        void SoftDeleteRecord(int RecordId);

        void ArchiveRecord(int RecordId);
    }
}
