using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RenegadeWizardWasm.Core;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var host = builder.Build();

await host.RunAsync();

GameManager.StartGame();