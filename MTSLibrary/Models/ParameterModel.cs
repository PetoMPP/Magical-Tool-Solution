using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MTSLibrary.Models
{
    public class ParameterModel
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
    public class ParameterModelIdComparer : IEqualityComparer<ParameterModel>
    {
        public bool Equals(ParameterModel x, ParameterModel y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x is null || y is null)
            {
                return false;
            }
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] ParameterModel obj) => obj.Id.GetHashCode();
    }
}