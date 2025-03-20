// Minor update to trigger Jenkins
pipeline {
    agent any

    environment {
        EMAIL_RECIPIENT = "vanshika4823.be23@chitkara.edu.in"
    }

    stages {
        stage('Clone Repository') {
            steps {
                echo "Cloning the GitHub repository..."
                checkout([
                    $class: 'GitSCM',
                    branches: [[name: '*/main']],
                    userRemoteConfigs: [[url: 'https://github.com/Vanshika466/Jenkins-CI-CD.git']]
                ])
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo "Restoring NuGet packages..."
                bat 'dotnet restore'  
            }
        }

        stage('Build') {
            steps {
                echo "Building the .NET application..."
                bat 'dotnet build --configuration Release'  
            }
        }

        stage('Run Unit & Integration Tests') {
            steps {
                echo "Running unit and integration tests..."
                bat 'dotnet test --logger trx'  
            }
            post {
                always {
                    junit '**/*.trx' // Collect test results
                    emailext (
                        subject: "Jenkins Pipeline - Unit and Integration Tests Stage Status",
                        body: "The Unit and Integration Tests stage has completed. Please check Jenkins for details.",
                        to: "$EMAIL_RECIPIENT",
                        attachLog: true
                    )
                }
            }
        }

        stage('Code Analysis') {
            steps {
                echo "Running static code analysis..."
                bat 'dotnet build --configuration Release /p:EnableNETAnalyzers=true'  
            }
        }
    }

    post {
        failure {
            echo "Build failed!"
        }
    }
}
