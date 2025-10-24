using HealthcareApi.Data;
using MachineLearningModel.DataEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ML;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var modelPath = Path.Combine(builder.Environment.ContentRootPath, "MachineLearningModels", "HeartDiseaseModel.zip");

builder.Services.AddPredictionEnginePool<HeartDiseaseData, HeartDiseasePrediction>()
  .FromFile(modelName: "HeartDiseaseModel", filePath: modelPath, watchForChanges: true);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddCors(options =>
{
  options.AddPolicy("CorsPolicy", b =>
    b
      .WithOrigins("http://localhost:5173")
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors("CorsPolicy");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


