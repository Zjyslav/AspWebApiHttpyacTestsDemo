# ASP.NET Web API httpYac tests Demo
[![Run API tests using Docker Compose](https://github.com/Zjyslav/AspWebApiHttpyacTestsDemo/actions/workflows/test-api.yml/badge.svg)](https://github.com/Zjyslav/AspWebApiHttpyacTestsDemo/actions/workflows/test-api.yml)  
This is a demo of running automated API tests using .http files and [httpYac](https://httpyac.github.io/) in Docker containers.

## Powershell scripts
I started with running this setup locally.
- [CreateDevCert.ps1](AspWebApiHttpyacTestsDemo.Api/CreateDevCert.ps1) creates dev certs used to run https in API
- [RunDocker.ps1](AspWebApiHttpyacTestsDemo.Api/RunDocker.ps1) starts containers individually and runs the tests
- [RunHttpyacTestsWithDockerCompose.ps1](AspWebApiHttpyacTestsDemo.Api/RunHttpyacTestsWithDockerCompose.ps1) starts containers using docker-compose, runs the tests and saves logs to a .txt file.

## Github Actions
When I had a working setup, I moved it to Github Actions
- [test-api.yml](.github/workflows/test-api.yml)

## Things to improve
I'm generating dev-certs to use https in API, but for the tests, I tell httpYac to accept insecure connections. However, if I used a different program that wouldn't accept insecure https, I'd have to run a few more commands to trust the certs. It's likely I'd have to change the way I generate them.  
If I ever have to go down that way, [this repo](https://github.com/BorisWilhelms/create-dotnet-devcert/tree/main) looks like it could be useful.
