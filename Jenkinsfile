pipeline {   
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('BuildAndTest') {
            steps {
                bat 'powershell.exe -file ./build.ps1'
            }
        }
    }
    post {
        always {
            deleteDir()
        }
    }
}