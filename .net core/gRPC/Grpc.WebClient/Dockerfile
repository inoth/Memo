    
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /src
EXPOSE 5000

# FROM microsoft/dotnet:2.2-sdk AS build
# WORKDIR /src
# COPY ["ApiDemo/ApiDemo.csproj", "ApiDemo/"]
# RUN dotnet restore "ApiDemo/ApiDemo.csproj"
# COPY . .
# WORKDIR "/src/ApiDemo"
# RUN dotnet build "ApiDemo.csproj" -c Release -o /app

# FROM build AS publish
# RUN dotnet publish "ApiDemo.csproj" -c Release -o /app

RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
RUN echo "Asia/Shanghai" > /etc/timezone
RUN dpkg-reconfigure -f noninteractive tzdata

#FROM base AS final
WORKDIR /src
# COPY --from=publish /app .
COPY . /src
ENTRYPOINT ["dotnet", "Grpc.WebClient.dll"]