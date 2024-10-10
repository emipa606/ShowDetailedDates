using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace ShowDetailedDates;

[HarmonyPatch(typeof(MainTabWindow_History), "DoArchivableRow")]
public static class MainTabWindow_History_DoArchivableRow
{
    // A transpiler that replaces any call to DateShortStringAt with ConditionalDateString
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = instructions.ToList();
        for (var i = 0; i < codes.Count - 1; i++)
        {
            if (codes[i].opcode == OpCodes.Call && codes[i].operand ==
                AccessTools.Method(typeof(GenDate), nameof(GenDate.DateShortStringAt)))
            {
                codes[i].operand = AccessTools.Method(typeof(MainTabWindow_History_DoArchivableRow),
                    nameof(ConditionalDateString));
            }
        }

        return codes.AsEnumerable();
    }

    private static string ConditionalDateString(long absTicks, Vector2 location)
    {
        // If ALT-key is pressed, return custom date-string, else call DateShortStringAt
        return Event.current.alt
            ? "SDD.DateWithHour".Translate(GenDate.HourInteger(absTicks, location.x) + "LetterHour".Translate(),
                GenDate.Quadrum(absTicks, location.x).LabelShort(), GenDate.DayOfSeason(absTicks, location.x) + 1)
            : GenDate.DateShortStringAt(absTicks, location);
    }
}