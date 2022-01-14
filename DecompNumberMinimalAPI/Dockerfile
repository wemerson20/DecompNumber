#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DecompNumberMinimalAPI/DecompNumberMinimalAPI.csproj", "DecompNumberMinimalAPI/"]
COPY ["DecompNumber.Domain.Core/DecompNumber.Domain.Core.csproj", "DecompNumber.Domain.Core/"]
COPY ["DecompNumber.App.DTO/DecompNumber.App.DTO.csproj", "DecompNumber.App.DTO/"]
COPY ["DecompNumber.Domain/DecompNumber.Domain.csproj", "DecompNumber.Domain/"]
COPY ["DecompNumber.Domain.Services/DecompNumber.Domain.Services.csproj", "DecompNumber.Domain.Services/"]
COPY ["DecompNumber.Infra.CC.IOC/DecompNumber.Infra.CC.IOC.csproj", "DecompNumber.Infra.CC.IOC/"]
RUN dotnet restore "DecompNumberMinimalAPI/DecompNumberMinimalAPI.csproj"
COPY . .
WORKDIR "/src/DecompNumberMinimalAPI"
RUN dotnet build "DecompNumberMinimalAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DecompNumberMinimalAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DecompNumberMinimalAPI.dll"]