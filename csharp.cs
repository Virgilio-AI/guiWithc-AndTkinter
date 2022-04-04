using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
// in the terminal use:
// nuget install Newtonsoft.Json
// copy the dll into the same folder
// then create a sh file that contains

//mcs -reference:Newtonsoft.Json.dll program.cs
//mono program.exe

//using System;
//using System.IO;
//using Newtonsoft.Json;
//
//using (StreamReader r = new StreamReader("test.json"))
//{
//	string json = r.ReadToEnd();
//	dynamic array = JsonConvert.DeserializeObject(json);
//	foreach(var item in array)
//	{
//		//				foreach(var subitem in item)
//		//				{
//		//					Console.WriteLine(subitem);
//		//				}
//		Console.WriteLine(item);
//		//				Console.WriteLine("{0} {1}", item.Firstname, item.Lastname);
//		Console.WriteLine("-------");
//	}




class csharp {
	public static bool checkIfJson(string FileName)
	{
		if(File.Exists(FileName + ".json"))
		{
			return true;
		}
		return false;
	}

	public static dynamic ReadJsonFile(string FileName)
	{
		using (StreamReader r = new StreamReader(FileName +".json"))
		{
			string json = r.ReadToEnd();
			dynamic array = JsonConvert.DeserializeObject(json);
			return array;
		}
	}

	public static void FactoryReadFile(string FileName)
	{
		checkIfJson(FileName);
		if(checkIfJson(FileName))
		{
			ReadJsonFile(FileName);
		}
		// here you can add code to red file from different file formats
	}

	public static string[] getUserPassword()
	{

		Process proc = new Process {
			StartInfo = new ProcessStartInfo {
				FileName = "/usr/bin/sh",
							Arguments = "command.sh",
							UseShellExecute = false,
							RedirectStandardOutput = true,
							CreateNoWindow = true
			}
		};

		proc.Start();

		string line = "error,error";
		while (!proc.StandardOutput.EndOfStream) {
			line = proc.StandardOutput.ReadLine();
			string[] ans = line.Split(',');

			if(ans.Length == 2)
			{
				return ans;
			}
			// do something with line
		}
		string error = "error,error";
		string[] ansi = error.Split(',');
		return ansi;
	}



	static void Main() {
		string[] userPassword = getUserPassword();
		Console.Write("user:" + userPassword[0]);
		Console.Write("password:" + userPassword[1]);

		// leer usuario y contraseña
		// autenticar usuario
		// entrar a la pagina

		string nameOfFile = "datos";
		FactoryReadFile(nameOfFile);
	}
}
