using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de controllers
builder.Services.AddControllers();

builder.Services.AddControllers().AddNewtonsoftJson();

//Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parâmetros de validação do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
        {
        //VALIDAÇÕES DO TOKEN
        //Quem está solicitando
        ValidateIssuer = true,
        //Quem está recebendo
        ValidateAudience = true,
        //Define se o tempo de expiração do token será validado
        ValidateLifetime = true,
        //Forma de criptografia e ainda validação da chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogo-chave-autenticacao-webapi-dev")),
        //Tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(30),
        //Nome da issuer, de onde está vindo
        ValidIssuer = "senai.inlock.webApi",
        //Nome da audience, de onde está vindo
        ValidAudience = "senai.inlock.webApi"
        };
});

//Adiciona o gerador do Swagger à coleção de serviços no Program.cs
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
        {
        Version = "v1",
        Title = "API Senai InLock",
        Description = "API para Gerenciamento de Jogos",
        Contact = new OpenApiContact
            {
            Name = "Sampaio",
            Url = new Uri("https://github.com/gsampaiowz")
            },
        });
    //Configura o Swagger para usar o arquivo XML gerado com as instruções anteriores
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autenticação via JWT no swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
        });

    //Usando a autenticação via JWT no swagger
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        }
                },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

//Habilita o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger
//adicionará o middleware do Swagger somente se o ambiente atual estiver definido como Desenvolvimento. A chamada do método UseSwaggerUI habilita o Middleware de arquivos estáticos.
if (app.Environment.IsDevelopment())
    {
    app.UseSwagger();
    app.UseSwaggerUI();
    }

//Para atender à interface do usuário do Swagger na raiz do aplicativo (https://localhost:<port>/), define-se a propriedade RoutePrefix como uma cadeia de caracteres vazia:
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//AUTENTICAÇÃO
app.UseAuthentication();

//AUTORIZAÇÃO
app.UseAuthorization();

//Mapear os controllers
app.MapControllers();

//Inicia a API
app.Run();