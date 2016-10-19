#! /bin/sh

currentBuildImage=$(docker images buildimage -q)

rsync -R src/**/project.json test/**/project.json ./tmp

docker build -t buildimage -f Dockerfile.build .

if [ -n "$currentBuildImage" ]; then
    docker rmi $currentBuildImage
fi

rm -r tmp

docker create --name build-container buildimage

rm -r ./src/MyAPI/bin
docker cp build-container:/sln/src/MyAPI/bin ./src/MyAPI/bin

docker rm build-container

docker-compose down
docker-compose build

docker-compose run integrationContainer dotnet test