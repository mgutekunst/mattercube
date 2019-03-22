namespace SonarResultTransformer.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open FSharp.Data


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

[<Route("api/[controller]")>]
[<ApiController>]
type ValuesController () =
    inherit ControllerBase()

    [<HttpPost>]
    member this.Post([<FromBody>] value:SolarWindsResult) =
        ActionResult<SolarWindsResult>(value)
