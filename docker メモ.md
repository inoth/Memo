## docker メモ 

### よく使う命令
docker run <br/>
-v  path:path  宿主机：容器 <br/>
-p  prot:prot  宿主机：容器 <br/>

docker [option] $(sudo docker [options]) <br/>

docker build <br/>
-t tags:version <br/>

### Dockerfile メモ
// 引用
FORM image AS xxx <br/>
// 执行linux命令
RUN cmd
// 执行
ENTRYPOINT ["xxxx","xxxx"]



### go build linux use file
SET CGO_ENABLED=0
SET GOOS=linux
SET GOARCH=amd64
go build xxxx.go
