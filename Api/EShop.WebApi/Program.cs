using EShop.BLL.ServiceInjections;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//----------------------

builder.Services.AddIdentityServices();     //Identity Services
builder.Services.MapperServiceInjections(); //Mapper Services
builder.Services.AddDbContextService();     //Context Services
builder.Services.AddRepServices();          //Repositories Services
builder.Services.AddManagerServices();      //Manager Services
builder.Services.AddCookieServices();       //Cookie Services
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
