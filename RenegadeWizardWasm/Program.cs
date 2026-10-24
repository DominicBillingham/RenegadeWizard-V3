using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RenegadeWizardWasm;
using RenegadeWizardWasm.Core;
using RenegadeWizardWasm.Core.DataStorage;
using RenegadeWizardWasm.Core.Interactions;
using RenegadeWizardWasm.Core.UserInterface;
using RenegadeWizardWasm.Pages;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<GameCoordinator>();
builder.Services.AddScoped<InputManager>();
builder.Services.AddScoped<SceneManager>();
builder.Services.AddScoped<CombatManager>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var host = builder.Build();

var gameCoordinator = host.Services.GetRequiredService<GameCoordinator>();
GameCoordinator.Initialize(gameCoordinator);

await host.RunAsync();