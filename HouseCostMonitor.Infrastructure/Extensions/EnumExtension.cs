namespace HouseCostMonitor.Infrastructure.Extensions;

using System.ComponentModel;
using System.Reflection;

public static class EnumExtension
{
    public static string? GetEnumDescription<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        return enumValue
            .GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DescriptionAttribute>()?
            .Description ?? string.Empty;
    }
}