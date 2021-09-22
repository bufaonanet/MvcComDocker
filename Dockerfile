FROM mcr.microsoft.com/dotnet/sdk:5.0

LABEL version="1.2" description="Aplicacao ASP NET.Core MVC com Docker"

WORKDIR /app

COPY dist /app

ENV ASPNETCORE_URLS=http://+:80  

EXPOSE 80

ENTRYPOINT [ "dotnet","MvcComDocker.dll" ]