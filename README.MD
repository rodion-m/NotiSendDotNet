# NotiSend API-клиент
[![Nuget](https://img.shields.io/nuget/v/NotiSendDotNet?style=for-the-badge)](https://www.nuget.org/packages/NotiSendDotNet/)

API-клиент для взаимодействия с сервисом NotiSend (.NET 6)

# Установка
Добавить к проекту NuGet пакет NotiSendDotNet: `Install-Package NotiSendDotNet` или `dotnet add package NotiSendDotNet`

# Использование
```csharp
var client = INotiSendClient.Create(authToken);
var request = new SendEmailRequest(
    from, "Почтальон Печкин",  to, "Заметка", "Все в порядке");
SendEmailResponse response = await client.SendEmail(request);
if (response.Status == "queued")
{
    //OK
}
```
Больше примеров доступно в тестах: https://github.com/rodion-m/NotiSendDotNet/blob/master/NotiSendDotNet.Test/ClientTests.cs