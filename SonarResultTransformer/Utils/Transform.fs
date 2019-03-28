module Utils.Transform

open Model.Sonarqube
open Model.Mattermost
open Utils.Variables


let CreateFieldsFromConditions(condition: Condition) =
    {Short = true; Title = condition.Metric; Value = condition.Status; }

let CreateFields(qualityGate: QualityGate) =
    seq {yield  {Short = false; Title = qualityGate.Name; Value = qualityGate.Status} ; yield! qualityGate.Conditions |> Array.map CreateFieldsFromConditions }


let CreateAttachments(input : SonarqubeResult) : Attachment =
    {
        Title = "This is your result"
        Text = (sprintf "Project %s was analysed at %s. It's result is: %s" input.Project.Name (input.AnalysedAt.ToString "d") input.Status);
        Fields = CreateFields(input.QualityGate) |> Seq.toArray;
    }
    

let Transform (input: SonarqubeResult) : MattermostNotification =
    {
        Channel = GetChannel;
        Username = GetUsername;
        Icon_Url = GetIcon;
        Text = GetText;
        Attachments = [|CreateAttachments(input)|]
    }
