﻿using System;
using ZenProgramming.Chakra.Core.Data;
using ZenProgramming.Chakra.Core.Data.Repositories;
using ZenProgramming.Chakra.Core.Data.Repositories.Helpers;
using ZenProgramming.Chakra.Core.Mocks.Data.Repositories;
using ZenProgramming.Chakra.Core.Mocks.Scenarios;
using ZenProgramming.Chakra.Core.Mocks.Scenarios.Options;

namespace ZenProgramming.Chakra.Core.Mocks.Data
{
    /// <summary>
    /// Simplified implementation of data session on "Mock" engine
    /// </summary>
    /// <typeparam name="TScenarioInstance">Type of scenario instance</typeparam>
    public class MockDataSession<TScenarioInstance> : MockDataSession<TScenarioInstance, ScopedScenarioOption<TScenarioInstance>>
        where TScenarioInstance : class, IScenario, new()
    { 
    }
}
