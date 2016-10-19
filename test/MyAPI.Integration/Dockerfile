FROM microsoft/dotnet:1.0.0-preview2-sdk
ARG source=.
WORKDIR /app
COPY $source .
RUN dotnet restore
