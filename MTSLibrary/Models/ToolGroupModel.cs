namespace MTSLibrary.Models
{
    public class ToolGroupModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ToolClassId { get; set; }
        public bool SuitabilityEnabled { get; set; }
        public bool MachineInterfaceEnabled { get; set; }
        public bool InsertsEnabled { get; set; }
        public bool HoldingOtherComponentsEnabled { get; set; }
        public bool EnabledInComps { get; set; }
        public bool EnabledInTools { get; set; }
        public string DisplayName { get { return $"{Id} - {Name}"; } }
    }
}