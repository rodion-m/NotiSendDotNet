using System.Text.Json.Serialization;

namespace NotiSendDotNet.Models.Requests;

public class SendEmailRequest
{
    public SendEmailRequest(
        string fromEmail, string fromName, string to, string subject, string text, string html = null)
    {
        FromEmail = fromEmail ?? throw new ArgumentNullException(nameof(fromEmail));
        FromName = fromName ?? throw new ArgumentNullException(nameof(fromName));
        To = to ?? throw new ArgumentNullException(nameof(to));
        Subject = subject ?? throw new ArgumentNullException(nameof(subject));
        Text = text;
        Html = html ?? text;
    }

    [JsonPropertyName("from_email")] public string FromEmail { get; set; }

    [JsonPropertyName("from_name")] public string FromName { get; set; }

    [JsonPropertyName("to")] public string To { get; set; }

    [JsonPropertyName("subject")] public string Subject { get; set; }

    [JsonPropertyName("text")] public string Text { get; set; }

    [JsonPropertyName("html")] public string Html { get; set; }

    [JsonPropertyName("payment")] public string Payment { get; set; } = "subscriber_priority";

    [JsonPropertyName("smtp_headers")] public SmtpHeaders SmtpHeaders { get; set; } = new();
}

public class SmtpHeaders
{
    [JsonPropertyName("Client-Id")] public string ClientId { get; set; }
}