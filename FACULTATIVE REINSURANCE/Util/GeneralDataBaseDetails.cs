namespace FACULTATIVE_REINSURANCE.Util
{
    internal class GeneralDataBaseDetails
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string ColumnName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    internal class ReInsuranceDetails : GeneralDataBaseDetails
    {
    }

    internal class RiskInfoDetails : GeneralDataBaseDetails
    {
    }

    internal class CoverageDeatils : GeneralDataBaseDetails
    {
        public string DisplayName { get; set; }
        public int DefaultValue { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int InputValue { get; set; }

        public string WarningMessage
        {
            get { return " * Range bw " + this.MinValue + " to " + this.MaxValue; }
        }
    }

    internal class ExtenstionDetails : GeneralDataBaseDetails
    {
        public string DisplayName { get; set; }
        public string DefaultValue { get; set; }
        public string InputValue { get; set; }
    }

    internal class LawJurisdiction : GeneralDataBaseDetails
    {
    }

    internal class AttachmentDetails
    {
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public long fileSizeInBytes { get; set; }
        public System.IO.DirectoryInfo FileDirectory { get; set; }
    }
}