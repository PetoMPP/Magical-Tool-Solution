namespace MTSLibrary.Models.SharedClasses
{
    public interface IParameterModel
    {
        DataValueType DataValueType { get; set; }
        string Description { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        double? NumericValue { get; set; }
        int Position { get; set; }
        string TextValue { get; set; }
        string Value { get; }
    }
}