using System.Web.Optimization;

namespace ChildhoodMinistry.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/crudApp/crud.js").IncludeDirectory("~/scripts/crudApp/", "*.js", searchSubdirectories: true)); 
        }
    }
}