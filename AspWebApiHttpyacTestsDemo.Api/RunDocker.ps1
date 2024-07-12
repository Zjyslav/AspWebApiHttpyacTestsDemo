docker build -q -t asp-web-api-httpyac-test-demo:latest -f Dockerfile .. | Out-Null
docker network create httpyac-test | Out-Null

docker run --name api --network httpyac-test -qd -e ASPNETCORE_HTTPS_PORTS=8081 -e ASPNETCORE_Kestrel__Certificates__Default__Password="Zjyslav19" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v "$env:USERPROFILE/.aspnet/https:/https/" asp-web-api-httpyac-test-demo:latest | Out-Null
docker run --name httpyac --network httpyac-test -it -v ${PWD}:/data ghcr.io/anweber/httpyac:latest **/*.http --all --insecure

docker container stop api | Out-Null

docker container remove api | Out-Null
docker container remove httpyac | Out-Null

docker network remove httpyac-test | Out-Null