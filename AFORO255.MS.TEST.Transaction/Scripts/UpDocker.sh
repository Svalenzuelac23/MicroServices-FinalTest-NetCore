﻿#!/bin/bash
echo ====================================================================
echo Release, build and push
echo ====================================================================
dotnet publish -c release -o ./publish
docker build -t svalenzuelac23/img-transaction -f Scripts/Dockerfile .
docker push svalenzuelac23/img-transaction