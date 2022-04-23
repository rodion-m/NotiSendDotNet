using System;
using System.Threading.Tasks;
using NotiSendDotNet.Models.Requests;
using NotiSendDotNet.Models.Responses;
using Refit;
using Xunit;

namespace NotiSendDotNet.Test;

public partial class ClientTests
{
    [Fact]
    public async Task SendEmail_with_correct_fields_succeeded()
    {
        var (authToken, from, to) = GetVariables();
        var client = INotiSendClient.Create(authToken);
        var request = new SendEmailRequest(
            from, "Почтальон Печкин",  to, "Заметка", "Все в порядке");
        try
        {
            SendEmailResponse response = await client.SendEmail(request);
            Assert.Equal(request.To, response.To);
            Assert.Equal("queued", response.Status);
            Assert.NotEqual(0, response.Id);
        }
        catch (ApiException e)
        {
            Assert.Null(e.Content);
            Assert.NotNull(e.Content);
        }
    }

    private static (string authToken, string from, string to) GetVariables()
    {
        var authToken = Environment.GetEnvironmentVariable("notisend_token");
        if (authToken == null) throw new InvalidOperationException("Environment variable 'notisend_token' is not set");

        var from = Environment.GetEnvironmentVariable("notisend_from_email");
        if (from == null) throw new InvalidOperationException("Environment variable 'notisend_from_email' is not set");

        var to = Environment.GetEnvironmentVariable("notisend_to_email");
        if (to == null) throw new InvalidOperationException("Environment variable 'notisend_to_email' is not set");
        return (authToken, from, to);
    }
}