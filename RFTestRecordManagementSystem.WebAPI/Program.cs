using Microsoft.EntityFrameworkCore;
using RFTestRecordManagementSystem.Infrastructure;
using RFTestRecordManagementSystem.Repository;
using RFTestRecordManagementSystem.Service;
using RFTestRecordManagementSystem_Service;

var builder = WebApplication.CreateBuilder(args);

// 1?、讀取 appsettings.json 的連線字串
var connectionString = builder.Configuration.GetConnectionString("RFTestRecordManagementSystemDB");

// 2?、註冊 DbContext（用 EF Core SqlServer）
builder.Services.AddDbContext<RFTestDbContext>(options =>
    options.UseSqlServer(connectionString));

// 3?、加入 Repository + Service 層（依賴注入）
builder.Services.AddScoped<IRFTestRecordRepository, EfCoreRFTestRecordRepository>();
builder.Services.AddScoped<IRFTestRecordService, RFTestRecordService>();

// 4、Add services to the container.
builder.Services.AddControllers();

// 5?、啟用 Swagger（API 測試介面)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 6?、Swagger 只在開發模式開啟
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 7、Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
