// Minor update to trigger Jenkins
pipeline {
    agent any

    environment {
        EMAIL_RECIPIENT = "vanshika4823.be23@chitkara.edu.in"
    }

    stages {
        stage('Clone Repository') {
            steps {
                echo "Step: Cloning the GitHub repository."
                echo "Tool: Git"
                echo "Command: Use 'git clone' or Jenkins' built-in 'checkout' step"
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo "Step: Restoring project dependencies."
                echo "Tool: NuGet (for .NET projects)"
                echo "Command: Use 'dotnet restore' to fetch required packages."
            }
        }

        stage('Build') {
            steps {
                echo "Step: Building the .NET application."
                echo "Tool: .NET SDK"
                echo "Command: Use 'dotnet build --configuration Release' to compile the code."
            }
        }

        stage('Run Unit & Integration Tests') {
            steps {
                echo "Step: Running unit and integration tests."
                echo "Tool: xUnit, NUnit, MSTest"
                echo "Command: Use 'dotnet test --logger trx' to execute tests and generate logs."
            }
            post {
                always {
                    echo "Step: Collecting and publishing test results."
                    echo "Tool: Jenkins JUnit plugin"
                    echo "Command: Use 'junit **/*.trx' to process test reports."
                    
                    echo "Step: Sending notification email."
                    echo "Tool: Jenkins Email Extension Plugin"
                    echo "Configuration: Set up 'emailext' in Jenkins to send test results."

                    mail (
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
                echo "Step: Running static code analysis."
                echo "Tool: .NET Analyzers, SonarQube, ReSharper"
                echo "Command: Use 'dotnet build --configuration Release /p:EnableNETAnalyzers=true' or integrate with SonarQube."
            }
        }
    }

    post {
        failure {
            echo "Step: Handling build failures."
            echo "Possible Actions: Check logs, fix errors, retry the pipeline."
        }
    }
}
