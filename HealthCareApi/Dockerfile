FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["HealthCareApi/HealthCareApi.csproj", "HealthCareApi/"]
RUN dotnet restore "HealthCareApi/HealthCareApi.csproj"
COPY . .
WORKDIR "/src/HealthCareApi"
RUN dotnet build "HealthCareApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HealthCareApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HealthCareApi.dll"]