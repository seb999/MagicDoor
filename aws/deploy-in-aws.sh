#!/bin/bash

cd $(dirname ${0})

sudo rm -rf publish.tmp
sudo rm -rf publish.old
sudo mkdir publish.tmp

#decompress .TAR file
sudo tar xf publish_aws.tar -C publish.tmp

sudo mv publish publish.old
sudo mv publish.tmp publish
#cp secrets/appsettings.json publish/appsettings.json

sudo killall dotnet

#we have to preserve env varioable for root profile
sudo --preserve-env=BINANCE_SECRET_KEY -s supervisord -n