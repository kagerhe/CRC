
function ProgressShow() {
    $("#loading-div-background").show();
    $("#loading-div").show();
}

function ProgressHide() {
    $("#loading-div-background").hide();
    $("#loading-div").hide();
}

function ValidarDatosIngresados(count) {
    var Resultmessage = "";

    var Datos = {

        Tipo_doc: $("#tipod").val(),
        Dni: $("#nro_doc").val(),
        Papellido: $("#apellidoP").val(),
    };
    if (isNaN(Datos.Tipo_doc)) {
        swal("¡Datos!", "...Se debe seleccionar el tipo de documento");
        //Resultmessage += "Razon Social" + "</br>";
        return 0;
    }
    if (Datos.Dni == "") {
        swal("¡Datos!", "...Se debe colocar la identificación");
        // Resultmessage += "número identificación" + "</br>";
        return 0;
    }

    if (Datos.Papellido == "") {
        swal("¡Datos!", "...Se debe colocar el primer apellido");
        //  Resultmessage += "apellido" + "</br>";
        return 0;
    }
    for (var key in Datos) {
        if (Datos[key] == "" || Datos[key] == null) {
            //swal("¡Datos!", "...Por favor ingrese" + " " + key.replace("_", " ").replace("_", " "));
            Resultmessage += key.replace("_", " ").replace("_", " ") + "</br>";
            //return false;
        }
    }
    if (Resultmessage == "") {
        Resultmessage = true;
    }


    return Resultmessage;
}

var count = 2;
$(".btnGuardar").on("click", function () {

    var DatosDetalle = [];
    var ListaCargo = [];
    var ListaSede = [];
    var row = 1;
    var paso = 1;
    var error = 0;
    var Seg = false;
    var Ries = false;
    var catCount = $("#catcount").val();
    //Armar list de item de las caterogias.




    // variables del Formulario
    var Datos = {
        Tipo_doc: $("#tipod").val(),
        Dni: $("#nro_doc").val(),
        Papellido: $("#apellidoP").val(),
        Sapellido: $("#apellidoM").val(),
        Nombres: $("#nombres").val(),
        fecha_Nac: $("#FechaN").val(),
        Nacionalidad: $("#Nacionalidad option:selected").val(),
        Pais: $("#pais option:selected").val(),
        Correo: $("#correo").val(),
        TelefonoC: $("#TelefonoC").val(),
        TelefonoCasa: $("#TelefonoCasa").val(),
        Nivelingles: $("#nivelingles option:selected").val(),
        IdEnteraste: $("#Enteraste option:selected").val(),
        Trabajo_Interes: $("#InteresadoEn option:selected").val(),
        Experiencia: $("#group4").val(),
        IdCompCrucero: $("#compania option:selected").val(),
        IdAreaInteres: $("#AreaInteres option:selected").val(),
        Tatuaje: $("#group6").val(),
        sede: $("#sede option:selected").val(),
        LugarTatu: $("#LugarTatu").val(),
        Foto: $("#foto").val()




    };


    var message = ValidarDatosIngresados(count);
    // var message = 0;
    var dataform = new FormData();
    for (var key in Datos) {
        dataform.append(key, Datos[key]);
    }





    if (message != 0)
        if (error != 1) {
            swal({
                title: '¿Desea guardar los datos?',
                //title: 'Desea guardar el formato?',
                //html: "<b>No se han llenado los siguientes campos:</b><br/><br/>" + message,
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Guardar',
                cancelButtonText: 'Cancelar'
            }).then(function (result) {
                if (result) {
                    //    ProgressShow();
                    $.ajax({
                        type: "POST",
                        url: '/Interesados/InsertNewInteresado',
                        data: dataform,
                        processData: false,
                        contentType: false,
                        dataType: "json",
                        success: function (response) {
                            if (response.isRedirect) {
                                ProgressHide();
                                window.onbeforeunload = null;
                                swal(
                                    '¡Se ha registrado con éxito!',
                                    '',
                                    'success'
                                ).then((result) => {
                                    window.location.href = response.redirectUrl;
                                })


                            } else { alert('Se ha producido un error'); }
                        }
                    });
                }
            })

        }
})


$(".btnnocontesto").on("click", function (value) {
    message = 1;
    error = 2;
    // variables del Formulario
    var Datos = {
        Id_Inter: $("#indinter").val(),
        Estado: 1
    };

    var dataform = new FormData();

    for (var key in Datos) {
        dataform.append(key, Datos[key]);
    }

    if (message != 0)
        if (error != 1) {
            swal({
                title: '¿Desea actualizar el estado del interesado?',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si',
                cancelButtonText: 'No'
            }).then(function (result) {
                if (result) {
                    //    ProgressShow();
                    $.ajax({
                        type: "POST",
                        url: '/Interesados/EditarInteresados',
                        data: dataform,
                        processData: false,
                        contentType: false,
                        dataType: "json",
                        success: function (response) {
                            if (response.isRedirect) {
                                ProgressHide();
                                window.onbeforeunload = null;
                                swal(
                                    '¡Se ha registrado con éxito!',
                                    '',
                                    'success'
                                ).then((result) => {
                                    window.location.href = response.redirectUrl;
                                })
                            } else { alert('Se ha producido un error'); }
                        }
                    });
                }
            })

        }
})

$(".btnnointeresado").on("click", function () {
    message = 1;
    error = 2;
    // variables del Formulario
    var Datos = {
        Id_Inter: $("#indinter").val(),
        Estado: 2
    };

    var dataform = new FormData();

    for (var key in Datos) {
        dataform.append(key, Datos[key]);
    }

    if (message != 0)
        if (error != 1) {
            swal({
                title: '¿Desea actualizar el estado del interesado?',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si',
                cancelButtonText: 'No'
            }).then(function (result) {
                if (result) {
                    //    ProgressShow();
                    $.ajax({
                        type: "POST",
                        url: '/Interesados/EditarInteresados',
                        data: dataform,
                        processData: false,
                        contentType: false,
                        dataType: "json",
                        success: function (response) {
                            if (response.isRedirect) {
                                ProgressHide();
                                window.onbeforeunload = null;
                                swal(
                                    '¡Se ha registrado con éxito!',
                                    '',
                                    'success'
                                ).then((result) => {
                                    window.location.href = response.redirectUrl;
                                })
                            } else { alert('Se ha producido un error'); }
                        }
                    });
                }
            })

        }
})

$(".btncitar").on("click", function () {
    message = 1;
    error = 2;
    // variables del Formulario
    var Datos = {
        Id_Inter: $("#indinter").val(),
        Estado: 3
    };

    var dataform = new FormData();

    for (var key in Datos) {
        dataform.append(key, Datos[key]);
    }

    if (message != 0)
        if (error != 1) {
            swal({
                title: '¿Desea actualizar el estado del interesado?',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si',
                cancelButtonText: 'No'
            }).then(function (result) {
                if (result) {
                    //    ProgressShow();
                    $.ajax({
                        type: "POST",
                        url: '/Interesados/EditarInteresados',
                        data: dataform,
                        processData: false,
                        contentType: false,
                        dataType: "json",
                        success: function (response) {
                            if (response.isRedirect) {
                                ProgressHide();
                                window.onbeforeunload = null;
                                swal(
                                    '¡Se ha registrado con éxito!',
                                    '',
                                    'success'
                                ).then((result) => {
                                    window.location.href = response.redirectUrl;
                                })
                            } else { alert('Se ha producido un error'); }
                        }
                    });
                }
            })

        }
})

$(".btnnodisponible").on("click", function () {
    message = 1;
    error = 2;
    // variables del Formulario
    var Datos = {
        Id_Inter: $("#indinter").val(),
        Estado: 4
    };

    var dataform = new FormData();

    for (var key in Datos) {
        dataform.append(key, Datos[key]);
    }

    if (message != 0)
        if (error != 1) {
            swal({
                title: '¿Desea actualizar el estado del interesado?',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si',
                cancelButtonText: 'No'
            }).then(function (result) {
                if (result) {
                    //    ProgressShow();
                    $.ajax({
                        type: "POST",
                        url: '/Interesados/EditarInteresados',
                        data: dataform,
                        processData: false,
                        contentType: false,
                        dataType: "json",
                        success: function (response) {
                            if (response.isRedirect) {
                                ProgressHide();
                                window.onbeforeunload = null;
                                swal(
                                    '¡Se ha registrado con éxito!',
                                    '',
                                    'success'
                                ).then((result) => {
                                    window.location.href = response.redirectUrl;
                                })
                            } else { alert('Se ha producido un error'); }
                        }
                    });
                }
            })

        }
})

$(".btnnodisponible").on("click", function () {
    message = 1;
    error = 2;
    // variables del Formulario
    var Datos = {
        Id_Inter: $("#indinter").val(),
        Estado: 4
    };

    var dataform = new FormData();

    for (var key in Datos) {
        dataform.append(key, Datos[key]);
    }

    if (message != 0)
        if (error != 1) {
            swal({
                title: '¿Desea actualizar el estado del interesado?',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si',
                cancelButtonText: 'No'
            }).then(function (result) {
                if (result) {
                    //    ProgressShow();
                    $.ajax({
                        type: "POST",
                        url: '/Interesados/EditarInteresados',
                        data: dataform,
                        processData: false,
                        contentType: false,
                        dataType: "json",
                        success: function (response) {
                            if (response.isRedirect) {
                                ProgressHide();
                                window.onbeforeunload = null;
                                swal(
                                    '¡Se ha registrado con éxito!',
                                    '',
                                    'success'
                                ).then((result) => {
                                    window.location.href = response.redirectUrl;
                                })
                            } else { alert('Se ha producido un error'); }
                        }
                    });
                }
            })

        }
})

$(".btnderivar").on("click", function () {
    message = 1;
    error = 2;
    // variables del Formulario
    var Datos = {
        Id_Inter: $("#indinter").val(),
        Estado: 5
    };

    var dataform = new FormData();

    for (var key in Datos) {
        dataform.append(key, Datos[key]);
    }

    if (message != 0)
        if (error != 1) {
            swal({
                title: '¿Desea actualizar el estado del interesado?',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si',
                cancelButtonText: 'No'
            }).then(function (result) {
                if (result) {
                    //    ProgressShow();
                    $.ajax({
                        type: "POST",
                        url: '/Interesados/EditarInteresados',
                        data: dataform,
                        processData: false,
                        contentType: false,
                        dataType: "json",
                        success: function (response) {
                            if (response.isRedirect) {
                                ProgressHide();
                                window.onbeforeunload = null;
                                swal(
                                    '¡Se ha registrado con éxito!',
                                    '',
                                    'success'
                                ).then((result) => {
                                    window.location.href = response.redirectUrl;
                                })
                            } else { alert('Se ha producido un error'); }
                        }
                    });
                }
            })

        }
})