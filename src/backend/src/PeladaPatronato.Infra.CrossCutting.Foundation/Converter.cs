
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace PeladaPatronato.Infra.CrossCutting.Foundation
{
  public static class Converter
  {
    public static string ObterDescricaoItemEnum<T>(this T e) where T : IConvertible
    {
      if (e is Enum)
      {
        Type type = e.GetType();
        Array values = System.Enum.GetValues(type);
        foreach (int val in values)
        {
          if (val == e.ToInt32(CultureInfo.InvariantCulture))
          {
            var memInfo = type.GetMember(type.GetEnumName(val));
            var descriptionAttribute = memInfo[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;

            if (descriptionAttribute == null)
            {
              var displayAttribute = memInfo[0]
                  .GetCustomAttributes(typeof(DisplayAttribute), false)
                  .FirstOrDefault() as DisplayAttribute;

              if (displayAttribute != null)
              {
                return displayAttribute.Name;
              }
            }
            else
            {
              return descriptionAttribute.Description;
            }
          }
        }
      }

      return string.Empty; // could also return string.Empty
    }
  }
}
