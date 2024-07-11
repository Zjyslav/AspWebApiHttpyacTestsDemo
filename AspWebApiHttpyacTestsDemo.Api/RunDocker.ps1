docker build -t asp-web-api-httpyac-test-demo:latest -f Dockerfile ..
docker run --name httpyac-test-demo -p 1980:8080 -p 1981:8081 -d asp-web-api-httpyac-test-demo:latest