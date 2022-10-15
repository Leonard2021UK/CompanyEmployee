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
               git credentialsId: 'd5ec799a-dd4d-4269-9203-1a4922b04500', url: 'https://github.com/Leonard2021UK/CompanyEmployee.git', branch: 'master'
           }  
        }  
        stage('Build stage') {  
            steps {  
                bat 'dotnet build %WORKSPACE%\\CompanyEmployee.sln --configuration Release' 
                //bat 'dotnet build C:\\ProgramData\\Jenkins\\.jenkins\\workspace\\HRMPipelines\\jenkins-demo\\HRM\\HRM.sln --configuration Release'  
            }  
        }  
        stage('Test') {  
            steps {  
                bat 'dotnet test %WORKSPACE%\\CompanyEmployeeTest\\CompanyEmployeeTest.csproj --logger:trx'  
            }  
        }
        stage("Release"){
            steps {
                bat 'dotnet publish %WORKSPACE%\\CompanyEmployee\\CompanyEmployee.csproj /p:PublishProfile=%WORKSPACE%\\CompanyEmployee\\Properties\\PublishProfiles\\JenkinsProfile.pubxml'
            }
        }
        stage('Deploy') {
            steps {
                // Stop IIS
                bat 'net stop "w3svc"'
            
                // Deploy package to IIS
                bat '"C:\\Program Files\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:iisApp=%WORKSPACE%\\CompanyEmployee\\bin\\Release\\net6.0\\publish\\win-x64 -dest:iisApp=C:\\inetpub\\CompanyEmployee > web.log -skip:objectName=filePath,absolutePath=.\\\\PackageTmp\\\\Web.config$ -allowUntrusted=true'

                // Start IIS again
                bat 'net start "w3svc"'
            }
        }
        
    }
}  