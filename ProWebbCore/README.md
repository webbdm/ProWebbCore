# AWS

Use this to authenticate with AWS CLI V2 and docker to push images to the ECR

 ```docker login -u AWS -p $(aws ecr get-login-password --region the-region-you-are-in) xxxxxxxxx.dkr.ecr.the-region-you-are-in.amazonaws.com```
 
