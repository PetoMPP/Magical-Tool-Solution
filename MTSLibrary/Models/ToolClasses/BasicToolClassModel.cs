namespace MTSLibrary.Models.ToolClasses
{
    public class BasicToolClassModel : IBasicToolClassModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public static explicit operator ToolClassModel(BasicToolClassModel model) => new() { Id = model.Id, Name = model.Name };
    }
}
