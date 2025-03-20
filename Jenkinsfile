pipeline {
    agent any
    environment {
                EMAIL = 'vanshika4823.be23@chitkara.edu.in'
    }
    stages {
        stage('Build') {
            steps {
                echo 'Building the project...'
                //sh 'npm install'
            }
        }
        stage('Unit and Integration Tests') {
            steps {
                echo 'Running unit tests...'
                //sh 'npm test || exit 1'
            }
        }
        stage('Code Analysis') {
            steps {
                echo 'Performing code analysis...'
                //sh 'npm run lint || exit 1'
            }
        }
        stage('Security Scan') {
            steps {
                echo 'Running SonarQube Security Scan...'
            }
        }
        stage('Deploy to Staging') {
            steps {
                echo 'Deploying to Staging...'
            }
        }
        stage('Integration Tests on Staging') {
            steps {
                echo 'Running integration tests on staging...'
            }
        }
        stage('Deploy to Production') {
            steps {
                echo 'Deploying to Production...'
            }
        }
    }
    post {
        always {
            
                mail (
                    subject: "Jenkins Pipeline Execution",
                    body: "Pipeline execution complete. Check Jenkins for details...",
                    to: "${EMAIL}"
                )
            
        }
    }
}
