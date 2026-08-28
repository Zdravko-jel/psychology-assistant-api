using PsychologyAssistant.DTOs.Report;
using PsychologyAssistant.Interfaces;
using ScottPlot;

namespace PsychologyAssistant.Service
{
    public class ChartService : IChartService
    {
        public byte[] CreateClosedFilesPerDayChart(List<DailyStatisticDto> data)
        {
            var plot = new Plot();

            double[] days = data.Select(x => (double)x.Date.Day).ToArray();
            double[] counts = data.Select(x => (double)x.Count).ToArray();

            var bars = plot.Add.Bars(days, counts);

            plot.Title("Closed Files Per Day");
            plot.XLabel("Day of Month");
            plot.YLabel("Number of Files");

            return plot.GetImageBytes(1000, 500, ImageFormat.Png);
        }

        public byte[] CreateDiagnosesPerDayChart(List<DailyStatisticDto> data)
        {
            var plot = new Plot();

            double[] days = data.Select(x => (double)x.Date.Day).ToArray();
            double[] counts = data.Select(x => (double)x.Count).ToArray();

            var bars = plot.Add.Bars(days, counts);

            plot.Title("Diagnoses found per day");
            plot.XLabel("Day of Month");
            plot.YLabel("Number of Diagnoses");

            return plot.GetImageBytes(1000, 500, ImageFormat.Png);
        }

        public byte[] CreatePatientsPerDayChart(List<DailyStatisticDto> data)
        {
            var plot = new Plot();

            double[] days = data.Select(x => (double)x.Date.Day).ToArray();
            double[] counts = data.Select(x => (double)x.Count).ToArray();

            var bars = plot.Add.Bars(days, counts);

            plot.Title("Patients Registered Per Day");
            plot.XLabel("Day of Month");
            plot.YLabel("Number of Patients");

            return plot.GetImageBytes(1000, 500, ImageFormat.Png);
        }

        public byte[] CreateSessionsPerDayChart(List<DailyStatisticDto> data)
        {
            var plot = new Plot();

            double[] days = data.Select(x => (double)x.Date.Day).ToArray();
            double[] counts = data.Select(x => (double)x.Count).ToArray();

            var bars = plot.Add.Bars(days, counts);

            plot.Title("Sessions Per Day");
            plot.XLabel("Day of Month");
            plot.YLabel("Number of Sessions");

            return plot.GetImageBytes(1000, 500, ImageFormat.Png);
        }
    }
}
