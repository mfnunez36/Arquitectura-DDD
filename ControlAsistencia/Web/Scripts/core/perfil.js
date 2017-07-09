$(document).ready(function () {
    GetAll();
});

/* BOTONES */

$('#btnLimpiar').click(function () {
    LimpiarCampos();
});

$('#btnBuscar').click(function () {
    GetById($('#txtPerfilID').val());
});

$('#btnModificar').click(function () {
    var perfil = new Object();
    perfil.perfilID = $('#txtPerfilID').val();
    perfil.nombre = $('#txtNombre').val();
    perfil.descripcion = $('#txtDescripcion').val();
    perfil.vigente = $('#chkVigente').val();

    UpdatePerfil(perfil.perfilID, JSON.stringify(perfil));
    window.location.href = "/Perfil/";
});

$('#btnAgregar').click(function () {
    var perfil = new Object();
    perfil.nombre = $('#txtNombre').val();
    perfil.descripcion = $('#txtDescripcion').val();
    perfil.vigente = $('#chkVigente').val();

    CreatePerfil(JSON.stringify(perfil));
});

$('#btnEliminar').click(function () {
    Delete($('#txtPerfilID').val());
});

/* METODOS */

function GetById(id) {
    var url = '/Perfil/Editar/' + id;
    $.getJSON(url).done(function (data) {
        $('#txtNombre').val(data.nombre);
        $('#txtDescripcion').val(data.descripcion);
        $('#chkVigente').val(data.vigente);

    }).fail(function (error) {
        alert("DO!");
    });
}

function GetAll() {
    var item = "";
    $('#listaPerfil tbody').html('');

    $.getJSON('/Perfil/Listar', function (data) {
        $.each(data, function (key, value) {
            item +=
                "<tr><td>" + value.perfilID +
                "</td><td>" + value.nombre +
                "</td><td>" + value.descripcion +
                "</td><td>" + value.vigente + "</td><td><a href='/Perfil/Editar/" + value.perfilID + "' class='btn btn-default'>EDITAR</a></td >'" + 
                "<td><a href='/Perfil/Eliminar/" + value.perfilID +"' class='btn btn-default'>ELIMINAR</a></td> <tr>'";
        });

        $('#listaPerfil tbody').append(item);
    });
}

function UpdatePerfil(id, perfil) {
    var url = '/Perfil/Editar/' + id;

    $.ajax({
        url: url,
        type: 'POST',
        data: perfil,
        contentType: "application/json; charset=utf-8",
        statusCode:
        {
            200: function () {
                GetAll();
                alert("Perfil fue Actualizado Exitosamente");
            },
            404: function () {
                alert("No Existe");
            },
            400: function () {
                alert("DO!");
            }
        }
    });
}

function CreatePerfil(perfil) {
    var url = '/Perfil/Agregar';

    $.ajax(
        {
            url: url,
            type: 'POST',
            data: perfil,
            contentType: "application/json; charset=utf-8",
            statusCode:
            {
                201: function () {
                    GetAll();
                    alert("Perfil Creado Exitosamente");
                },
                400: function () {
                    alert("DO!");
                }
            }
        });
}

function Delete(id) {
    var url = '/Perfil/Eliminar/' + id;

    $.ajax(
        {
            url: url,
            type: 'DELETE',
            data: perfil,
            contentType: "application/json; charset=utf-8",
            statusCode:
            {
                200: function () {
                    GetAll();
                    alert("Perfil Eliminado Exitosamente");
                    window.location.href = "Perfil/Index";
                },
                400: function () {
                    alert("DO!");
                    window.location.href = "Perfil/Index";
                }
            }
        });
}

function LimpiarCampos() {
    $('#txtPerfilID').val('');
    $('#txtNombre').val('');
    $('#txtDescripcion').val('');
    $('#chkVigente').val('');
}