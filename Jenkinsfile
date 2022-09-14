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

    stage('Build & test project') {
      agent {
        dockerfile true
      }
      steps {
        sh 'ls -la'
        sh 'cat /etc/hostname'
      }
    }
  }
}