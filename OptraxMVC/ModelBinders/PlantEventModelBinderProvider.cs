using Microsoft.AspNetCore.Mvc.ModelBinding;
using OptraxDAL.Models.Grow; 

namespace OptraxMVC.ModelBinders
{
    public class PlantEventModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(PlantEvent) ||
                context.Metadata.ModelType.IsSubclassOf(typeof(PlantEvent)))
            {
                var modelBinderFactory = context.Services.GetRequiredService<IModelBinderFactory>();
                var metadataProvider = context.Services.GetRequiredService<IModelMetadataProvider>();

                return new PlantEventModelBinder(modelBinderFactory, metadataProvider);
            }

            return null;
        }
    }
}
