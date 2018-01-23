pipeline {   
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
                echo "branch: ${env.BRANCH_NAME}"
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