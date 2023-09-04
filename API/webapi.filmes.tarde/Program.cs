using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de controllers
builder.Services.AddControllers();

//Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
	options.DefaultChallengeScheme = "JwtBearer";
	options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os parâmetros de validação do token
.AddJwtBearer(options =>
 {

 }); //Paramos aqui, continuar na segunda

//Adiciona o gerador do Swagger à coleção de serviços no Program.cs
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
		{
		Version = "v1",
		Title = "API Filmes Tarde",
		Description = "API para Gerenciamento de filmes - Introdução a sprint 2 - BackEndAPI",
		Contact = new OpenApiContact
			{
			Name = "Sampaio",
			Url = new Uri("https://github.com/gsampaiowz")
			},
		});
	//Configura o Swagger para usar o arquivo XML gerado com as instruções anteriores
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
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

//Mapear os controllers
app.MapControllers();

app.Run();
