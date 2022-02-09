namespace MTSLibrary.Models
{
    public class BasicToolClassModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public static explicit operator ToolClassModel(BasicToolClassModel model) => new() { Id = model.Id, Name = model.Name };
    }
}
