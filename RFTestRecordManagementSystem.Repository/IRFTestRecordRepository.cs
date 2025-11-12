using RFTestRecordManagementSystem.Domain;

namespace RFTestRecordManagementSystem.Repository
{
    public interface IRFTestRecordRepository
    {
        void InsertRecord(RFTestRecord record);

        void UpdateRecord(RFTestRecord record);

        //void DeleteRecord(int recordId);

        RFTestRecord? GetRecordById(int recordId);

        List<RFTestRecord> GetAllRecords();

        List<RFTestRecord> SearchRecords(string regulation, string radioTechnology);

        void SoftDeleteRecord(int RecordId);
        void ArchiveRecord(int RecordId);
    }
}
