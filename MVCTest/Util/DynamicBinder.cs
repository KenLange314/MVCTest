using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTest.Models;

namespace MVCTest.Util
{
    public class DynamicBinder:DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var typeValue = bindingContext.ValueProvider.GetValue("contextID");

            if (typeValue == null)
                return base.CreateModel(controllerContext, bindingContext, modelType);

            var contextID = typeValue.ConvertTo(typeof(string)) as string;

            if (contextID == "Test1")
            {
                var model = new Test1VM();
                model.FavoriteColor = new SelectListVM
                {
                    Items = new List<SelectListItem>
                        {
                            new SelectListItem{Value="Blue",Text="Blue"},
                            new SelectListItem{Value="Red",Text="Red"},
                            new SelectListItem{Value="Green",Text="Green"},
                        }
                };
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, typeof(Test1VM));
                return model;
            }
            else if (contextID == "Test2")
            {
                var model = new Test2VM();
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, typeof(Test2VM));
                return model;
            }
            else
                return base.CreateModel(controllerContext, bindingContext, modelType);

        }
    }
}