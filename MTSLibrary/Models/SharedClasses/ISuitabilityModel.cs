namespace MTSLibrary.Models.SharedClasses
{
    public interface ISuitabilityModel
    {
        int HSuitability { get; set; }
        int KSuitability { get; set; }
        int MSuitability { get; set; }
        int NSuitability { get; set; }
        int PSuitability { get; set; }
        int SSuitability { get; set; }
    }
}