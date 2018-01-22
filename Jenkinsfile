pipeline {   
    agent any

    stages {
        stage('BuildAndTest') {
            steps {
                checkout scm
                powershell './build.ps1'
            }
        }
    }
}