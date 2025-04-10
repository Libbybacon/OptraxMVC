//using Microsoft.AspNetCore.Mvc.ModelBinding;

//namespace OptraxMVC.Models.ModelBinders
//{
//    public class PlantEventModelBinderProvider : IModelBinderProvider
//    {
//        //public IModelBinder? GetBinder(ModelBinderProviderContext context)
//        //{
//        //    ArgumentNullException.ThrowIfNull(context);

//        //    //if (context.Metadata.ModelType == typeof(PlantEvent))
//        //    //{
//        //    //    return new BinderTypeModelBinder(typeof(PlantEventModelBinder)); //Restrict to PlantEvent model type to avoid infinite loop
//        //    //}
//        //    return null;
//        //}
//    }

//    public class PlantEventModelBinder : IModelBinder
//    {
//        //public async Task BindModelAsync(ModelBindingContext mbContext)
//        //{
//        //    ArgumentNullException.ThrowIfNull(mbContext);
//        //    var eventTypeResult = mbContext.ValueProvider.GetValue($"{mbContext.ModelName}.EventType");
//        //    if (eventTypeResult == ValueProviderResult.None)
//        //    {
//        //        mbContext.Result = ModelBindingResult.Failed();
//        //        return;
//        //    }
//        //    var eventType = eventTypeResult.FirstValue;

//        //    // Instantiate concrete type
//        //    PlantEvent model;
//        //    switch (eventType)
//        //    {
//        //        case "Transfer":
//        //            model = new TransferEvent();
//        //            break;
//        //        case "Transplant":
//        //            model = new TransplantEvent();
//        //            break;
//        //        default:
//        //            mbContext.Result = ModelBindingResult.Failed();
//        //            return;
//        //    }

//        //    // New binding context for concrete type
//        //    var mmp = mbContext.HttpContext.RequestServices.GetService(typeof(IModelMetadataProvider)) as IModelMetadataProvider ?? throw new InvalidOperationException("IModelMetadataProvider service is not available.");
//        //    var metadata = mmp.GetMetadataForType(model.GetType());

//        //    var mbFactory = mbContext.HttpContext.RequestServices.GetService(typeof(IModelBinderFactory)) as IModelBinderFactory ?? throw new InvalidOperationException("IModelBinderFactory service is not available.");
//        //    var binder = mbFactory.CreateBinder(new ModelBinderFactoryContext
//        //    {
//        //        BindingInfo = null,
//        //        Metadata = metadata,
//        //        CacheToken = model.GetType()
//        //    });

//        //    var childBinder = DefaultModelBindingContext.CreateBindingContext(
//        //        mbContext.ActionContext,
//        //        mbContext.ValueProvider,
//        //        metadata,
//        //        bindingInfo: null,
//        //        modelName: mbContext.ModelName
//        //    );
//        //    childBinder.Model = model;

//        //    await binder.BindModelAsync(childBinder);
//        //    mbContext.Result = childBinder.Result;
//        //}
//    }
//}
