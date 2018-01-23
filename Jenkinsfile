pipeline {   
    agent any

    stages {
        stage('Checkout'){
          checkout scm
        }
        stage('BuildAndTest') {
            steps {
                bat 'powershell.exe -file ./build.ps1'
            }
        }
    }
}