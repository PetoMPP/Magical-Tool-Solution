namespace MTSLibrary.Models.ToolGroups
{
    public interface IToolGroupModel : IBasicToolGroupModel
    {
        string DisplayName { get; }
        bool EnabledInComps { get; set; }
        bool EnabledInTools { get; set; }
        bool HoldingOtherComponentsEnabled { get; set; }
        bool InsertsEnabled { get; set; }
        bool MachineInterfaceEnabled { get; set; }
        bool SuitabilityEnabled { get; set; }
        string ToolClassId { get; set; }
    }
}