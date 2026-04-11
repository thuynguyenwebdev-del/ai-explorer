using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Extensions.AI;

DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions
{
    TenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID") ?? "default",
};

IChatClient client = new AzureOpenAIClient(new Uri(
    Environment.GetEnvironmentVariable("OPENAI_ENDPOINT") ?? "default"),
    new DefaultAzureCredential(options))
    //new System.ClientModel.ApiKeyCredential(
    //    Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "default"))
    .GetChatClient("gpt-4o-mini")
    .AsIChatClient();

var response = await client.GetResponseAsync("Where is the biggest beaver in the world?");

Console.WriteLine(response);
