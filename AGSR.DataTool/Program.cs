using AGSR.DataTool;
using AGSR.DataTool.Models;
using AGSR.DataTool.Rules;
using CommandLine;
using System.Text;
using System.Text.Json;
using static AGSR.DataTool.Constants;

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true;
    cts.Cancel();
};

await Parser.Default.ParseArguments<Options>(args)
    .WithParsedAsync(RunOptions);

async Task RunOptions(Options options)
{
    using var httpClient = new HttpClient();
    var uri = new Uri(options.BaseUrl + CreatePatientAction);

    var patients = new PatientFaker(options.Locale).Generate(options.Count);

    foreach (var patient in patients)
    {
        await SendRequest(httpClient, patient, uri, cts.Token);
    }
}

async Task SendRequest(HttpClient httpClient, Patient patient, Uri uri, CancellationToken cancellationToken)
{
    var json = JsonSerializer.Serialize(patient);
    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
    
    using var response = await httpClient.PostAsync(uri, httpContent, cancellationToken);
}