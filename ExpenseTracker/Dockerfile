FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ExpenseTracker.Web/*.csproj", "ExpenseTracker.Web/"]
COPY ["ExpenseTracker.Framework/*.csproj", "ExpenseTracker.Framework/"]
COPY ["ExpenseTracker.Data/*.csproj", "ExpenseTracker.Data/"]
RUN dotnet restore "ExpenseTracker.Web/ExpenseTracker.Web.csproj"
COPY . .
WORKDIR "/src/ExpenseTracker.Web"
RUN dotnet build "ExpenseTracker.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ExpenseTracker.Web.csproj" -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ExpenseTracker.Web.dll"]