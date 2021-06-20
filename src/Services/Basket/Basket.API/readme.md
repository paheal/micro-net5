## Docker Dependency for Redis



**To Pull Redis image**  
docker pull redis

**To run for project**  
docker run -d -p 6379:6379 --name aspnetrun-redis redis

**To view logs**  
docker logs aspnetrun-redis

**To launch interactive terminal**  
docker exec -it aspnetrun-redis /bin/bash

**Start cli in interactive terminal**  
redis-cli

**redis command -> returns**  
ping "Hello" -> "Hello"  
set key value -> OK  
get key -> "value"  
set id "Test Value" -> OK
get id -> "Test Value"