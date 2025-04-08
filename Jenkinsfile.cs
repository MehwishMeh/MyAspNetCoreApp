pipeline {
         agent any
         environment {
             DOCKERHUB_CREDENTIALS = credentials('dockerHubCredentialsId')
         }
         stages {
             stage('Checkout') {
                 steps {
                     git 'https://dev.azure.com/mmehmoo5/MyAspNetCoreApp/_git/MyAspNetCoreApp'
                 }
             }
             stage('Build Maven Project') {
    steps {
        sh 'mvn clean package'
                 }
}
stage('Docker Login') {
    steps {
        sh 'echo $DOCKERHUB_CREDENTIALS | docker login -u your-dockerhub-username --password-stdin'
                 }
}
stage('Docker Build') {
    steps {
        sh 'docker build -t your-dockerhub-username/my-app:latest .'
                 }
}
stage('Docker Push') {
    steps {
        sh 'docker push your-dockerhub-username/my-app:latest'
                 }
}
         }
     }