using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Validations
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
  public class BirthdateAttribute : ValidationAttribute
  {
    public BirthdateAttribute()
    {
    }

    public override bool IsValid(object value)
    {
      var date = (DateTime)value;
      return date < DateTime.UtcNow;
    }
  }
}
