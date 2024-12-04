using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services
    .AddAuthentication(BearerTokenDefaults.AuthenticationScheme)
    .AddBearerToken();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () =>
    {
       return "Hello World!";
    })
    .WithOpenApi();

app.MapGet("login", (bool firstApi = false, bool secondApi = false) =>
/*{
    var config = builder.Configuration;
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtOptions.SecretKey"]!));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var userClaims = new[]
    {
        new Claim(ClaimTypes.Name, "Admin"),
    };

    var token = new JwtSecurityToken(
        issuer: config["JwtOptions.Issuer"],
        audience: config["JwtOptions.Audience"],
        claims: userClaims,
        expires: DateTime.Now.AddHours(2),
        signingCredentials: credentials
        );
    
    return new JwtSecurityTokenHandler().WriteToken(token);
}*/
    Results.SignIn(
        new ClaimsPrincipal(
            new ClaimsIdentity(
                [
                    new Claim("sub", Guid.NewGuid().ToString()),
                    new Claim("first-api-access", firstApi.ToString()),
                    new Claim("second-api-access", secondApi.ToString())
                ],
                BearerTokenDefaults.AuthenticationScheme)),
        authenticationScheme: BearerTokenDefaults.AuthenticationScheme));

app.UseAuthentication();

app.UseAuthorization();

app.MapReverseProxy();

app.Run();