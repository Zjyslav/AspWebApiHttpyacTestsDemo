$startTime = Get-Date
$sinceString = $startTime.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'")
$logsFileName = $startTime.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH'-'mm'-'ss'Z'")
$currentDirectory = Get-Location

docker-compose up --build --abort-on-container-exit

New-Item -ItemType Directory -Force -Path logs\tests | out-null
docker-compose logs --no-color --since $sinceString -t > logs\tests\$logsFileName.txt
echo "Logs saved to $currentDirectory\logs\tests\$logsFileName.txt"

docker-compose down