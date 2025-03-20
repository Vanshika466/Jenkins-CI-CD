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
                bat 'dotnet restore'  // Changed from 'sh' to 'bat'
            }
        }

        stage('Build') {
            steps {
                echo "Building the .NET application..."
                bat 'dotnet build --configuration Release'  // Changed from 'sh' to 'bat'
            }
        }

        stage('Run Unit & Integration Tests') {
            steps {
                echo "Running unit and integration tests..."
                bat 'dotnet test --logger trx'  // Changed from 'sh' to 'bat'
            }
            post {
                always {
                    mail (
                        subject: "Jenkins Pipeline - Unit and Integration Tests Stage Status",
                        body: "The Unit and Integration Tests stage has completed. Please check Jenkins for details.",
                        to: "${env.EMAIL_RECIPIENT}",
                        attachLog: true
                    )
                }
            }
        }

        stage('Code Analysis') {
            steps {
                echo "Running static code analysis..."
                bat 'dotnet build --configuration Release /p:EnableNETAnalyzers=true'  // Changed from 'sh' to 'bat'
            }
        }
    }

    post {
        failure {
            echo "Build failed!"
        }
    }
}
