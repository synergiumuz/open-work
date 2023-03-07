FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY src/ .
WORKDIR /src/OpenWork.Api
RUN dotnet restore "OpenWork.Api.csproj"
RUN dotnet build "OpenWork.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenWork.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenWork.Api.dll"]
