using WebSocketApI;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args).Inject();//注入Furion

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var service = builder.Services;

service.AddMvc();

string anyAllowSpecificOrigins = "any";//解决跨域
//解决跨域
service.AddCors(options =>
{
    options.AddPolicy(anyAllowSpecificOrigins, corsbuilder =>
    {
        var corsPath = builder.Configuration.GetSection("CorsPaths").GetChildren().Select(p => p.Value).ToArray();
        corsbuilder.WithOrigins(corsPath) 
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();//指定处理cookie  
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//添加websocket中间件

app.UseInject();//注入Furion
app.UseCorsAccessor();//
app.UseWebSockets(new WebSocketOptions()
{
    KeepAliveInterval = TimeSpan.FromSeconds(60),
    ReceiveBufferSize = 1024 * 1024
});
app.UseMiddleware<WebSocketMiddleHandler>();
app.Run();