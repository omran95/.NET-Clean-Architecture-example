
set -e

SERVER="identity-db";
PW="mysecretpassword";

echo "echo stop & remove old docker [$SERVER] and starting new fresh instance of [$SERVER]"
(docker kill $SERVER || :) && \
  (docker rm $SERVER || :) && \
  docker run --name $SERVER -e POSTGRES_PASSWORD=$PW \
  -e PGPASSWORD=$PW \
  -p 5432:5432 \
  --restart=always \
  -d postgres


# wait for pg to start
echo "sleep wait for pg-server [$SERVER] to start";
SLEEP 3;