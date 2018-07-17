# Sample Call

Start the solution in Visual Studio and the API should start on localhost port 2837
Use a sample call like below
http://localhost:2837/flights/availability?startDate=2018-07-01T00:00:00&endDate=2018-09-01T23:59:59&numberOfPassengers=8

startDate and endDate should be in ISO8601 format (local, not UTC)

The SampleCalls folder contains files with samples commands you can use to test the API when running on your localhost. The commands are curl commands that can be run in a windows command prompt.