using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;


using Newtonsoft.Json;
class csharp {
	public static string FileName = "datos";
	public static string shLocation = "/usr/bin/sh";

	public static bool checkIfJson()
	{
		if(File.Exists(FileName + ".json"))
		{
			return true;
		}
		return false;
	}

	public static dynamic ReadJsonFile()
	{
		using (StreamReader r = new StreamReader(FileName +".json"))
		{
			string json = r.ReadToEnd();
			dynamic array = JsonConvert.DeserializeObject(json);
			return array;
		}
	}

	public static dynamic FactoryReadFile()
	{
		dynamic ans = new System.Dynamic.ExpandoObject();
		if(checkIfJson())
		{
			ans = ReadJsonFile();
		}

		// here you can add code to red file from different file formats
		return ans;
	}

	public static Process executeShFile(string pathToFile,string arguments,string locationOfShExe)
	{
		string targuments = pathToFile + " " + arguments ;
		Console.Write("\n\n the arguments: " + targuments + "\n\n");

		Process proc = new Process {
			StartInfo = new ProcessStartInfo {
				FileName = locationOfShExe,
							Arguments = pathToFile + " " + arguments,
							UseShellExecute = false,
							RedirectStandardOutput = true,
							CreateNoWindow = true
			}
		};
		return proc;
	}
	public static string[] getUserPassword(bool contraseñaIncorrecta)
	{
		string nameOfshFile = "Login.sh";
		string argument = "0";
		if(contraseñaIncorrecta)
		{
			argument =  "1";
		}
		Process proc = executeShFile(nameOfshFile,argument,"/usr/bin/sh");


		proc.Start();

		string line = "error,error";
		while (!proc.StandardOutput.EndOfStream) {
			line = proc.StandardOutput.ReadLine();
			string[] ans = line.Split(',');

			//Console.Write(ans[0]);
			//Console.Write(ans[1]);
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

	public static bool checarExistenciaDeUsuario(string usuario,string password)
	{
		dynamic array = FactoryReadFile();
		foreach(var item in array)
		{
			foreach(var user in item)
			{
				// Console.Write(user);
				if(user.name == usuario && user.password == password)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static dynamic getUserAsObject(string usuario)
	{
		dynamic array = FactoryReadFile();
		foreach(var item in array)
		{
			foreach(var user in item)
			{
				Console.Write(user.name);
				Console.Write(user.type);
				//Console.Write(user);
				if(user.name == usuario)
				{
					return user;
				}
			}
		}
		return array;
	}

	public static dynamic autenticaUsuario()
	{
		bool incorrecto = false;
		string user = "";
		do{
			string[] userPassword = getUserPassword(incorrecto);
			user = userPassword[0];
			string password = userPassword[1];
			bool correcto = checarExistenciaDeUsuario(user,password);
			incorrecto = !correcto;
		}while(incorrecto == true);
		dynamic duser = getUserAsObject(user);
		Console.Write("duser" + duser.name);
		return duser;
	}
	public static void accederestudiante(dynamic user)
	{
		string arguments = "\"";
		arguments += user.name + "," + user.nombreCompleto + "," + user.carrera + "," + user.nacimiento + "," + user.ciudad ;
		arguments  += "\"";
		Console.Write(arguments);
		Console.Write(user.calificaciones);

		arguments += " \"";
		int cont = 1;
		foreach(var cal in user.calificaciones)
		{
			string ansi = "";
			foreach(var val in cal)
			{
//				if(val == ":")
//				{
//					ansi+=",";
//				}
//				else if(val == " ")
//				{
//					ansi+="";
//				}
//				else
//				{
//					ansi+=val;
//				}
			}
			ansi += cal.Name + "," + cal.Value;
			arguments+=ansi + ",";
		}
		arguments = arguments.Remove(arguments.Length-1,1);
		arguments += "\"";

		arguments += " authenticated/user/build/gui.py";
		Console.Write(arguments);
		Process proc = executeShFile("authenticated/user/build/build.sh",arguments,shLocation);
		proc.Start();


		string line = "error,error";
		while (!proc.StandardOutput.EndOfStream) {
			line = proc.StandardOutput.ReadLine();
			Console.Write(line);
			string[] ans = line.Split(',');

			//Console.Write(ans[0]);
			//Console.Write(ans[1]);

//			if(ans[0] == "descargar")
//			{
//				Console.Write("Descargar archivo");
//			}

			// do something with line
		}
	}
	public static void accederAdmin(dynamic user)
	{
	}
	public static void accedermaestro(dynamic user)
	{
	}
	public static void acceder(dynamic user)
	{
		// Console.Write("----------\n");
		// Console.Write(user);
		// Console.Write("----------\n");

		//Console.Write(user);
		Console.Write("\nacceder:" + user.type);
		// Console.Write(user.type);
		if(user.type == "student")
		{
			//Console.Write("es un estudiante");
			accederestudiante(user);
		}
		if(user.type == "admin")
		{
			accederAdmin(user);
		}
		if(user.type == "teacher")
		{
			accedermaestro(user);
		}
	}

	static void Main() {


		// obtener el usuario
		dynamic usuario = autenticaUsuario();
		Console.Write("main:" + usuario.type);

		acceder(usuario);

		// leer usuario y contraseña
		// autenticar usuario
		// entrar a la pagina
	}
}

