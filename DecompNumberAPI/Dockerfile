#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DecompNumberAPI/DecompNumberAPI.csproj", "DecompNumberAPI/"]
COPY ["DecompNumber.Domain.Core/DecompNumber.Domain.Core.csproj", "DecompNumber.Domain.Core/"]
COPY ["DecompNumber.App.DTO/DecompNumber.App.DTO.csproj", "DecompNumber.App.DTO/"]
COPY ["DecompNumber.Domain/DecompNumber.Domain.csproj", "DecompNumber.Domain/"]
COPY ["DecompNumber.Infra.CC.IOC/DecompNumber.Infra.CC.IOC.csproj", "DecompNumber.Infra.CC.IOC/"]
COPY ["DecompNumber.Domain.Services/DecompNumber.Domain.Services.csproj", "DecompNumber.Domain.Services/"]
RUN dotnet restore "DecompNumberAPI/DecompNumberAPI.csproj"
COPY . .
WORKDIR "/src/DecompNumberAPI"
RUN dotnet build "DecompNumberAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DecompNumberAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DecompNumberAPI.dll"]