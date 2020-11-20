FROM microsoft/aspnetcore-build AS build
WORKDIR /build
COPY . .
RUN dotnet restore
RUN dotner publish -c release -o output

FROM microsoft/aspnetcore
WORKDIR /app
COPY --from=build /build/output .
ENTRYPOINT ["dotnet","MayaBinance.Api.dll"]