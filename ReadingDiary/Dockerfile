#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ReadingDiary/ReadingDiary.csproj", "ReadingDiary/"]
RUN dotnet restore "ReadingDiary/ReadingDiary.csproj"
COPY . .
WORKDIR "/src/ReadingDiary"
RUN dotnet build "ReadingDiary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReadingDiary.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReadingDiary.dll"]