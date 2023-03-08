#!/bin/bash

cd $(dirname ${0})/..

rm -rf publish_aws publish_aws.tar
dotnet publish -o publish_aws --configuration release

#compressed to a tar file
tar cf publish_aws.tar -C publish_aws .

#copy the .TAR to the target server and call deploy script
scp publish_aws.tar aws/deploy-in-aws.sh ec2-user@ec2-13-48-2-168.eu-north-1.compute.amazonaws.com:
ssh sebastien.dubos@gmail.com@192.168.1.97 "./deploy-in-aws.sh"

#clean 
#rm -rf publish_aws publish_aws.tar

#chmod u+x deploy-in-aws.sh I did that on the server the first time 