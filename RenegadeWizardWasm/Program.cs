using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.UserInterface;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<GameManager>();
builder.Services.AddSingleton<SceneManager>();
builder.Services.AddSingleton<InputManager>();

var host = builder.Build();

await host.RunAsync();
