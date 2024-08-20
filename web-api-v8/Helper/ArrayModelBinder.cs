using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace web_api_v8.Helper
{
    public class ArrayModelBinder: IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();

            if (string.IsNullOrWhiteSpace(value)) { 
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }
         

        }

    }
}
