rm csharp.exe
mcs -reference:Newtonsoft.Json.dll csharp.cs
mono csharp.exe

