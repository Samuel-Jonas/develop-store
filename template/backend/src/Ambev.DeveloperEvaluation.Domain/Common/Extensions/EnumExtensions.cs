using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.Domain.Common.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var memberInfo = enumValue
            .GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault();

        if (memberInfo == null)
            return enumValue.ToString();

        var displayAttribute = memberInfo.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

        return displayAttribute?.Name ?? enumValue.ToString();
    }
}
