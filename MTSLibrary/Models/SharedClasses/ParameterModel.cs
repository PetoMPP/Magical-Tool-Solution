namespace MTSLibrary.Models.SharedClasses
{
    public class ParameterModel : IParameterModel
    {
        public int Position { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DataValueType DataValueType { get; set; }
        public double? NumericValue { get; set; }
        public string TextValue { get; set; }
        public string Value {
            get {
                return DataValueType switch
                {
                    DataValueType.Text => TextValue,
                    DataValueType.Numeric => NumericValue.ToString(),
                    _ => null,
                };
            }
        }
    }
}