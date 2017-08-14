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

    public function InsertarDatosUsuario($Nombre, $ApellidoPaterno, $ApellidoMaterno, $Calle, $Numero, $Colonia, $Estado, $CodigoPostal, $Telefono, $Municipio, $EntreCalle1, $EntreCalle2)
    {
        $query = "INSERT into usuario(Nombre, ApellidoPaterno, ApellidoMaterno, Calle, Numero, Colonia, Estado, CodigoPostal, Telefono, Municipio, EntreCalle1, EntreCalle2) values ('".$Nombre."', '".$ApellidoPaterno."', '".$ApellidoMaterno."', '".$Calle."', '".$Numero."', '".$Colonia."', '".$Estado."', '".$CodigoPostal."', '".$Telefono."', '".$Municipio."', '".$EntreCalle1."', '".$EntreCalle2."');";
        $res = $this -> mysqli -> query($query);
    }

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
}
/*
$miConsulta = new Consultas();
$miConsulta -> conectado();
$miConsulta ->consultarCancionesPorGeneroFiltrado("Electronica");
//$miConsulta ->consultarConJoin();
//$miConsulta ->consultarOrdenPorCancion();
//$miConsulta ->consultarOrdenPorArtista();
$miConsulta ->consultarOrdenPorGenero();
 */