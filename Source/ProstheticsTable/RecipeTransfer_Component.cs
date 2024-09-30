using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Verse;

namespace ProstheticsTable;

[StaticConstructorOnStartup]
public class RecipeTransfer_Component : GameComponent
{
    public static readonly FieldInfo ThingDef_allRecipesCached =
        typeof(ThingDef).GetField("allRecipesCached", BindingFlags.Instance | BindingFlags.NonPublic);

    public RecipeTransfer_Component(Game game)
    {
    }

    public override void FinalizeInit()
    {
        base.FinalizeInit();
        if (!RecipeTransfer.VEPLoaded)
        {
            return;
        }

        var recipeDefs = DefDatabase<RecipeDef>.AllDefs.Where(x =>
            !x.AllRecipeUsers.EnumerableNullOrEmpty() &&
            x.AllRecipeUsers.Any(ru =>
                ru == ProstheticsTableDefOf.TableMachining || ru == ProstheticsTableDefOf.FabricationBench ||
                ru.defName == "VFE_TableMachiningLarge") &&
            x.products.Any(p =>
                !p.thingDef.tradeTags.NullOrEmpty() &&
                (p.thingDef.isTechHediff || p.thingDef.tradeTags.Any(tt => tt == "TechHediff"))));
        if (recipeDefs.EnumerableNullOrEmpty())
        {
            return;
        }

        foreach (var recipeDef in recipeDefs)
        {
            if (recipeDef.recipeUsers.NullOrEmpty())
            {
                recipeDef.recipeUsers = [];
            }
            else
            {
                foreach (var recipeUser in recipeDef.recipeUsers)
                {
                    recipeUser.recipes = recipeUser.recipes.Where(def => def != recipeDef).ToList();
                    var cachedRecipes = (List<RecipeDef>)ThingDef_allRecipesCached.GetValue(recipeUser);
                    if (cachedRecipes.Any())
                    {
                        ThingDef_allRecipesCached.SetValue(recipeUser,
                            cachedRecipes.Where(def => def != recipeDef).ToList());
                    }
                }

                recipeDef.recipeUsers.Clear();
            }

            recipeDef.recipeUsers.Add(ProstheticsTableDefOf.TableSyrProsthetics);
            recipeDef.ResolveReferences();
        }
    }
}