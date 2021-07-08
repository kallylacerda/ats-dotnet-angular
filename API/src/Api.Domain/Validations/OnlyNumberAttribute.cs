using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Api.Domain.Validations
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
  public class OnlyNumberAttribute : ValidationAttribute
  {
    public OnlyNumberAttribute()
    {
    }

    public override bool IsValid(object value)
    {
      var regex = new Regex(@"^\d+$");
      if (value != null)
        return regex.IsMatch(value.ToString());
      return true;
    }
  }
}
