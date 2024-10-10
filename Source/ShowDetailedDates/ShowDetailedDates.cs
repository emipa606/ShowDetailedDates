using System.Reflection;
using HarmonyLib;
using Verse;

namespace ShowDetailedDates;

[StaticConstructorOnStartup]
public static class ShowDetailedDates
{
    static ShowDetailedDates()
    {
        new Harmony("Mlie.ShowDetailedDates").PatchAll(Assembly.GetExecutingAssembly());
    }
}