FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY BookingNG.Providers.Service.csproj ./
RUN dotnet restore "./BookingNG.Providers.Service.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BookingNG.Providers.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingNG.Providers.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingNG.Providers.Service.dll"]
