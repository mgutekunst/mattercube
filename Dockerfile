FROM microsoft/dotnet:2.1-sdk AS build-env

WORKDIR /app

COPY SonarResultTransformer/*.fsproj .
RUN dotnet restore


COPY SonarResultTransformer/ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1

WORKDIR /app
COPY --from=build-env /app/out ./

ENV CHANNEL="Town-Square"
ENV ICON_URL=""
ENV USERNAME="Sonarqube"
ENV TEXT="Here are your results"
ENV HOOK_URL=""


EXPOSE 80

ENTRYPOINT ["dotnet", "SonarResultTransformer.dll"]
