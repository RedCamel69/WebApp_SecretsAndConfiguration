Simple project illustrating the use of key vault / app configuration

Steps For Keyvault
**********************
1. Create Key Vault CodeExamplesKV
2. Create web app and publish to we app WebApp-SecretsAndConfiguration
3. Enable Managed Identities for WebApp-SecretsAndConfiguration
4  Grant permission to the Azure Key Vault by adding access policy
5  Create a secret on Azure Key Vault
6	Install following packages
	Microsoft.Azure.KeyVault;	
	Microsoft.Azure.Services.AppAuthentication;
	Microsoft.Extensions.Configuration.AzureKeyVault;
7  Add vault URI to appsettings
8  Add local secret to secrets file

Steps For AppConfiguration
*******************************
1 Create ApplicationSetting1 in the appsettings json
2 Create ApplicationSetting1 in the Configuration tab of the WebApp-SecretsAndConfiguration web app.

Steps For App Configuration Service
******************************************
1 Create CodeExamplesAppConfiguration service
2 Add service's connection string to secrets.json (ConnectionStrings:AppConfig equates to AppConfig in ConnectionStrings section)
3 In Program.cs Retrieve the Connection String from the secrets file
4 In Program.cs connect to your CodeExamplesAppConfiguration using the connection string - embed in test for env to facillitate switch between local / hosted
5 Common named key values will have following order of precedence:
		app config service
		application settings
		appsettings.json
