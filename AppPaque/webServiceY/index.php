<?php
//no bloquee el contenido
if (isset($_SERVER['HTTP_ORIGIN']))
{
    header("Access-Control-Allow-Origin: {$_SERVER['HTTP_ORIGIN']}");
    header('Access-Control-Allow-Credentials:true');
    header('Access-Control-Max-Age:86400'); //cache por un dia 
}

//ESTABLECE FORMATO DE ENTRADA PARA APPLICATION/JSON
if(strcasecmp($_SERVER['REQUEST_METHOD'],'POST') != 0)
{
    throw new Exception("EL METODO DEBERIA SER POST");
}

//Establece que el formato de entrada será application/json
$contentType = isset($_SERVER["CONTENT_TYPE"]) ? trim($_SERVER["CONTENT_TYPE"]) : '';
if(strcasecmp($contentType, 'application/json') != 0){
    throw new Exception('Content type must be: application/json');
}


//RECIBE EL RAW
$content = trim(file_get_contents("php://input"));

//transdorma el raw json a php
$decoded = json_decode($content,true); //guarda la peticion

$message = array(); //guardar las respuestas

require 'Config/Conexion.php';
require 'API/apiTest.php';

$miApi = new Consultas();

//tratar la peticion
switch ($decoded['action']) {
    //
    case "InsertarDatosR":
        $data = $miApi->InsertarDatosRas($decoded['idGuia'],$decoded['Fecha'],$decoded['Latitud'],$decoded['Longitud'],$decoded['idEmpleado']);
        $message = $data;
    break;
    //
    case "DatosG":
        $data = $miApi->ObtenerGuias();
        $message = $data;
    break;
    //Aqui
    case "IdEmpleados":
        $data = $miApi->ObtenerIdEmpleados();
        $message = $data;
    break;
    //

    case "generos":
            if(is_array($data = $miApi->consultarGenero())) //VERIFICA QUE ES UN ARREGLO, ES DECIR QUE LA CONSULTA DEVUELVA RESULTADOS
            {
                $message = $data;
            }
            else
            {
                $message["message"] = "ERROR EN LA ACCION CANCIONES.";
            }
        break;
        
    case "cancionesPorGenero":
            if(is_array($data = $miApi->consultarCancionesPorGenero())) //VERIFICA QUE ES UN ARREGLO, ES DECIR QUE LA CONSULTA DEVUELVA RESULTADOS
            {
                $message = $data;
            }
            else
            {
                $message["message"] = "ERROR EN LA ACCION CANCIONES.";
            }
        break;
        
    case "cancionesPorGeneroFiltrado":
            if(is_array($data = $miApi->consultarCancionesPorGeneroFiltrado($decoded['genero']))) //VERIFICA QUE ES UN ARREGLO, ES DECIR QUE LA CONSULTA DEVUELVA RESULTADOS
            {
                $message = $data;
            }
            else
            {
                $message["message"] = "ERROR EN LA ACCION CANCIONES.";
            }
        break;

    case "Insertar":

        $data = $miApi->InsertarCancion($decoded['NombreC'],$decoded['Artista'],$decoded['IdGenero']); 
        
        break;
    
    case "canciones":
            if(is_array($data = $miApi->consultar())) //VERIFICA QUE ES UN ARREGLO, ES DECIR QUE LA CONSULTA DEVUELVA RESULTADOS
            {
                $message = $data;
            }
            else
            {
                $message["message"] = "ERROR EN LA ACCION CANCIONES.";
            }
        break;

    case "artistas":
            if(is_array($data = $miApi->listarArtistas())) //VERIFICA QUE ES UN ARREGLO, ES DECIR QUE LA CONSULTA DEVUELVA RESULTADOS
            {
                $message = $data;
            }
            else
            {
                $message["message"] = "ERROR EN LA ACCION CANCIONES.";
            }
        break;
        
    default:
            $message["message"] = "ACCION NO VALIDA";
        break;

    case "Empleado":
        $data = $miApi->InsertEmpleado($decoded['nombre'],$decoded['apellidos'],$decoded['correo'],$decoded['contraseña']);
        break;
    case "LoginEmpleado":
    	$data = $miApi->ConsultarEmpleado($decoded['correo'],$decoded['contraseña']);
    	$message = $data;
    	break;
    case "DatosUsuario":
        $data = $miApi->InsertarDatosUsuario($decoded['nombre'],$decoded['apellidoPaterno'],$decoded['apellidoMaterno'],$decoded['calle'],$decoded['numero'],$decoded['colonia'],$decoded['estado'],$decoded['codigoPostal'],$decoded['telefono'],$decoded['municipio'],$decoded['entreCalle1'],$decoded['entreCalle2']);
        break;
}

header('Content-Type:application/json;charset=utf-8');
print json_encode($message);