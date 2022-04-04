# guiWithc-AndTkinter
This is a school prokect for design pattern algoritms and is meant to be runed in linux or macos

# first git clone this repo into your local machine 
git clone https://github.com/Virgilio-AI/guiWithc-AndTkinter.git guiTkinter

# cd into the dir
cd guiTkinter

# run the program
sh run.sh



# to configure the program at the beggining of the file csharp.cs there are the global variables

## the name of the json file
## deafault
FileName = "datos";

## the location for the sh exe, in linux is
shLocation="/usr/bin/sh";



# screenshots

![image](https://user-images.githubusercontent.com/59902976/161639305-2e9661b4-68b4-424d-95b6-cc81dbbb0edd.png)
![image](https://user-images.githubusercontent.com/59902976/161639325-992ffb4a-2f47-40a7-bb31-e2a1504e5348.png)


# structural patterns 
el patron de diseño estructural usado primordialmente es el adapter ya que nosotros damos la señal de que queremos ejecutar codigo en python. pero hacerlo directamente 
desde c# es muy complicado con versiones actualizadas de python. asi que llamamos un script de sh para ejecutar el codigo de python.( que es lo que nos va a dar la gui)

# patrones creacionales
el patron creacional que use fue el factory ya que es aplicado en muchas funciones que para reducir la complejiadad llamamos a travez de una interfaz

ejemplo:
la funcion acceder se le es pasado un argumento de tipo usuario
![image](https://user-images.githubusercontent.com/59902976/161639997-cd34e12d-3e2d-4e84-86e3-f82a35ea317f.png)


y dentro de la funcion acceder se elabora en llamar a la funcion requerida dependiendo de el tipo de usuario que se esta identificando
![image](https://user-images.githubusercontent.com/59902976/161640120-495d4071-d0dd-410b-bd22-2039b56616b9.png)
