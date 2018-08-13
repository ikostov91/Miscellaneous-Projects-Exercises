using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Core;

namespace DungeonsAndCodeWizards.Models.Interfaces
{
    public interface IEngine
    {
        void Run(DungeonMaster dungeonMaster);
    }
}
