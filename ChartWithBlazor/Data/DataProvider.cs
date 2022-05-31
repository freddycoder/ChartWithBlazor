using System.Globalization;

namespace ChartWithBlazor.Data;

public class DataProvider
{
    private static Data[]? _values;

    public async ValueTask<Data[]> GetDataAsync()
    {
        if (_values == null)
        {
            _values = (await File.ReadAllLinesAsync("datasauRus.csv"))
                .Skip(1)
                .Select(line =>
                {
                    var elements = line.Split(',');

                    double.TryParse(elements[1], NumberStyles.Any, new CultureInfo("en-us"), out double x);
                    double.TryParse(elements[2], NumberStyles.Any, new CultureInfo("en-us"), out double y);

                    return new Data
                    {
                        Name = elements[0],
                        X = x,
                        Y = y
                    };
                })
                .ToArray();
        }

        return _values;
    }
}
