namespace SonarResultTransformer.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc

open FSharp.Data
open Newtonsoft.Json
open FSharp.Data.HttpRequestHeaders


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

type SolarWindsResult = {
    AnalysedAt: DateTime;
    Project: Project;
    ServerUrl: string;
    Status: string;
    TaskId: string
    }

type Field = {
    Short: bool;
    Title: string;
    Value: string;
    }

type Attachment = {
    Fields: Field[]
    }

type MattermostNotification = {
    Channel: string;
    Username: string;
    Icon_Url: string;
    Text: string;
    Attachments: Attachment[];

    }

[<Route("api/[controller]")>]
[<ApiController>]
type ValuesController () =
    inherit ControllerBase()

    [<HttpPost>]
    member this.Post([<FromBody>] value:SolarWindsResult) =
        let obj = JsonConvert.SerializeObject(value)
        let result = Http.RequestString ("http://requestbin.fullcontact.com/1c9ymib1",
                                         headers = [ ContentType  HttpContentTypes.Json],
                                         body = TextRequest obj)
        ActionResult<SolarWindsResult>(value)
