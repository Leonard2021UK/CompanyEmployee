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
stage('Restore packages') {
    steps {
      bat "dotnet restore ${workspace}/CompanyEmployee/CompanyEmployee.sln"
    }
}
stage('Clean') {
  steps {
    bat "msbuild.exe ${workspace}\\<path-to-solution\\<solution-project-name>.sln" /nologo /nr:false /p:platform=\"x64\" /p:configuration=\"release\" /t:clean"
  }
}