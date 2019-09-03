    
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /src
EXPOSE 80

RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
RUN echo "Asia/Shanghai" > /etc/timezone
RUN dpkg-reconfigure -f noninteractive tzdata

WORKDIR /src
# COPY --from=publish /app .
COPY . /src
ENTRYPOINT ["dotnet", "Grpc.Client.dll"]