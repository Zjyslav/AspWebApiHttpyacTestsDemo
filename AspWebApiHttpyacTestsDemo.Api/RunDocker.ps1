docker build -q -t asp-web-api-httpyac-test-demo:latest -f Dockerfile .. | out-null
docker network create httpyac-test  | out-null

docker run --name httpyac-test-demo-api --network httpyac-test -p 8080:8080 -qd asp-web-api-httpyac-test-demo:latest  | out-null
docker run --name httpyac --network httpyac-test -it -v ${PWD}:/data ghcr.io/anweber/httpyac:latest **/*.http --var host=http://httpyac-test-demo-api:8080 --all

docker container stop httpyac-test-demo-api | out-null

docker container remove httpyac-test-demo-api | out-null
docker container remove httpyac | out-null

docker network remove httpyac-test | out-null