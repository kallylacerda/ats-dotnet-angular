using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Validations
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
  public class GreaterThan0Attribute : ValidationAttribute
  {
    public GreaterThan0Attribute()
    {
    }

    public override bool IsValid(object value)
    {
      return Int32.Parse(value.ToString()) > 0;
    }
  }
}
