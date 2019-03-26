namespace SonarResultTransformer.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc

open FSharp.Data
open Newtonsoft.Json
open FSharp.Data.HttpRequestHeaders
open Model.Sonarqube
open Utils.Transform

[<Route("api/[controller]")>]
[<ApiController>]
type MattermostController () =
    inherit ControllerBase()

    [<HttpPost>]
    member this.Post([<FromBody>] value: SonarqubeResult) =
        let obj = value |> Transform |> JsonConvert.SerializeObject

        let result = Http.RequestString ("http://requestbin.fullcontact.com/twz9eptx",
                                         headers = [ ContentType  HttpContentTypes.Json],
                                         body = TextRequest obj)
        result
