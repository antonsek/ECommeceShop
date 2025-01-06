using Xunit;
using Grpc.Net.Client;
using Message.Client;
using NBomber.Contracts;
using NBomber.CSharp;

namespace NBomberTests.LoadTests;

public class MessageTest
{
    [Fact]
    public void LoadMessageTest()
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:8002");

        // Создаем клиента для вызова gRPC-методов
        var client = new Greeter.GreeterClient(channel);

        // Сценарий нагрузки
        var scenario = Scenario.Create("LoadMessageTest", async context =>
            {
                try
                {
                    // gRPC-запрос
                    var request = new HelloRequest() { Name = "Anton" };
                    var response = await client.SayHelloAsync(request);

                    // Проверяем результат
                    if (response.Message != "")
                    {
                        return Response.Ok(); // Успешный запрос
                    }
                    else
                    {
                        return Response.Fail(statusCode: "500", message: "Unexpected response");
                    }
                }
                catch (Exception ex)
                {
                    // Логируем и возвращаем ошибку
                    return Response.Fail(message: ex.Message);
                }
            })
            .WithLoadSimulations(
                Simulation.Inject(rate: 100, interval: TimeSpan.FromSeconds(1), during: TimeSpan.FromMinutes(1)), // 100 запросов в секунду в течение 1 минуты
                Simulation.RampingInject(rate: 1000, interval: TimeSpan.FromSeconds(1),  during: TimeSpan.FromMinutes(2))
            );

        var result = NBomberRunner
            .RegisterScenarios(scenario)
            .Run();
        
        var scnStats = result.ScenarioStats.Get("LoadMessageTest");
        
        Assert.True(scnStats.Ok.Request.Percent == 100);
        Assert.True(scnStats.Fail.Request.Percent < 1); 
        
        Assert.True(scnStats.Ok.Latency.Percent75 < 200); // 75% of requests below 200ms.
        Assert.True(scnStats.Ok.Latency.Percent99 < 400); // 99% of requests below 400ms.
    }
}