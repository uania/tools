FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY Uania.Tools.Web/bin/Release/net6.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "Uania.Tools.Web.dll"]