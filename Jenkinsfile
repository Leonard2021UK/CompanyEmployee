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
        sh "docker image tag CompanyEmployee 2ab9d04e41264e80606551255f285ba254573c01:latest"
      }
    }
    stage('Docker Push') {
        agent any
        steps {
            withCredentials([usernamePassword(credentialsId: 'dockerHub', passwordVariable: 'dockerHubPassword', usernameVariable: 'dockerHubUser')]) {
                sh "docker login -u ${env.dockerHubUser} -p ${env.dockerHubPassword}"
              sh 'docker push rspoto/3a0e234df3a4:latest'
            }
        }
    }
  }
}