using Dapper.FluentMap.Mapping;

namespace MTSLibrary.Models
{
    public class ParameterModel
    {
        public int Position { get; set; }
        public string ParameterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DataValueType DataValueType { get; set; }
        public double NumericValue { get; set; }
        public string TextValue { get; set; }
    }
    //internal class ParameterModelMap : EntityMap<ParameterModel>
    //{
    //    internal ParameterModelMap()
    //    {
    //        Map(p => p.ParameterId).ToColumn("Id");
    //    }
    //}
}