using Microsoft.EntityFrameworkCore;
using social_media.Contexts;
using social_media.Repository.CommentRepository;
using social_media.Repository.PostRepository;
using social_media.Repository.UserRepository;
using social_media.Services.CommentService;
using social_media.Services.MediaService;
using social_media.Services.PostService;
using social_media.Services.UserService;
using social_media.Repository.MediaRepository;
using Microsoft.AspNetCore.Identity;
using social_media.Models;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using social_media.Middleware;
using social_media.Services.AuthService;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<DataContext>();

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DevConnection"]));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Syntaxe : Bearer {votre token}",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthorizationFilter>();

builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.AddEventSourceLogger();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapIdentityApi<User>();
app.MapGet("/", () => Results.Redirect("/swagger"));
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
