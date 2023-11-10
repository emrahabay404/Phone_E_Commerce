using System.Text.Json;

namespace E_Commerce_Core.Utilities.Results
{
   public class ErrorDetails
   {
      public string Message { get; set; }
      public int StatusCode { get; set; }

      public override string ToString()
      {
         return JsonSerializer.Serialize(this);
      }
   }
}
