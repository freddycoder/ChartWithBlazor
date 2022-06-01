# ChartWithBlazor

![Example page](https://github.com/freddycoder/ChartWithBlazor/blob/main/demo.png?raw=true)

The graph is rendered using google charts.

## How it work

In the _Layout.cshtml the script is loaded and a javascript function ```loadChart``` is defined.

```
 <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        window.loadChart = (chartTitle, xs, ys) => {

            google.charts.load('current', { 'packages': ['corechart'] });
            google.charts.setOnLoadCallback(drawChart);

            var array = [
                ['X', 'Y']
            ];

            for (var i = 0; i < xs.length; i++) 
            {
                var ap = [xs[i], ys[i]];

                array.push(ap);
            }

            function drawChart() {
                var data = google.visualization.arrayToDataTable(array);

                var options = {
                    title: chartTitle,
                    hAxis: { title: 'X', minValue: 0, maxValue: 100 },
                    vAxis: { title: 'Y', minValue: 0, maxValue: 100 },
                    legend: 'none'
                };

                var chart = new google.visualization.ScatterChart(document.getElementById('chart_div'));

                chart.draw(data, options);
            }


        };
    </script>
```

After in the FetchData.razor page the function is called passing the selected data point as parameter using the JSRuntime.

```
await JSRuntime.InvokeVoidAsync("loadChart",
    selectedDataset,
    xs,
    ys);
```

### Source:

The google chart documentation for scatter charts: https://developers.google.com/chart/interactive/docs/gallery/scatterchart