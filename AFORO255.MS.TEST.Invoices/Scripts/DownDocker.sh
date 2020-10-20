#!/bin/bash
echo ====================================================================
echo Remove publish and docker local images
echo ====================================================================
rm -rf ./publish
docker rmi -f svalenzuelac23/img-invoices
