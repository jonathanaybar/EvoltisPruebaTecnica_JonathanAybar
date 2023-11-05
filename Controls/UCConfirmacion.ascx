<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCConfirmacion.ascx.cs" Inherits="PruebaTecnicaEvoltis_JonathanAybar.Controls.UCConfirmacion" %>


<div class="modal fade" id="confirmacionModal" tabindex="-1" role="dialog" aria-labelledby="confirmacionModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="confirmacionModalLabel"></h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
            </div>
            <div class="modal-body">
                <p>La accion se realizo correctamente.</p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-success" data-bs-dismiss="modal">Aceptar</button>
            </div>
        </div>
    </div>
</div>

    <script type="text/javascript">

        //Funciones

        ////Modal
        function mostrarModalConfirmacion(titulo) {
            $('#confirmacionModal').modal('show');

            document.getElementById("confirmacionModalLabel").innerHTML = titulo;
        }

        function cerrarModalConfirmacion() {
            $('#confirmacionModal').modal('hide');
        }       

    </script>