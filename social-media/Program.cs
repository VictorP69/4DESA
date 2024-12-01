using Microsoft.EntityFrameworkCore;
using social_media.Contexts;
using social_media.Repository.CommentRepository;
using social_media.Repository.PostRepository;
using social_media.Repository.UserRepository;
using social_media.Services.CommentService;
using social_media.Services.MediaService;
using social_media.Services.PostService;
using social_media.Services.UserService;
using DotNetEnv;
using social_media.Repository.MediaRepository;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

builder.Configuration.AddEnvironmentVariables();

builder.Configuration["AzureBlobStorage:ConnectionString"] = Environment.GetEnvironmentVariable("AZURE_BLOB_CONNECTION_STRING");
builder.Configuration["AzureBlobStorage:ContainerName"] = Environment.GetEnvironmentVariable("AZURE_BLOB_CONTAINER_NAME");

var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();

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

// Configuration du pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
