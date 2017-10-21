namespace SimpleMvc.Framework.Routers
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Reflection;
   using Attributes.Methods;
   using Contracts;
   using WebServer.Contracts.Contracts;
   using WebServer.Contracts.Enums;
   using WebServer.Contracts.Exceptions;
   using WebServer.Contracts.Http.Contracts;
   using WebServer.Contracts.Http.Response;

   public class ControllerRouter : IHandleable
   {

      private IDictionary<string, string> getParams;
      private IDictionary<string, string> postParams;
      private string requestMethod;
      private object controllerInstance;
      private string controllerName;
      private string actionName;
      private object[] methodParameters;

      public IHttpResponse Handle(IHttpRequest request)
      {
         this.getParams = new Dictionary<string, string>(request.UrlParameters);
         this.postParams = new Dictionary<string, string>(request.FormData);
         this.requestMethod = request.Method.ToString().ToUpper();
         this.PrepareControllerAndAcionNames(request);

         var methodInfo = this.GetActionForExecution();

         if (methodInfo == null)
         {
            return new NotFoundResponse();
         }

         this.PrepareMethodParameters(methodInfo);

         var actionResult = (IInvocable) methodInfo.Invoke(this.GetControllerInstance(), this.methodParameters);

         var content = actionResult.Invoke();
         return  new ContentResponse(HttpStatusCode.Ok,content);
      }

      private void PrepareControllerAndAcionNames(IHttpRequest request)
      {
         var pathParts = request.Path.Split(new[] { '/', '?' }, StringSplitOptions.RemoveEmptyEntries);

         if (pathParts.Length < 2)
         {

            BadRequestException.ThrowFromInvalidRequest();
         }

         this.controllerName = $"{Capitalize(pathParts[0])}{MvcContext.Get.ControllerSuffix}";
         this.actionName = $"{Capitalize(pathParts[1])}";

      }

      public static string Capitalize(string input)
      {
         var firstLetter = char.ToUpper(input.First());
         var rest = input.Substring(1);
         return $"{firstLetter}{rest}";
      }

      private MethodInfo GetActionForExecution()
      {

         foreach (var method in this.GetSuitableMethods())
         {

            var httpMethodAttributes = method
               .GetCustomAttributes()
               .Where(a => a is HttpMethodAttribute)
               .Cast<HttpMethodAttribute>();


            if (!httpMethodAttributes.Any() && this.requestMethod == "GET")
            {
               return method;
            }

            foreach (var httpMethodAttribute in httpMethodAttributes)
            {
               if (httpMethodAttribute.IsValid(this.requestMethod))
               {
                  return method;
               }
            }
         }
         return null;
      }

      private IEnumerable<MethodInfo> GetSuitableMethods()
      {
         var controller = this.GetControllerInstance();

         if (controller == null)
         {
            return new MethodInfo[0];
         }
         return controller
            .GetType()
            .GetMethods()
            .Where(m => m.Name == actionName);
      }

      private object GetControllerInstance()
      {
         if (controllerInstance != null)
         {
            return controllerInstance;
         }

         var controllerFullQualifiedName = string.Format(
            "{0}.{1}.{2}, {0}",
            MvcContext.Get.AssemblyName,
            MvcContext.Get.ControllerFolder,
            this.controllerName);

         var controllerType = Type.GetType(controllerFullQualifiedName);

         if (controllerType == null)
         {
            return null;
         }

          controllerInstance = Activator.CreateInstance(controllerType);
         return controllerInstance;
      }


      private void PrepareMethodParameters(MethodInfo methodInfo)
      {
         var parameters = methodInfo.GetParameters();

         this.methodParameters = new object[parameters.Length];

         for (var i = 0; i < parameters.Length; i++)
         {
            var parameter = parameters[i];

            if (parameter.ParameterType.IsPrimitive || parameter.ParameterType == typeof(string))
            {
               var getParameterValue = this.getParams[parameter.Name];

               var value = Convert.ChangeType(getParameterValue, parameter.ParameterType);

               this.methodParameters[i] = value;
            }
            else
            {
               var modelType = parameter.ParameterType;
               var modelInstance = Activator.CreateInstance(modelType);

               var modelProperties = modelType.GetProperties();

               foreach (var modelProperty in modelProperties)
               {
                  var postParameterValue = this.postParams[modelProperty.Name];
                  var value = Convert.ChangeType(postParameterValue, modelProperty.PropertyType);

                  modelProperty.SetValue(modelInstance, value);
                  
               }
               this.methodParameters[i] = Convert.ChangeType(modelInstance, modelType);
            }
         }
      }


   }
}
