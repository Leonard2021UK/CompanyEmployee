pipeline {
  agent any
  stages {
    stage('Clean workspace') {
        agent any
      steps {
        cleanWs()
      }
    }

    stage('Git Checkout') {
      steps {
        git(branch: 'master', credentialsId: 'jenkins ', url: 'https://github.com/Leonard2021UK/CompanyEmployee')
      }
    }

    stage('Build') {
      agent {
        dockerfile true
      }
      steps {
        echo "done"
      }
    }
    
    stage('Test') {
      steps {
        sh 'docker run --entrypoint=dotnet CompanyEmployee.dll 7bdd'
        bash 'dotnet CompanyEmployee.dll'
      }
    }
  }
}