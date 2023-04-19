FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PalmLab4-3.0.IvanSyleman/PalmLab4-3.0.IvanSyleman.csproj", "PalmLab4-3.0.IvanSyleman/"]
RUN dotnet restore "PalmLab4-3.0.IvanSyleman/PalmLab4-3.0.IvanSyleman.csproj"
COPY . .
WORKDIR "/src/PalmLab4-3.0.IvanSyleman"
RUN dotnet build "PalmLab4-3.0.IvanSyleman.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PalmLab4-3.0.IvanSyleman.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PalmLab4-3.0.IvanSyleman.dll"]
