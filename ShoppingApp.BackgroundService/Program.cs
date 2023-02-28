// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.AddCompletedShoplist;
using ShoppingApp.Application.Features.ShoplistFeature.Commands.CompleteShoplist;
using ShoppingApp.Domain.Entities;
using System.Text;
using System.Text.Json;

Console.WriteLine("Background service çalıştı");
ConnectionFactory connectionFactory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "123456" };
using (IConnection connection = connectionFactory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    EventingBasicConsumer eventingBasicConsumer = new EventingBasicConsumer(channel);
    //Yeni data geldiğinde bu event otomatik tetikleniyor.
    eventingBasicConsumer.Received += (model, ea) =>
    {
        byte[] body = ea.Body.ToArray();// Kuyruktaki içerik bilgisi.
        string message = Encoding.UTF8.GetString(body);// Gelen bodyi stringe çeviriyoruz.
        AddCompletedShoplistCommandRequest response = JsonSerializer.Deserialize<AddCompletedShoplistCommandRequest>(message); // Mesajdan dönen veriyi classa çeviriyoruz.

        using HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:7058/");
        string serializeEmail = JsonSerializer.Serialize(response);

        StringContent stringContent = new StringContent(serializeEmail, Encoding.UTF8, "application/json");
        HttpResponseMessage result = httpClient.PostAsync("api/Admins/AddCompletedShoplist", stringContent).Result;
        if (result.IsSuccessStatusCode)
            Console.WriteLine("Admin kayıt başarılı.");
        else
            Console.WriteLine($"Admin kayıt başarısız. Hata Kodu: {result.StatusCode}");
    };
    channel.BasicConsume(queue: "ShoplistQueue", // Consume edilecek kuyruk ismi
        autoAck: true, //Kuyruk ismi doğrulansın mı
        consumer: eventingBasicConsumer); //Hangi consumer kullanılacak.

    Console.WriteLine("Shoplist kuyruğuna bağlantı başarılı. Dinleniyor...");
    Console.ReadKey();
}


