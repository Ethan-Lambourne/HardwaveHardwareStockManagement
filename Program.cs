using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.GenerateID;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IItemsRepository<Case>, CaseRepository>();
builder.Services.AddSingleton<IItemsRepository<CPU>, CPURepository>();
builder.Services.AddSingleton<IItemsRepository<GraphicsCard>, GraphicsCardRepository>();
builder.Services.AddSingleton<IItemsRepository<Laptop>, LaptopRepository>();
builder.Services.AddSingleton<IItemsRepository<Memory>, MemoryRepository>();
builder.Services.AddSingleton<IItemsRepository<HardwaveStockManagement.Models.Monitor>, MonitorRepository>();
builder.Services.AddSingleton<IItemsRepository<Motherboard>, MotherboardRepository>();
builder.Services.AddSingleton<IItemsRepository<Storage>, StorageRepository>();
builder.Services.AddSingleton<IGenerateItemID, GenerateItemID>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

builder.Services.AddSingleton<ItemContext>();
builder.Services.AddSingleton<UserContext>();
builder.Services.AddSingleton<OrderContext>();
ItemContext itemContext = new();
UserContext userContext = new();
OrderContext orderContext = new();
DbInitializer.Initialize(itemContext, userContext, orderContext);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=LogInView}/{id?}");

app.Run();
