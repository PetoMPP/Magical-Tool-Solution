namespace MTSLibrary.Models
{
    public class BasicToolGroupModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public static explicit operator ToolGroupModel(BasicToolGroupModel model) => new() { Id = model.Id, Name = model.Name };
    }
}
