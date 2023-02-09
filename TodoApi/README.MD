Simple TODO api that uses in memory db. Can be tested with http-repl tool.
API: https://localhost:7021/api/todoitems
Swagger: https://localhost:7021/swagger/index.html

For port nbr, see launchSettings.json


http-repl tool
------------------------------------------------------------------------------------------------------------------
* install: dotnet tool install -g Microsoft.dotnet-httprepl
* https://learn.microsoft.com/en-us/aspnet/core/web-api/http-repl/?view=aspnetcore-7.0&tabs=windows


commands:
# 1. open tool
httprepl

# 2. connect to api
connect https://localhost:7021/api/todoitems

# 3. make todo post request
post -h Content-Type=application/json -c "{"name":"walk dog","isComplete":true}"

# 4. get todo's
get

# 5. put request
put -h Content-Type=application/json -c "{"id":1,"name":"feed fish","isComplete":true}"

# 6. delete todo
delete

# 7. close session
exit