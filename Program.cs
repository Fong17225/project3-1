using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình DbContext cho Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 403))));

// Thêm các dịch vụ cho MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Sử dụng các middleware bảo mật như xác thực và phân quyền
app.UseAuthorization();

// Đảm bảo sử dụng tài nguyên tĩnh như hình ảnh, JavaScript và CSS
app.UseStaticFiles();

// Cấu hình các route cho các controller và các action tương ứng
app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    "admin",
    "admin/{action=Admin}/{id?}",
    new { controller = "Admin", action = "Admin" }
);

// Chạy ứng dụng
app.Run();
