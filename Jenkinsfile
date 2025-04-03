pipeline {
    agent any
    environment {
                EMAIL = 'vanshika4823.be23@chitkara.edu.in'
    }
    stages {
        stage('Build') {
            steps {
              echo "Step: Building the .NET application."
                echo "Tool: .NET SDK, MSBuild"

            }
        }
        stage('Unit and Integration Tests') {
            steps {
               echo "Step: Running unit and integration tests."
                echo "Tool: xUnit, NUnit, MSTest"
        
            }
        }
        stage('Code Analysis') {
            steps {
                echo "Step: Running static code analysis."
                echo "Tool: .NET Analyzers, SonarQube, ReSharper"

            }
        }
        stage('Security Scan') {
            steps {
                echo "Step: Performing security scan using SonarQube..."
                echo "Tool: SonarQube, Snyk, OWASP Dependency-Check"
            }
        }
        stage('Deploy to Staging') {
            steps {
                echo "Step: Deploying to staging server."
                echo "Environment: AWS EC2 instance"
                echo "Tools: Ansible,Terraform,Docker"
            }
        }
        stage('Integration Tests on Staging') {
            steps {
                echo "Step: Running integration tests on staging environment."
                echo "Tool: Selenium, Postman, JMeter"
            }
        }
        stage('Deploy to Production') {
            steps {
                echo "Step: Deploying to production server."
                echo "Environment: AWS EC2 instance"
                echo "Tools: 'scp', Kubernetes, or Docker for deployment."
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
