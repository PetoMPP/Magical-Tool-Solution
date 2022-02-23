namespace MTSLibrary.Models.SharedClasses
{
    public class SuitabilityModel : ISuitabilityModel
    {
        public int PSuitability { get; set; }
        public int MSuitability { get; set; }
        public int KSuitability { get; set; }
        public int NSuitability { get; set; }
        public int SSuitability { get; set; }
        public int HSuitability { get; set; }
    }
}