using DirectoryComparerProject.Infrastructure;
using System.Collections.Generic;

namespace DirectoryComparerProject.Processes
{
    internal interface IOutput<T>
    {
        T Print(List<DirectoryProcess> directoryProcesses);
    }
}
