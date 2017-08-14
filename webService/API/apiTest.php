<?php

class Consultas {
    
    private $conexion;
    private $results;
    private $mysqli;
    
    public function __construct() {
       $this -> conexion = new Conexion();
       $this -> mysqli = $this->conexion->mysqli;
    }
    
    public function conectado(){
        if ($this -> mysqli -> connect_errno)
            print "ERROR AL CONECTARSE".$this-> mysqli->connect_error;
        else
            print "CONECTADO CORRECTAMENTE";
    }

    public function consultar(){
        $query = "SELECT * FROM canciones";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        //print_r($this -> results);
        return $this->results;
    }
    
    public function consultarGenero(){
        $query = "SELECT genero FROM generos";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        //print_r($this -> results);
        return $this->results;
    }
    //PREGUNTAR EL USO DE AS
    public function consultarCancionesPorGenero(){
        $query = "SELECT genero, count(*) as canciones  FROM canciones INNER JOIN generos ON canciones.idGenero = generos.idGenero GROUP BY genero";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        //print_r($this -> results);
        return $this->results;
    }
    
    public function consultarCancionesPorGeneroFiltrado($genero){
        $query = "SELECT genero, count(*) as canciones  FROM canciones INNER JOIN generos ON canciones.idGenero = generos.idGenero where genero='".$genero."' GROUP BY genero ";
        print $query;
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        //print_r($this -> results);
        return $this->results;
    }
    
    public function listarArtistas(){
        $query = "SELECT artista FROM canciones GROUP BY artista ORDER BY artista";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        //print_r($this -> results);
        return $this->results;
    }
    
    public function consultarConJoin(){
        $query = "SELECT canciones.nombre,canciones.artista,generos.genero FROM canciones INNER JOIN generos ON canciones.idGenero = generos.idGenero";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        print_r($this -> results);
    }
    
    public function consultarOrdenPorCancion(){
        $query = "SELECT * FROM canciones ORDER BY nombre";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        print_r($this -> results);
    }
    
    public function consultarOrdenPorArtista(){
        $query = "SELECT * FROM canciones ORDER BY artista";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        print_r($this -> results);
    }
    
    public function consultarOrdenPorGenero(){
        $query = "SELECT canciones.nombre,canciones.artista,generos.genero FROM canciones INNER JOIN generos ON canciones.idGenero = generos.idGenero ORDER BY genero";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        print_r($this -> results);
    }

    public function InsertarCancion($nombre, $artista, $idGenero){
        $query = "INSERT into canciones(nombre,artista,idGenero) values ('".$nombre."','".$artista."','".$idGenero."');";
        $res = $this -> mysqli -> query($query);

    }

    //Aqui Comienza Proyecto Paqueteria

    //AppEmpleado
    //WebEmpleado
    public function ObtenerIdEmpleados(){
        $query = "SELECT idEmpleado, CONCAT(Nombre, ' ', Apellidos) as name from empleado";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }
    //
    public function ObtenerGuias(){
        $Entre = "ENTREGADO";
        $query = "SELECT idGuia from datosdeenvio where Estado != '".$Entre."'";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }
    //
    public function InsertarDatosRas($idGuia, $Fecha, $Latitud, $Longitud,$idEmpleado)
    {
        $query = "INSERT into rastreo(idGuia,Fecha,Latitud,Longitud,idEmpleado) values ('".$idGuia."', '".$Fecha."', '".$Latitud."', '".$Longitud."','".$idEmpleado."');";
        $res = $this -> mysqli -> query($query);
    }
    //Obtener Longitud y latitud
    public function InsertarDatosEntre($idGuia, $Fecha, $Latitud, $Longitud,$idEmpleado)
    {
        $query = "INSERT into rastreo(idGuia,Fecha,Latitud,Longitud,idEmpleado) values ('".$idGuia."', '".$Fecha."', '".$Latitud."', '".$Longitud."','".$idEmpleado."');";
        $res = $this -> mysqli -> query($query);
        ActualizarEstado($idGuia);
        if ($this -> mysqli -> error) {
            return "ERROR AL CONECTARSE".$this-> mysqli->error;
        }
    }

    public function ActualizarEstado($idGuia){
        $query = "UPDATE datosdeenvio SET Estado = 'ENTREGADO' where idGuia = '".$idGuia."'";
        $res = $this -> mysqli -> query($query);
        if ($this -> mysqli -> error) {
            return "ERROR AL CONECTARSE".$this-> mysqli->error;
        }
    }
    //
    public function ObtenerUbicacion(){
        $query = "SELECT Latitud=$latitud, Longitud= $Longitud FROM rastreo WHERE idGuia = $idGuia" ;
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }

    public function ObtenerDatosPedido($guia)
    {
        $query = "SELECT Fecha, Latitud, Longitud FROM rastreo WHERE idGuia = '".$guia."'  ORDER BY Fecha limit 1";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }

    public function ObtenerDatosPedidoID($guia)
    {
        $query = "SELECT Latitud, Longitud FROM rastreo WHERE idGuia = '".$guia."'";
        $res = $this -> mysqli -> query($query);
        $this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        return $this->results;
    }

    //Escritorio

    public function InsertEmpleado($nombre, $apellidos, $correo, $contraseña)
    {
        $query = "INSERT into empleado(nombre,apellidos,correo,contraseña) values ('".$nombre."', '".$apellidos."', '".$correo."', '".$contraseña."');";
        $res = $this -> mysqli -> query($query);
    }

    public function ConsultarEmpleado($correo, $contraseña){
        $query = "SELECT Nombre FROM empleado WHERE Correo = '".$correo."' and Contraseña = '".$contraseña."';";
        $res = $this -> mysqli -> query($query);
        //print_r($this -> results)
        $cont = mysqli_num_rows($res);
        //$this -> results = $res -> fetch_all(MYSQLI_ASSOC);
        return $cont;
    }

    public function InsertarDatosUsuario($Nombre, $ApellidoPaterno, $ApellidoMaterno, $Calle, $Numero, $Colonia, $Estado, $CodigoPostal, $Telefono, $Municipio, $Tipo1)
    {
        $query = "INSERT into usuario(Nombre, ApellidoPaterno, ApellidoMaterno, Calle, Numero, Colonia, Estado, CodigoPostal, Telefono, Municipio, Tipo) values ('".$Nombre."', '".$ApellidoPaterno."', '".$ApellidoMaterno."', '".$Calle."', '".$Numero."', '".$Colonia."', '".$Estado."', '".$CodigoPostal."', '".$Telefono."', '".$Municipio."', '".$Tipo1."');";

        $res = $this -> mysqli -> query($query);
        if ($this -> mysqli -> error) {
            return "ERROR AL CONECTARSE".$this-> mysqli->error;
        }
    }

    public function InsertarDatosUsuario2($Nombre, $ApellidoPaterno, $ApellidoMaterno, $Calle, $Numero, $Colonia, $Estado, $CodigoPostal, $Telefono, $Municipio, $EntreCalle1, $EntreCalle2, $Tipo1)
    {
        $query = "INSERT into usuario(Nombre, ApellidoPaterno, ApellidoMaterno, Calle, Numero, Colonia, Estado, CodigoPostal, Telefono, Municipio, EntreCalle1, EntreCalle2, Tipo) values ('".$Nombre."', '".$ApellidoPaterno."', '".$ApellidoMaterno."', '".$Calle."', '".$Numero."', '".$Colonia."', '".$Estado."', '".$CodigoPostal."', '".$Telefono."', '".$Municipio."', '".$EntreCalle1."', '".$EntreCalle2."', '".$Tipo1."');";
        $res = $this -> mysqli -> query($query);
        if ($this -> mysqli -> error) {
            return "ERROR AL CONECTARSE".$this-> mysqli->error;
        }
    }

    public function InsertarDatosPaquete($Tipo,$Peso)
    {
        $query = "INSERT into paquete(Tipo,Peso) values ('".$Tipo."','".$Peso."');";
        $res = $this -> mysqli -> query($query);
        if ($this -> mysqli -> error) {
            return "ERROR AL CONECTARSE".$this-> mysqli->error;
        }
    }

    //public function ObtenerFecha($Fecha)
    //{
      //  $Fecha = new DateTime(&Fecha);
       // $FE = $Fecha -> add(new DateInterval('P10D'));
        //print $Fecha -> Format('Y-m-d');
        //print $FE -> Format('Y-m-d');
    //}

    public function ObtenerDatosReceptor(){
        $query = "SELECT MAX(idUsuario) AS id FROM usuario WHERE Tipo = 'Receptor'";
        $res = $this -> mysqli -> query($query);

        $fila = $res->fetch_assoc();


        //print_r($this -> results)
        if ($this -> mysqli -> error) {
            return "ERROR AL CONECTARSE".$this-> mysqli->error;
        }
        $Resultado = $fila['id'];
        return $Resultado;
    }


    public function ObtenerDatosPaquete(){
        $query = "SELECT MAX(idPaquete) AS id FROM paquete";
        $res = $this -> mysqli -> query($query);

        $fila = $res->fetch_assoc();


        //print_r($this -> results)
        if ($this -> mysqli -> error) {
            return "ERROR AL CONECTARSE".$this-> mysqli->error;
        }
        $Resultado = $fila['id'];
        return $Resultado;
    }

    public function ObtenerIDGuia(){
        $query = "SELECT MAX(idGuia) AS id FROM datosdeenvio";
        $res = $this -> mysqli -> query($query);

        $fila = $res->fetch_assoc();


        //print_r($this -> results)
        if ($this -> mysqli -> error) {
            return "ERROR AL CONECTARSE".$this-> mysqli->error;
        }
        $Resultado = $fila['id'];
        return $Resultado;
    }

    public function InsertarDatosEnvioPaquete($idUsuario, $idPaquete, $FechaSalida, $FechaLlegada, $Estado)
    {
        $query = "INSERT into datosdeenvio(idDestinatario, idPaquete, FechaSalida, FechaLlegada) values ('".$idUsuario."', '".$idPaquete."', '".$FechaSalida."', '".$FechaLlegada."')";
        $res = $this -> mysqli -> query($query);
        if ($this -> mysqli -> error) {
            return "ERROR AL CONECTARSE".$this-> mysqli->error;
        }
    }
}
//
//$miConsulta = new Consultas();
//$miConsulta -> conectado();
//$miConsulta ->consultarCancionesPorGeneroFiltrado("Electronica");
//$miConsulta ->consultarConJoin();
//$miConsulta ->consultarOrdenPorCancion();
//$miConsulta ->consultarOrdenPorArtista();
//$miConsulta ->consultarOrdenPorGenero();