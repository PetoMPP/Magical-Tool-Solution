namespace MTSLibrary.Models
{
    public class ToolComponentModel
    {
        public bool IsKey { get; set; }
        public int Position { get; set; }
        public CompModel Comp { get; set; }
        public int Quantity { get; set; }
    }
}