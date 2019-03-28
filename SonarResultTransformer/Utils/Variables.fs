module Utils.Variables

open System

let GetEnvVariable name =
    Environment.GetEnvironmentVariable name

let GetChannel = GetEnvVariable "CHANNEL"
let GetIcon = GetEnvVariable "ICON_URL"
let GetUsername = GetEnvVariable "USERNAME"
let GetText = GetEnvVariable "TEXT"
let GetHookUrl = GetEnvVariable "HOOK_URL"

