using PNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class Form1 : Form
    {
        private string NombreAnt;
        public Form1()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                DgvUsuarios.DataSource = NUsuario.Listar();

                this.Formato();
                this.Limpiar();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);

            }
        }

        private void Limpiar()
        {

            TxtNombres.Clear();
            TxtApellidos.Clear();
            TxtDni.Clear();
            TxtId.Clear();
            
            BtnInsertar.Visible = true;
            ErrorIcono.Clear();
            BtnActualizar.Visible = true;
            DgvUsuarios.Columns[0].Visible = false;
            BtnEliminar.Visible = true;

        }

        private void Formato()
        {
            DgvUsuarios.Columns[0].Visible = false;
            DgvUsuarios.Columns[1].Width = 40;
            DgvUsuarios.Columns[1].Visible = true;
            DgvUsuarios.Columns[2].Width = 150;
            DgvUsuarios.Columns[3].Width = 150;
            DgvUsuarios.Columns[4].HeaderText = "Fecha Nacimiento";
            DgvUsuarios.Columns[4].Width = 80;
            DgvUsuarios.Columns[5].Width = 80;
            
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void DgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvUsuarios.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvUsuarios.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }


        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtNombres.Text == string.Empty)
                {
                    this.MensajeError("Faltan ingresos algunos datos, seran remarcados");
                    ErrorIcono.SetError(TxtNombres, "Ingrese un nombre");
                }
                else
                {
                    Rpta = NUsuario.Insertar(TxtNombres.Text.Trim(), TxtApellidos.Text.Trim(), TxtDni.Text.Trim(), Convert.ToDateTime(DtFechaNac.Text.Trim()));
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se inserto de forma correcta el registro");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtNombres.Text == string.Empty || TxtId.Text == string.Empty)
                {
                    this.MensajeError("Faltan ingresos algunos datos, seran remarcados");
                    ErrorIcono.SetError(TxtNombres, "Ingrese su(s) nombre");
                    
                }
                else
                {
                    Rpta = NUsuario.Actualizar(Convert.ToInt32(TxtId.Text), this.NombreAnt, TxtNombres.Text.Trim(), TxtApellidos.Text.Trim(), TxtDni.Text.Trim(), Convert.ToDateTime(DtFechaNac.Text.Trim()));
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizo de forma correcta el registro");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabCentral.SelectedIndex = 0;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas eliminar el(los) registro?", "Formulario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {

                    int Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in DgvUsuarios.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NUsuario.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino el registro: " + Convert.ToString(row.Cells[2].Value));
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                BtnActualizar.Visible = true;
                BtnInsertar.Visible = true;
                TxtId.Text = Convert.ToString(DgvUsuarios.CurrentRow.Cells["ID"].Value);
                this.NombreAnt = Convert.ToString(DgvUsuarios.CurrentRow.Cells["Nombres"].Value);
                TxtNombres.Text = Convert.ToString(DgvUsuarios.CurrentRow.Cells["Nombres"].Value);
                TxtApellidos.Text = Convert.ToString(DgvUsuarios.CurrentRow.Cells["Apellidos"].Value);
                TxtDni.Text = Convert.ToString(DgvUsuarios.CurrentRow.Cells["DNI"].Value);

                TabCentral.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione desde la celda nombre.");
            }
        }

        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccionar.Checked)
            {
                DgvUsuarios.Columns[0].Visible = true;
                BtnEliminar.Visible = true;
            }
            else
            {
                DgvUsuarios.Columns[0].Visible = false;
                BtnEliminar.Visible = false;
            }
        }
    }
}
