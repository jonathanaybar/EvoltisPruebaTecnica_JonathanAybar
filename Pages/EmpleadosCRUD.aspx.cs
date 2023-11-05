using PruebaTecnicaEvoltis_JonathanAybar.Context;
using PruebaTecnicaEvoltis_JonathanAybar.Models;
using PruebaTecnicaEvoltis_JonathanAybar.Repositories.Implementaciones;
using PruebaTecnicaEvoltis_JonathanAybar.Repositories.Interfaces;
using PruebaTecnicaEvoltis_JonathanAybar.Services.Implementaciones;
using PruebaTecnicaEvoltis_JonathanAybar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaTecnicaEvoltis_JonathanAybar.Pages
{
    public partial class EmpleadosCRUD : System.Web.UI.Page
    {

        #region Propiedades

        private EmpleadoService EmpleadoService
        {
            get { return new EmpleadoService(); }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTablaEmpleados();
                LimpiarCamposEmpleado();
            }
        }

        #region Eventos Controles
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreEmpleado = txtBuscarEmpleado.Text.Trim();

                var empleadosEncontrados = (List<Empleado>)EmpleadoService.ObtenerEmpleadosPorNombre(nombreEmpleado);

                if (empleadosEncontrados != null)
                {
                    GridViewEmpleados.DataSource = empleadosEncontrados;
                    GridViewEmpleados.DataBind();
                }
            }
            catch
            {
                throw new Exception("Error al buscar empleado.");
            }
        }
        protected void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            MostrarControlesEdicion();
            OcultarErrores();

            if (IsPostBack)
            {
                lblTituloModal.Text = "Agregar empleado";
                this.hdfIdEmpleado.Value = null;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalEmpleadoAgregarScript", "$(function() { mostrarModalEmpleado(); });", true);

                LimpiarCamposEmpleado();
            }
        }

        protected void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            MostrarControlesEdicion();
            OcultarErrores();

            Button btn = (Button)sender;
            string idEmpleado = btn.CommandArgument;

            if (IsPostBack)
            {
                lblTituloModal.Text = "Editar empleado";

                Empleado empleado = EmpleadoService.ObtenerEmpleadoPorId(Convert.ToInt32(idEmpleado));

                this.hdfIdEmpleado.Value = empleado.ID.ToString();
                this.txtNombre.Text = empleado.Nombre;
                this.txtApellido.Text = empleado.Apellido;
                this.txtCorreoElectronico.Text = empleado.CorreoElectronico;
                this.txtSalario.Text = empleado.Salario.ToString();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalEmpleadoEditarScript", "$(function() { mostrarModalEmpleado(); });", true);
            }
        }

        protected void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            OcultarErrores();

            Button btn = (Button)sender;
            string idEmpleado = btn.CommandArgument;

            if (IsPostBack)
            {
                lblTituloModal.Text = "Eliminar empleado";
                this.hdfIdEmpleado.Value = null;

                Empleado empleado = EmpleadoService.ObtenerEmpleadoPorId(Convert.ToInt32(idEmpleado));

                this.hdfIdEmpleado.Value = empleado.ID.ToString();
                this.txtNombre.Text = empleado.Nombre;
                this.txtApellido.Text = empleado.Apellido;
                this.txtCorreoElectronico.Text = empleado.CorreoElectronico;
                this.txtSalario.Text = empleado.Salario.ToString();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalEmpleadoAgregarScript", "$(function() { mostrarModalEmpleado(); });", true);

                MostrarControlesEdicion(false);
            }
        }

        protected void btnConfirmarEmpleado_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                if (string.IsNullOrEmpty(this.hdfIdEmpleado.Value))
                {
                    CrearEmpleado();
                }
                else
                {
                    EditarEmpleado();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalEmpleadoErrorScript", "$(function() { mostrarModalEmpleado(); });", true);
            }
        }

        protected void btnConfirmarEliminarEmpleado_Click(object sender, EventArgs e)
        {
            EliminarEmpleado();
        }

        protected void GridViewEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEmpleados.PageIndex = e.NewPageIndex;
            CargarTablaEmpleados();
        }

        #endregion

        #region Metodos

        public void LimpiarCamposEmpleado()
        {
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtCorreoElectronico.Text = "";
            this.txtSalario.Text = "";
        }

        public void BloquearCamposEmpleado()
        {
            this.txtNombre.Enabled = false;
            this.txtApellido.Enabled = false;
            this.txtCorreoElectronico.Enabled = false;
            this.txtSalario.Enabled = false;
        }

        public void ActivarCamposEmpleado()
        {
            this.txtNombre.Enabled = true;
            this.txtApellido.Enabled = true;
            this.txtCorreoElectronico.Enabled = true;
            this.txtSalario.Enabled = true;
        }

        public void MostrarControlesEdicion(bool activar = true)
        {
            if (activar)
            {
                ActivarCamposEmpleado();

                btnConfirmarEliminarEmpleado.Visible = false;
                lblMensajeAdvertencia.Visible = false;

                btnConfirmarEmpleado.Visible = true;
            }
            else
            {
                BloquearCamposEmpleado();

                btnConfirmarEliminarEmpleado.Visible = true;
                lblMensajeAdvertencia.Visible = true;

                btnConfirmarEmpleado.Visible = false;
            }
        }

        public void CargarTablaEmpleados()
        {
            var listaEmpleados = (List<Empleado>)EmpleadoService.ObtenerTodosLosEmpleados();
            GridViewEmpleados.DataSource = listaEmpleados;
            GridViewEmpleados.DataBind();
        }

        public void CrearEmpleado()
        {

            Empleado empleado = new Empleado();

            empleado.Nombre = this.txtNombre.Text;
            empleado.Apellido = this.txtApellido.Text;
            empleado.CorreoElectronico = this.txtCorreoElectronico.Text;
            empleado.Salario = Convert.ToDecimal(this.txtSalario.Text);

            EmpleadoService.AgregarEmpleado(empleado);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalConfirmacionAgregarScript", "$(function() { mostrarModalConfirmacion('Carga de Empleado'); });", true);

            CargarTablaEmpleados();

        }

        public void EditarEmpleado()
        {
            Empleado empleado = new Empleado();

            empleado.ID = Convert.ToInt32(this.hdfIdEmpleado.Value);
            empleado.Nombre = this.txtNombre.Text;
            empleado.Apellido = this.txtApellido.Text;
            empleado.CorreoElectronico = this.txtCorreoElectronico.Text;
            empleado.Salario = Convert.ToDecimal(this.txtSalario.Text);

            EmpleadoService.ActualizarEmpleado(empleado);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalConfirmacionAgregarScript", "$(function() { mostrarModalConfirmacion('Actualizacion de Empleado'); });", true);

            CargarTablaEmpleados();

        }

        public void EliminarEmpleado()
        {            
            Empleado empleado = new Empleado();

            empleado.ID = Convert.ToInt32(this.hdfIdEmpleado.Value);

            EmpleadoService.EliminarEmpleado(empleado);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModalConfirmacionAgregarScript", "$(function() { mostrarModalConfirmacion('Baja de Empleado'); });", true);

            CargarTablaEmpleados();
            MostrarControlesEdicion(true);
        }

        private bool ValidarFormulario()
        {
            bool esValido = true;
            if (Page.IsValid)
            {


                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblNombreError.Visible = true;
                    esValido = false;
                }
                else
                {
                    lblNombreError.Visible = false;
                }

                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    lblApellidoError.Visible = true;
                    esValido = false;
                }
                else
                {
                    lblApellidoError.Visible = false;
                }

                if (string.IsNullOrWhiteSpace(txtCorreoElectronico.Text))
                {
                    lblCorreoElectronicoError.Visible = true;
                    esValido = false;
                }
                else
                {
                    lblCorreoElectronicoError.Visible = false;
                }

                if (string.IsNullOrWhiteSpace(txtSalario.Text))
                {
                    lblSalarioError.Visible = true;
                    esValido = false;
                }
                else
                {
                    lblSalarioError.Visible = false;
                }
            }
            else
            {
                esValido = false;
            }

            return esValido;
        }

        private void OcultarErrores()
        {
            lblNombreError.Visible = false;
            lblApellidoError.Visible = false;
            lblCorreoElectronicoError.Visible = false;
            lblSalarioError.Visible = false;
        }
    }

    #endregion

}
