# VehicleManagementSystem
 New ASP.NET Web API with barebones

## Splunk Integration

we are running the Splunk in the docker

install docker for desktop 

run below 2 commands in cmd

docker pull splunk/splunk

docker run -d -p 8000:8000  -p 8088:8088 -e "SPLUNK_START_ARGS=--accept-license" -e "SPLUNK_PASSWORD=<yourpassword>" --name splunk splunk/splunk:latest

splunk login url http://localhost:8000