pipeline {   
    agent any

    stages {
        stage('BuildAndTest') {
            steps {
                checkout scm
                bat 'powershell.exe -file ./build.ps1'
            }
        }
    }
}