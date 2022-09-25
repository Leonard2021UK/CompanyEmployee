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
    stage('Docker Push') {
        	agent any
          steps {
          	withCredentials([usernamePassword(credentialsId: 'dockerHub', passwordVariable: 'dockerHubPassword', usernameVariable: 'dockerHubUser')]) {
            	sh "docker login -u ${env.dockerHubUser} -p ${env.dockerHubPassword}"
              sh 'docker push 0635bc6f7262:latest'
            }
          }
        }
  }
}