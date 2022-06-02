using System.Text.Json.Serialization;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618

namespace NotiSendDotNet.Models.Responses;

public class ErrorResponse
{
    [JsonPropertyName("errors")] public Error[] Errors { get; set; }

    public class Error
    {
        [JsonPropertyName("code")] public long Code { get; set; }

        [JsonPropertyName("detail")] public string Detail { get; set; }
    }
}