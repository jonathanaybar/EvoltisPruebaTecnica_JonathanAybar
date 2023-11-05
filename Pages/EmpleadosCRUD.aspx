<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpleadosCRUD.aspx.cs" Inherits="PruebaTecnicaEvoltis_JonathanAybar.Pages.EmpleadosCRUD" %>

<%@ Register Src="~/Controls/UCConfirmacion.ascx" TagPrefix="UCModalConfirmacion" TagName="UCConfirmacion" %>

<asp:Content ID="ContentBody" ContentPlaceHolderID="MainContent" runat="server">

    <h1 style="padding-top: 30px" class="text-center">Empleados</h1>

    <div class="row" style="padding-top: 20px">

        <div class="row col-6">
            <div class="col-6">
                <asp:TextBox ID="txtBuscarEmpleado" runat="server" CssClass="form-control" placeholder="Ingrese nombre de empleado..." MaxLength="50" onkeypress="return validarNombre(event)" />
            </div>
            <div class="col-2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
        <div class="col-6 d-flex justify-content-end">
            <asp:Button ID="btnAgregarEmpleado" runat="server" Text="Agregar Empleado" CssClass="btn btn-success" OnClick="btnAgregarEmpleado_Click" />
        </div>

    </div>
    <hr />

    <asp:GridView ID="GridViewEmpleados" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridViewEmpleados_PageIndexChanging" EmptyDataText="No hay empleados para mostrar.">
        <PagerSettings Position="TopAndBottom" />
        <PagerStyle CssClass="pagination" />

        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" Visible="false" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" />
            <asp:BoundField DataField="Salario" HeaderText="Salario" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button ID="btnEditarEmpleado" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-primary" ToolTip="Editar" OnClick="btnEditarEmpleado_Click" />
                    <asp:Button ID="btnEliminarEmpleado" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-danger" ToolTip="Eliminar" OnClick="btnEliminarEmpleado_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <div class="modal fade" id="modalEmpleado" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label ID="lblTituloModal" runat="server" class="modal-title fs-5"></asp:Label>
                    <button type="button" class="btn-close" aria-label="Close" onclick="cerrarModalEmpleado()"></button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="updatePanelModal" runat="server">
                        <ContentTemplate>

                            <asp:HiddenField ID="hdfIdEmpleado" runat="server" />

                            <div>
                                <label style="padding-top: 10px;">Nombre:</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese nombre..." MaxLength="50" onkeypress="return validarNombre(event)" />
                                <asp:Label ID="lblNombreError" runat="server" CssClass="text-danger" Visible="false">El campo nombre es obligatorio.</asp:Label>
                            </div>

                            <div>
                                <label style="padding-top: 10px;">Apellido:</label>
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese apellido..." MaxLength="50" onkeypress="return validarNombre(event)" />
                                <asp:Label ID="lblApellidoError" runat="server" CssClass="text-danger" Visible="false">El campo apellido es obligatorio.</asp:Label>
                            </div>

                            <div>
                                <label style="padding-top: 10px;">Correo Electrónico:</label>
                                <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="form-control" placeholder="Ingrese correo..." MaxLength="50" />
                                <asp:Label ID="lblCorreoElectronicoError" runat="server" CssClass="text-danger" Visible="false">El campo correo electrónico es obligatorio.</asp:Label>
                                <div>
                                    <asp:RegularExpressionValidator ID="revCorreoElectronico" runat="server" ControlToValidate="txtCorreoElectronico" ValidationExpression="\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b" ErrorMessage="Correo electrónico no válido." CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>

                            <div>
                                <label style="padding-top: 10px;">Salario:</label>
                                <asp:TextBox ID="txtSalario" runat="server" CssClass="form-control" placeholder="Ingrese salario..." MaxLength="10" onkeypress="return soloNumeros(event)" />
                                <asp:Label ID="lblSalarioError" runat="server" CssClass="text-danger" Visible="false">El campo salario es obligatorio.</asp:Label>
                                <div>
                                    <asp:RegularExpressionValidator ID="revSalario" runat="server" ControlToValidate="txtSalario" ValidationExpression="^[0-9]*$|^[0-9]+(\.[0-9]{1,2})?$" ErrorMessage="El salario no puede ser negativo." CssClass="text-danger" Display="Dynamic" />
                                </div>
                            </div>

                            <br />

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnConfirmarEmpleado" runat="server" Text="Confirmar" CssClass="btn btn-success" OnClick="btnConfirmarEmpleado_Click" />

                    <asp:Label ID="lblMensajeAdvertencia" runat="server" CssClass="col-9 text-danger">¿Seguro que desea eliminar empleado?</asp:Label>
                    <asp:Button ID="btnConfirmarEliminarEmpleado" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnConfirmarEliminarEmpleado_Click" />
                </div>
            </div>
        </div>
    </div>

    <UCModalConfirmacion:UCConfirmacion runat="server" ID="UCConfirmacion" />

    <script type="text/javascript">

        //Funciones

        ////Modal
        function mostrarModalEmpleado() {
            $('#modalEmpleado').modal('show');
        }

        function cerrarModalEmpleado() {
            $('#modalEmpleado').modal('hide');
        }


        ////Validaciones
        function soloNumeros(event) {
            var tecla = event.which || event.keyCode;
            if (tecla < 48 || tecla > 57) {
                event.preventDefault();
            }
        }

        function validarNombre(input) {

            var tecla = event.which || event.keyCode;
            if (tecla > 48 && tecla < 57) {
                event.preventDefault();
            }
        }

    </script>

</asp:Content>


