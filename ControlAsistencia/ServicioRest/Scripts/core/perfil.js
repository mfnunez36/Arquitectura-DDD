$(document).ready(function()
{
    GetAll();
});

$('#btnLimpiar').click(function ()
{
    LimpiarCampos();
});

$('#btnBuscar').click(function ()
{
    GetById($('#txtPerfilID').val());
});

$('#btnModificar').click(function ()
{
    var perfil = new Object();
    perfil.perfilID = $('#txtPerfilID').val();
    perfil.nombre = $('#txtNombre').val();
    perfil.descripcion = $('#txtDescripcion').val();
    perfil.vigente = $('#chkVigente').val();

    UpdatePerfil(perfil.perfilID, JSON.stringify(perfil));
});

$('#btnAgregar').click(function ()
{
    var perfil = new Object();
    perfil.nombre = $('#txtNombre').val();
    perfil.descripcion = $('#txtDescripcion').val();
    perfil.vigente = $('#chkVigente').val();

    CreatePerfil(JSON.stringify(perfil));
});

$('#btnEliminar').click(function () {
    Delete($('#txtPerfilID').val());
});


function GetById(id)
{
    var url = '/api/Perfil/' + id;
    $.getJSON(url).done(function (data)
    {
        $('#txtNombre').val(data.nombre);
        $('#txtDescripcion').val(data.descripcion);
        $('#chkVigente').val(data.vigente);

    }).fail(function (error)
    {
        alert("DO!");
        LimpiarCampos();
    });
}

function GetAll()
{
    var item = "";
    $('#listaPerfil tbody').html('');

    $.getJSON('/api/Perfil', function (data) {
        $.each(data, function (key, value)
        {
            item +=
                "<tr><td>" + value.perfilID +
                "</td><td>" + value.nombre +
                "</td><td>" + value.descripcion +
                "</td><td>" + value.vigente + "</td><tr>";
        });

        $('#listaPerfil tbody').append(item);
    });
}

function UpdatePerfil(id, perfil)
{
    var url = '/api/Perfil/' + id;

    $.ajax({
        url: url,
        type: 'PUT',
        data: perfil,
        contentType: "application/json; charset=utf-8",
        statusCode:
        {
            200: function ()
            {
                GetAll();
                LimpiarCampos();
                alert("Perfil con el ID " + id + " fue Actualizado Exitosamente");
            },
            404: function ()
            {
                LimpiarCampos();
                alert("No existe el Perfil con ID " + id);
            },
            400: function ()
            {
                LimpiarCampos();
                alert("DO!");
            }
        }
    });
}

function CreatePerfil(perfil)
{
    var url = '/api/Perfil';

    $.ajax(
    {
        url: url,
        type: 'POST',
        data: perfil,
        contentType: "application/json; charset=utf-8",
        statusCode:
        {
            201: function ()
            {
                GetAll();
                LimpiarCampos();
                alert("Perfil Creado Exitosamente");
            }, 
            400: function ()
            {
                LimpiarCampos();
                alert("DO!");
            }
        }
    });
}

function Delete(id)
{
    var url = '/api/Perfil/' + id;

    $.ajax(
    {
        url: url,
        type: 'DELETE',
        contentType: "application/json; charset=utf-8",
        statusCode:
        {
            200: function ()
            {
                GetAll();
                LimpiarCampos();
                alert("Perfil Eliminado Exitosamente");
            },
            400: function ()
            {
                GetAll();
                LimpiarCampos();
                alert("DO!");
            }
        }
    });
}

function LimpiarCampos()
{
    $('#txtPerfilID').val('');
    $('#txtNombre').val('');
    $('#txtDescripcion').val('');
    $('#chkVigente').val('');
}