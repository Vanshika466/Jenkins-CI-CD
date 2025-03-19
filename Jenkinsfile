pipeline {
    agent any

    environment {
        EMAIL_RECIPIENT = "vanshika4823.be23@chitkara.edu.in"  
    }

    stages {
        stage('Clone Repository') {
            steps {
                echo "Cloning the GitHub repository..."
                checkout scm
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo "Restoring NuGet packages..."
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                echo "Building the .NET application..."
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Run Unit & Integration Tests') {
            steps {
                echo "Running unit and integration tests..."
                sh 'dotnet test --logger trx'
            }
            post {
                always {
                    script {
                        sendEmailNotification('Unit and Integration Tests')
                    }
                }
            }
        }

        stage('Code Analysis') {
            steps {
                echo "Running static code analysis..."
                sh 'dotnet build --configuration Release /p:EnableNETAnalyzers=true'
            }
        }
    }

    post {
        failure {
            echo "Build failed!"
        }
    }
}

// Function to send email notifications
def sendEmailNotification(stageName) {
    emailext (
        subject: "Jenkins Pipeline - ${stageName} Stage Status",
        body: "The ${stageName} stage has completed. Please check Jenkins for details.",
        to: "${env.EMAIL_RECIPIENT}",
        attachLog: true
    )
}
