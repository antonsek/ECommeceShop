using Grpc.Core;
using Message.Api;

namespace Message.Api.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Technology plays a crucial role in today's world, transforming nearly every aspect of our lives. The Internet of Things, artificial intelligence, and blockchain are just a few innovations reshaping business, education, and daily routines. Almost every device, from smartphones to refrigerators, is now connected to the network, enabling unprecedented opportunities for data exchange and automation. Artificial intelligence is used to analyze vast amounts of data, make decisions, and even create content, helping companies boost productivity and offer personalized products.\n\nHowever, with the rise of technology comes the growing need for security. Cyberattacks and data breaches have become significant threats, leading organizations to invest heavily in cybersecurity. Additionally, global digitalization raises new questions about privacy and ethics, particularly regarding data usage.\n\nIn the future, further integration of technology into our lives is expected. Smart cities, autonomous vehicles, and robotics will become commonplace, enhancing comfort and convenience. Yet, it's essential to remember that technology is a tool, not the ultimate goal. Only thoughtful and responsible use can truly benefit society." + request.Name
        });
    }
}