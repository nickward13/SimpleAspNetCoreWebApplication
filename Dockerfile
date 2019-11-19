# First stage of multi-stage build
FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build-env
WORKDIR /app

# copy the contents of agent working directory on host to workdir in container
COPY . ./

# dotnet commands to build, test, and publish
RUN dotnet restore
RUN dotnet build -c Release
RUN dotnet publish -c Release -o out

# Second stage - Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SimpleAspNetCoreWebApplication.dll"]