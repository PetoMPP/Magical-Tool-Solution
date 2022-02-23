using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSLibrary.Connections
{
    public interface IMachineData
    {
        string ValidateMachine(string machineId, string machineGroupId);
        string ValidateMachineInterfaceName(string machineInterface);
    }
}
