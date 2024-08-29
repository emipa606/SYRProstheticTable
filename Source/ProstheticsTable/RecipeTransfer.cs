using System.Linq;
using Verse;

namespace ProstheticsTable;

[StaticConstructorOnStartup]
public static class RecipeTransfer
{
    static RecipeTransfer()
    {
        var enumerable = DefDatabase<RecipeDef>.AllDefs.Where(x =>
            !x.AllRecipeUsers.EnumerableNullOrEmpty() &&
            x.AllRecipeUsers.Any(ru =>
                ru == ProstheticsTableDefOf.TableMachining || ru == ProstheticsTableDefOf.FabricationBench) &&
            x.products.Any(p =>
                !p.thingDef.tradeTags.NullOrEmpty() &&
                (p.thingDef.isTechHediff || p.thingDef.tradeTags.Any(tt => tt == "TechHediff"))));
        if (enumerable.EnumerableNullOrEmpty())
        {
            return;
        }

        foreach (var item in enumerable)
        {
            if (item.recipeUsers.NullOrEmpty())
            {
                item.recipeUsers = [];
            }
            else
            {
                item.recipeUsers.Clear();
            }

            item.recipeUsers.Add(ProstheticsTableDefOf.TableSyrProsthetics);
            item.ResolveReferences();
        }
    }
}