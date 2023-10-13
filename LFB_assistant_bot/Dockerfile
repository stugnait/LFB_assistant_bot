FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LFB_assistant_bot/LFB_assistant_bot.csproj", "LFB_assistant_bot/"]
RUN dotnet restore "LFB_assistant_bot/LFB_assistant_bot.csproj"
COPY . .
WORKDIR "/src/LFB_assistant_bot"
RUN dotnet build "LFB_assistant_bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LFB_assistant_bot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LFB_assistant_bot.dll"]
