using System.Text.Json.Serialization;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace NotiSendDotNet.Models.Responses;

public class SendEmailResponse
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("from_email")] public string FromEmail { get; set; }

    [JsonPropertyName("from_name")] public string FromName { get; set; }

    [JsonPropertyName("to")] public string To { get; set; }

    [JsonPropertyName("subject")] public string Subject { get; set; }

    [JsonPropertyName("text")] public string Text { get; set; }

    [JsonPropertyName("html")] public string Html { get; set; }

    [JsonPropertyName("status")] public string Status { get; set; }

    [JsonPropertyName("events")] public Events Events { get; set; }
}

public class Events
{
    [JsonPropertyName("open")] public long Open { get; set; }

    [JsonPropertyName("redirect")] public Dictionary<string, long> Redirect { get; set; }

    [JsonPropertyName("spam")] public long Spam { get; set; }

    [JsonPropertyName("unsubscribe")] public long Unsubscribe { get; set; }
}