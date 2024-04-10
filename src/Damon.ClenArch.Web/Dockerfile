FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8086

ENV ASPNETCORE_URLS=http://+:8086

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Damon.ClenArch.Web/Damon.ClenArch.Web.csproj", "src/Damon.ClenArch.Web/"]
RUN dotnet restore "src/Damon.ClenArch.Web/Damon.ClenArch.Web.csproj"
COPY . .
WORKDIR "/src/src/Damon.ClenArch.Web"
RUN dotnet build "Damon.ClenArch.Web.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Damon.ClenArch.Web.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Damon.ClenArch.Web.dll"]
