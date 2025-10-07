using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDbConnection>(sp =>
{
    /* Acessa o arquivo appsetings.json, dentro do objeto connectionstring */
    string connectionstring = builder.Configuration.GetConnectionString("BancoDoCoelho");
    return new NpgsqlConnection(connectionstring);
}
);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
