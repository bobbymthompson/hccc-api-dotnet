FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY hccc-server-dotnet/hccc-server-dotnet.csproj hccc-server-dotnet/
RUN dotnet restore hccc-server-dotnet/hccc-server-dotnet.csproj
COPY . .
WORKDIR /src/hccc-server-dotnet
RUN dotnet build hccc-server-dotnet.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish hccc-server-dotnet.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "hccc-server-dotnet.dll"]
