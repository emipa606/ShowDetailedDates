using System;
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
        if (!Event.current.alt)
        {
            return GenDate.DateShortStringAt(absTicks, location);
        }

        var dayPercent = GenDate.DayPercent(absTicks, location.x);

        var hours = Math.Floor(dayPercent * 24);
        if (Prefs.TwelveHourClockMode)
        {
            hours = dayPercent < 0.6 ? hours : hours - 12;
        }

        var minutes = Math.Floor(dayPercent * 24 % 1 * 60);
        var seconds = Math.Floor(dayPercent * 24 % 1 * 60 % 1 * 60);
        var timeString = $"{hours,0:00}:{minutes,0:00}:{seconds,0:00}";

        if (!Prefs.TwelveHourClockMode)
        {
            return timeString;
        }

        timeString = $"{hours,0}:{minutes,0:00}:{seconds,0:00}";
        timeString += $" {(dayPercent < 0.5 ? "AM" : "PM")}";

        return timeString;
    }
}