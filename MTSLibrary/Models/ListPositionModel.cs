namespace MTSLibrary.Models
{
    public class ListPositionModel
    {
        private CompModel _comp;
        private ToolModel _tool;
        public int Position { get; set; }
        public CompModel Comp {
            get => _comp;
            set {
                Tool = null;
                _comp = value;
            }
        }
        public ToolModel Tool {
            get => _tool;
            set {
                Comp = null;
                _tool = value;
            }
        }
        public int Quantity { get; set; }
    }
}