<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCModalError.ascx.cs" Inherits="PruebaTecnicaEvoltis_JonathanAybar.Controls.UCModalError" %>

<div class="modal fade" id="errorModal" tabindex="-1" role="dialog" aria-labelledby="confirmacionModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="background-color:#dc3545;color: white;">
                <h5 class="modal-title" id="errorModalLabel"></h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
            </div>
            <div class="modal-body">
                <p id="mensajeError"></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Aceptar</button>
            </div>
        </div>
    </div>
</div>

    <script type="text/javascript">

        //Funciones

        ////Modal
        function mostrarModalError(titulo, mensaje = "Ocurrió un error al realizar la acción.") {
            $('#errorModal').modal('show');

            document.getElementById("errorModalLabel").innerHTML = titulo;
            document.getElementById("mensajeError").innerHTML = mensaje;
        }

        function cerrarModalError() {
            $('#errorModal').modal('hide');
        }       

    </script>
