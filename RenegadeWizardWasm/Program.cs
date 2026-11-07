using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RenegadeWizardWasm;
using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<GameManager>();
builder.Services.AddSingleton<SceneManager>();
builder.Services.AddSingleton<InputManager>();

var host = builder.Build();

ReactBridge.Initialize(
    host.Services.GetRequiredService<GameManager>()
);

await host.RunAsync();
