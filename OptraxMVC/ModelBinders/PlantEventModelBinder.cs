using Microsoft.AspNetCore.Mvc.ModelBinding;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;

namespace OptraxMVC.ModelBinders
{
    public class PlantEventModelBinder(IModelBinderFactory binderFactory, IModelMetadataProvider metadataProvider) : IModelBinder
    {
        private readonly IModelBinderFactory _binderFactory = binderFactory;
        private readonly IModelMetadataProvider _metadataProvider = metadataProvider;

        public async Task BindModelAsync(ModelBindingContext modelBC)
        {
            ArgumentNullException.ThrowIfNull(modelBC);

            string modelName = modelBC.ModelName; // PlantEvents[0]
            string eventTypeKey = $"{modelName}.EventType";

            var eventTypeValue = modelBC.ValueProvider.GetValue(eventTypeKey).FirstValue;

            if (string.IsNullOrEmpty(eventTypeValue))
            {
                modelBC.ModelState.TryAddModelError(eventTypeKey, "EventType is required.");
                return;
            }

            // Instantiate subclass
            PlantEvent? model = eventTypeValue switch
            {
                "Transfer" => new TransferEvent { Transfer = new InventoryTransfer() },
                "Treatment" => new TreatmentEvent { TreatmentType = "" },
                "Growth" => new GrowthEvent { NewPhase = "" },
                "Prune" => new PruneEvent { PruneType = "" },
                _ => null
            };

            if (model == null)
            {
                modelBC.ModelState.TryAddModelError(eventTypeKey, "Invalid event type.");
                return;
            }

            modelBC.Model = model;
            modelBC.Result = ModelBindingResult.Success(model);

            // If TransferEvent - bind nested InventoryTransfer
            if (model is TransferEvent transferEvent)
            {
                string transferPrefix = $"{modelName}.Transfer"; // PlantEvents[0].Transfer

                var metadata = _metadataProvider.GetMetadataForType(typeof(InventoryTransfer));
                var binder = _binderFactory.CreateBinder(new ModelBinderFactoryContext
                {
                    Metadata = metadata,
                    CacheToken = metadata
                });

                var transferBC = DefaultModelBindingContext.CreateBindingContext(
                    modelBC.ActionContext,
                    modelBC.ValueProvider,
                    metadata,
                    bindingInfo: null,
                    modelName: transferPrefix
                );

                await binder.BindModelAsync(transferBC);

                if (transferBC.Result.IsModelSet)
                {
                    transferEvent.Transfer = (InventoryTransfer)transferBC.Result.Model!;
                }
            }
        }
    }
}
