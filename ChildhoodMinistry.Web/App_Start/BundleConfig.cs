using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ChildhoodMinistry.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/crudApp").Include(
                "~/scripts/crudApp/Factory.js",
                //"~/scripts/crudApp/Module.js",
                "~/scripts/crudApp/Controllers/ChildController.js",
                "~/scripts/crudApp/Controllers/ChildhoodController.js",
                "~/scripts/crudApp/Services/ChildService.js",
                "~/scripts/crudApp/Services/ChildhoodService.js",
                "~/scripts/crudApp/Directives/Directive.js"
                ));
        }
    }
}