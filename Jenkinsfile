pipeline {
    agent any
    environment {
                EMAIL = 'priyanka4800.be23@chitkara.edu.in'
    }
    stages {
        stage('Build') {
            steps {
              echo "Step: Building the .NET application."
                echo "Tool: .NET SDK"
                echo "Command: Use 'dotnet build --configuration Release' to compile the code."

            }
        }
        stage('Unit and Integration Tests') {
            steps {
               echo "Step: Running unit and integration tests."
                echo "Tool: xUnit, NUnit, MSTest"
                echo "Command: Use 'dotnet test --logger trx' to execute tests and generate logs."

            }
        }
        stage('Code Analysis') {
            steps {
                echo "Step: Running static code analysis."
                echo "Tool: .NET Analyzers, SonarQube, ReSharper"
                echo "Command: Use 'dotnet build --configuration Release /p:EnableNETAnalyzers=true' or integrate with SonarQube."

            }
        }
        stage('Security Scan') {
            steps {
                echo "Step: Performing security scan using SonarQube..."
                echo "Tool: SonarQube, Snyk, OWASP Dependency-Check"
                echo "Command: Use 'sonar-scanner' to analyze the code for vulnerabilities."
            }
        }
        stage('Deploy to Staging') {
            steps {
                echo "Step: Deploying to staging server."
                echo "Environment: AWS EC2 instance"
                echo "Command: Use 'scp' or a deployment tool like Ansible/Terraform to deploy."
            }
        }
        stage('Integration Tests on Staging') {
            steps {
                echo "Step: Running integration tests on staging environment."
                echo "Tool: Selenium, Postman, JMeter"
                echo "Command: Use automated testing scripts to validate deployment."
            }
        }
        stage('Deploy to Production') {
            steps {
                echo "Step: Deploying to production server."
                echo "Environment: AWS EC2 instance"
                echo "Command: Use 'scp', Kubernetes, or Docker for deployment."
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
