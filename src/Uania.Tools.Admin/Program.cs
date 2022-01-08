using Uania.Tools.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("defaultCors",
        builder =>
        {
            builder.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true); // allow any origin
        });
});
// Add log4net
builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();
// Add services to the container.
builder.Services.RegisterService(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["JwtConfig:Audience"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SecretKey"]))
                    };
                });
builder.Services.AddControllers(config =>
    {
        var policy = new AuthorizationPolicyBuilder()
                         .RequireAuthenticatedUser()
                         .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Uania.Tools.Api", Version = "v1" });
    var basePath = AppContext.BaseDirectory;
    var xmls = Directory.GetFiles(basePath, "*.xml");
    foreach (var xml in xmls)
    {
        option.IncludeXmlComments(xml);
    }

    #region jwt认证
    // 开启加权小锁
    option.OperationFilter<AddResponseHeadersFilter>();
    option.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
    // 在header中添加token，传递到后台
    option.OperationFilter<SecurityRequirementsOperationFilter>();
    // Jwt Bearer 认证
    option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Name = "Authorization",//jwt默认的参数名称
        In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
        Type = SecuritySchemeType.ApiKey,
        Description = "Authorization:Bearer {your JWT token},注意两者之间是一个空格",
    });
    #endregion
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Uania.Tools.Api v1"));

app.UseHttpsRedirection();
var options = new DefaultFilesOptions();
options.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(options);
app.UseStaticFiles();
app.UseCors("defaultCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
