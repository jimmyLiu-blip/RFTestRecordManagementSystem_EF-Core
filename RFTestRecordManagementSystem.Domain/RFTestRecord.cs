namespace RFTestRecordManagementSystem.Domain
{
    public class RFTestRecord
    {
        public int RecordId { get; set; }

        public string? Regulation { get; set; }

        public string? RadioTechnology { get; set; }

        public string? Band { get; set; }

        public decimal PowerDbm { get; set; }

        public string? Result { get; set; }

        public DateTime TestDate { get; set; }

        public RFTestRecord() { }

        public RFTestRecord(string regulation, string radioTechnology, string band, decimal powerDbm, string result, DateTime testDate)
        {
            Regulation = regulation;
            RadioTechnology = radioTechnology;
            Band = band;
            PowerDbm = powerDbm;
            Result = result;
            TestDate = testDate;
        }

    }
}



