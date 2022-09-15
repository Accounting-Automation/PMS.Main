﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Main.FrontEnd.Common
{
    public interface IStore
    {
        Action Reloaded { get; set; }

        Task Load();
        Task Reload();
    }
}