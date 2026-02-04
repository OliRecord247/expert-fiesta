using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace expert_fiesta.Application.Data.ValueConverters;

public class DateConverter : ValueConverter<DateOnly, string>
{
    public DateConverter() : base(
        dateOnly => dateOnly.ToString("yyyyMMdd", CultureInfo.InvariantCulture),
        stringDate => DateOnly.ParseExact(stringDate, "yyyyMMdd", CultureInfo.InvariantCulture)
        )
    {}
}