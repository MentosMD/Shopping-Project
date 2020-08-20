FROM microsoft/dotnet:3.1-sdk as build
ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

COPY ShoppingOnline.csproj /build/
RUN dotnet restore ./build/ShoppingOnline.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish ./ShoppingOnline.csproj -c $BUILDCONFIG -o /build/out /p:Version=$VERSION

FROM microsoft/dotnet:3.1-aspnetcore-runtime
WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT ["dotnet", "ShoppingOnline.dll"]