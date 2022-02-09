namespace MTSLibrary.Models
{
    public class CompUsageModel
    {
        public ToolModel ParentTool { get; set; }
        public CompModel Comp { get; set; }
        public int Quantity { get; set; }
    }
}
