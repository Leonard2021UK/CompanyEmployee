pipeline {  
    agent any  
    environment {  
        dotnet = 'C:\\Program Files\\dotnet\\dotnet.exe'  
    }  
    stages {  
        stage('Clean workspace') {
            agent any
            steps {
                cleanWs()
            }
        }
        stage('Checkout') {  
           steps {
               git credentialsId: 'aee7d65a-33a7-4616-ab5e-4a1598289b1b', url: 'https://github.com/mahedee/code-sample02.git', branch: 'main'
           }  
        }  
        stage('Build') {  
            steps {  
                bat 'dotnet build %WORKSPACE%\\jenkins-demo\\HRM\\HRM.sln --configuration Release' 
                //bat 'dotnet build C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\HRMPipelines\\jenkins-demo\\HRM\\HRM.sln --configuration Release'  
            }  
        }  
        stage('Test') {  
            steps {  
                bat 'dotnet test %WORKSPACE%\\jenkins-demo\\HRM\\HRM.Test\\HRM.Test.csproj --logger:trx'  
            }  
        }
        stage("Release"){
            steps {
                bat 'dotnet build  %WORKSPACE%\\jenkins-demo\\HRM\\HRM.sln /p:PublishProfile=" %WORKSPACE%\\jenkins-demo\\HRM\\HRM.API\\Properties\\PublishProfiles\\JenkinsProfile.pubxml" /p:Platform="Any CPU" /p:DeployOnBuild=true /m'
            }
        }
        stage('Deploy') {
            steps {
                // Stop IIS
                bat 'net stop "w3svc"'
            
                // Deploy package to IIS
                bat '"C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:package="%WORKSPACE%\\jenkins-demo\\HRM\\HRM.API\\bin\\Debug\\net6.0\\HRM.API.zip" -dest:auto -setParam:"IIS Web Application Name"="HRM.Web" -skip:objectName=filePath,absolutePath=".\\\\PackageTmp\\\\Web.config$" -enableRule:DoNotDelete -allowUntrusted=true'
            
                // Start IIS again
                bat 'net start "w3svc"'
            }
        }
    }
}  