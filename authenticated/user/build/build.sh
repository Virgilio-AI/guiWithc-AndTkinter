#!/usr/bin/sh
# Date: 04/April/2022 - Monday
# Author: Virgilio Murillo Ochoa
# personal github: Virgilio-AI
# linkedin: https://www.linkedin.com/in/virgilio-murillo-ochoa-b29b59203
info=$1
calificaciones=$2
location=$3
echo "info:"
echo $info
echo "calificaciones:"
echo $calificaciones
echo "calificaciones:~~~~~~~\n\n"
python $location "$info" "$calificaciones"
