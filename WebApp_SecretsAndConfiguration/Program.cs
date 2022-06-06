using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


var app = builder.Build();

//Retrieve the Connection String from the secrets manager 
var connectionString = builder.Configuration.GetConnectionString("AppConfig");

//Connect to your App Config Store using the connection string
//builder.Configuration.AddAzureAppConfiguration(connectionString);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    var keyVaultEndpoint = builder.Configuration["VaultURI"];

    if (!string.IsNullOrEmpty(keyVaultEndpoint))
    {
        var azureServiceTokenProvider = new AzureServiceTokenProvider();
        var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
        builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
    }

    //include in env check to exclude app config service values from local dev / switch to local secrets
    builder.Configuration.AddAzureAppConfiguration(connectionString);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();



app.Run();
