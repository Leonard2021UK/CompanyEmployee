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
    
    stage('Copy tagdockerimage script'){
        steps{
                sh "cp /var/tagdockerimage.sh /var/jenkins_home/workspace/CompanyEmployee_master@2"
        }
    }
//     stage('Build') {
//       agent {
//         dockerfile true
//       }
//       steps {
//         echo "done"
//       }
//     }
    stage('Buildv2') {
          agent any
          steps {
          sh "pwd"
            sh "./dockerimagetag.sh rspoto/0635bc6f7262"
          }
        }
//     stage('Rename') {
//           agent any
//           steps {
//             sh "docker image tag 3a0e234df3a4 rspoto/0635bc6f7262"
//           }
//         }
    stage('Docker Push') {
        agent any
        steps {
            withCredentials([usernamePassword(credentialsId: 'dockerHub', passwordVariable: 'dockerHubPassword', usernameVariable: 'dockerHubUser')]) {
                sh "docker login -u ${env.dockerHubUser} -p ${env.dockerHubPassword}"
              sh 'docker push rspoto/0635bc6f7262:latest'
            }
        }
    }
    stage('Docker run') {
        agent any
        steps {
            sh "docker run -d -p 8080:80 --name testapp 3a0e234df3a4"
        }
    }
    
  }
}