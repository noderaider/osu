﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Linq;
using NUnit.Framework;
using osu.Game.Beatmaps.Legacy;
using osu.Game.Rulesets;

namespace osu.Game.Tests.Beatmaps
{
    /// <summary>
    /// Base class for tests of converting <see cref="LegacyMods"/> enumeration flags to ruleset mod instances.
    /// </summary>
    public abstract class LegacyModConversionTest
    {
        /// <summary>
        /// Creates the <see cref="Ruleset"/> whose legacy mod conversion is to be tested.
        /// </summary>
        /// <returns></returns>
        protected abstract Ruleset CreateRuleset();

        protected void Test(LegacyMods legacyMods, Type[] expectedMods)
        {
            var ruleset = CreateRuleset();
            var mods = ruleset.ConvertLegacyMods(legacyMods).ToList();
            Assert.AreEqual(expectedMods.Length, mods.Count);

            foreach (var modType in expectedMods)
            {
                Assert.IsNotNull(mods.SingleOrDefault(mod => mod.GetType() == modType));
            }
        }
    }
}
