pipeline{
    agent none
    stages{
        stage ('Clean workspace') {
            steps {
                cleanWs()
            } 
        }
        stage ('Git Checkout') {
            steps {
                git branch: 'master', credentialsId: 'jenkins ', url: 'https://github.com/Leonard2021UK/CompanyEmployee'
            }
        }
        stage('Test') {
            agent { dockerfile true }
            steps {
               sh 'ls -la'
           }
        }
    }
}