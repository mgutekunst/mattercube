module Model.Sonarqube

open System

type Project = {
    Key: string;
    Name: string
}
type Condition = {
    Metric: string;
    Status: string
}

type QualityGate = {
    Conditions: Condition[];
    Name: string;
    Status: string
}

type SonarqubeResult = {
    AnalysedAt: DateTime;
    Project: Project;
    QualityGate: QualityGate;
    ServerUrl: string;
    Status: string;
    TaskId: string
}
