using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestPlug
{
    public class ValidatePhonePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context =
                (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            if (!context.InputParameters.ContainsKey("Target"))
                throw new InvalidPluginExecutionException("No target found");

            var entity = context.InputParameters["Target"] as Entity;

            var telephone = entity.GetAttributeValue<string>("telephone1");

            if (string.IsNullOrEmpty(telephone))
                entity.Attributes["new_isvalidated"] = false;
            else
                entity.Attributes["new_isvalidated"] = true;

        }
    }
}
