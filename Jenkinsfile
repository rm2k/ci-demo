pipeline {   
    agent any

    stages {
        stage('BuildAndTest') {
            steps {
                checkout scm
                './build.ps1'
            }
        }
    }
}