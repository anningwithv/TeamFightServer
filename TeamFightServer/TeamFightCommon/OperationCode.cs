﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamFightCommon
{
    public enum OperationCode : byte
    {
        Login,
        GetServer,
        Register,
        Role,
        TaskDB,
        InventoryItemDB,
        SkillDB,
        Battle,
        Enemy,
        Boss
    }
}