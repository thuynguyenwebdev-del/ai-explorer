using Azure.AI.OpenAI;
using OpenAI.Chat;

var openAIClient = new AzureOpenAIClient(
    new Uri(Environment.GetEnvironmentVariable("OPENAI_ENDPOINT") ?? "default"),
    new System.ClientModel.ApiKeyCredential(
        Environment.GetEnvironmentVariable("OPENAI_KEY") ?? "default")
);

var chatClient = openAIClient.GetChatClient("gpt-4.1-mini");

var prompt = "Does hippo eat meat?";

var response = await chatClient.CompleteChatAsync(
    [
        new SystemChatMessage("You are a helpful assistant."),
        new UserChatMessage(prompt)
    ]
);

Console.WriteLine(response.Value.Content[0].Text);