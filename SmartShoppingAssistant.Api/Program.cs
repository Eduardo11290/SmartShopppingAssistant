using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using OpenAI;
using SmartShoppingAssistant.BusinessLogic.Agents;
using SmartShoppingAssistant.BusinessLogic.Services;
using SmartShoppingAssistant.BusinessLogic.Services.Interfaces;
using SmartShoppingAssistant.BussinessLogic.Services;
using SmartShoppingAssistant.BussinessLogic.Services.Interfaces;
using SmartShoppingAssistant.DataAcces;
using SmartShoppingAssistant.DataAcces.Entities;
using SmartShoppingAssistant.DataAcces.Repositories;
using SmartShoppingAssistant.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("SmartShoppingAssistantContext");

var openAiApiKey = builder.Configuration["OpenAI:ApiKey"]
                   ?? throw new InvalidOperationException("OpenAI:ApiKey is not configured.");
var openAiModel = builder.Configuration["OpenAI:ModelId"] ?? "gpt-4o";

builder.Services.AddSingleton<IChatClient>(
    new OpenAIClient(openAiApiKey)
        .GetChatClient(openAiModel)
        .AsIChatClient()
        .AsBuilder()
        .UseFunctionInvocation()
        .Build());

builder.Services.AddScoped<IPromotionCheckerAgent, PromotionCheckerAgent>();

builder.Services.AddDbContext<SmartShoppingAssistantDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();

builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IPromotionService, PromotionService>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<ISuggestionComposerAgent, SuggestionComposerAgent>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
