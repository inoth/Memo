#build stage
# FROM golang:alpine AS builder
# WORKDIR /go/src/app
# COPY . .

# ENV GO111MODULE=on GOPROXY=https://goproxy.io

# RUN apk add --no-cache git
# RUN go get -d -v ./...
# RUN go install -v ./...
# RUN go build -o /go/bin/app main.go

#final stage
FROM alpine:latest
WORKDIR /app
EXPOSE 7777

RUN apk --no-cache add ca-certificates
COPY . /app

RUN chmod 777 /app/main
# COPY --from=builder ["/go/bin/app/","/go/src/app/conf.yaml","/app/"]
LABEL Name=apisample Version=0.0.1

ENTRYPOINT ["/app/main"]


# sudo docker run -d -p 7777:7777 -v /docker/configs/apisample/conf.yaml:/app/conf.yaml apisample
