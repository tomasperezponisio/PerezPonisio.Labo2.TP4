# Gestor de socios del club UGAB. ABM en C#.NET (POO) y SQL.

El proyecto es un programa para gestionar a los socios de un club. En el inicio se pueden ver listados los socios del club, la lista estará vacía si no hay ningún socio o si no se ha cargado la base datos.

![Anuncios](https://i.imgur.com/Roso4EY.png)

El menú tiene siete opciones con nombres descriptivos.
- **Cargar Socio**: aquí se puede cargar un nuevo socio al club ingresando todos los datos requeridos y en su correcto formato, por ejemplo, en el campo DNI solo se podrá ingresar números, que sean mayores a 0 y menores a 99999999, y que tengan 7 u 8 dígitos.

- <img src="https://i.imgur.com/0NQfcJ7.png" style=" width:200px ; ">

```c#
/// Código del boton Aceptar en el formulario de carga, Valida los campos y en especial el dni,
/// si esta todo ok, se crea un socio con estos datos y se agrega al club que recibió como
/// parametro al ser instanciado el formulario (y a la base de datos). Fallas en la
/// validacion de los datos arrojaran las excepciones que correspondan.
private void btnAceptar_Click(object sender, EventArgs e)
{
    try
    {
        this.ValidarCampos();
        this.ValidarDniExistente(int.Parse(this.txtDni.Text));

        string nombre = this.txtNombre.Text;
        string apellido = this.txtApellido.Text;
        int dni = int.Parse(this.txtDni.Text);
        DateTime fechaNacimiento = this.dtpFechaNacimiento.Value;
        Socio.ECategoria categoria = (Socio.ECategoria)this.cmbEnum1.SelectedItem;
        Socio.EActividad actividad = (Socio.EActividad)this.cmbEnum2.SelectedItem;

        Socio socio = new Socio(nombre, apellido, dni, fechaNacimiento, actividad, categoria);
        string mensaje = string.Empty;

        if (this.IngresarSocio(this.club, socio))
        {
            GestorSQL.AltaSocio(socio);
            MessageBox.Show("Socio agreado con éxito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
    catch (DniInvalidoException ex)
    {
        MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    catch (CampoVacioException ex)
    {
        MessageBox.Show(ex.Message, "Error al cargar los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    catch (IngresoAlClubException ex)
    {
        MessageBox.Show(ex.Message, "Error al ingresar al club", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    catch (ExceptionSQL ex)
    {
        MessageBox.Show(ex.Message, "Error al ingresar al club", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }            
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

```c#
/// EL metodo para ingresaro un socio al club, utiliza la sobre carga de los
/// operadores == y + que se programó en la Entidad club.
/// Recibe un club y un socio como parametros e intenta agregar el socio a la lista
/// de socios del club, si no se puede arroja una exception
private bool IngresarSocio(Club club, Socio socio)
{
    if (!(this.club != socio && club + socio))
    {
        throw new IngresoAlClubException("No se pudo agregar el socio");
    }
    return true;
} 
```

```c#
/// Sobrecarga del operador de igualdad entre un club y un socio, si el club tiene
/// ese socio en la lista de socios que tiene como atrubuto, devuelve true, si el
/// socio no se encuentra devuelve false

public static bool operator ==(Club c, Socio s)
{
    bool retorno = false;
    if (c is not null && s is not null)
    {
        foreach (Socio item in c.listaSocios)
        {
            if (item == s)
            {
                retorno = true;
            }
        }
    }
    return retorno;
}
public static bool operator !=(Club c, Socio s)
{
    return !(c == s);
}
```


- **Modificar Socio**: En un formulario muy similar al de carga, con un socio seleccionado de la lista, se pueden modificar sus datos menos el de DNI, si se quiere modificar un DNI, hay que eliminar el socio y crearlo de nuevo.

- **Estado de Cuenta**: Con un socio seleccionado se puede ver su estado de cuenta, esto es el historial de pagos de su cuota de socio y ver si debe o está al día. Un socio es deudor cuando no está paga la cuota correspondiente al último mes. Esta información se puede imprimir, se genera un archivo de texto con los datos del socio, el historial de pagos y el estado de la cuenta.

- <img src="https://i.imgur.com/xcBX9sM.png" style=" width:800px ; ">

```c#
/// Carga los datos del socio en los campos, cargo la lista de cuotas
/// del socio al lisbox y llamando a la funcion VerificarSiEstaAlDia()
/// verifico si esta al dia con las cuotas y cambio el texto
/// y el color del label lblEstaAlDia
private void frmEstadoDeCuenta_Load(object sender, EventArgs e)
{
    try
    {
        this.txtNombre.Text = socio.Nombre;
        this.txtApellido.Text = socio.Apellido;
        this.txtDni.Text = socio.Dni.ToString();
        socio.HistorialDePagos = GestorSQL.LeerCuotasDeSocio(this.socio);
        socio.HistorialDePagos.Sort((Cuota c1, Cuota c2) => string.Compare(c1.MesCuota, c2.MesCuota));
        this.lstHistorialDePagos.DataSource = socio.HistorialDePagos;

        if (socio.VerificarSiEstaAlDia())
        {
            this.lblEstaAlDia.ForeColor = Color.Green;
            this.lblEstaAlDia.Text = "Esta al día";
        }
        else
        {
            this.lblEstaAlDia.ForeColor = Color.Red;
            this.lblEstaAlDia.Text = "Debe";
        }
    }
    catch (ExceptionSQL ex)
    {
        MessageBox.Show(ex.Message, "Error al mostrar las cuotas", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error al mostrar las cuotas", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

```c#
/// Cada socio tiene como atributo una List con el historial de pagos de cuotas,
/// con este metodo se recorre dicha lista en busca de una cuota con
/// el mismo mes y anio al momento de la consulta, retorna true si la encuentra
public bool VerificarSiEstaAlDia()
{
    bool retorno = false;

    string mesActual = DateTime.Now.ToString("MM");
    string anioActual = DateTime.Now.ToString("yyyy");

    foreach (Cuota cuota in this.historialDePagos)
    {
        if (cuota.MesCuota == mesActual && cuota.AnioCuota == anioActual)
        {
            retorno = true;
        }
    }
    return retorno;
}
```



- **Pagar Cuota**: Aquí se puede pagar una cuota del socio seleccionado, se deberá ingresar el importe, fecha, la actividad y el método de pago y el registro se agregará automáticamente al historial de pagos (estado de cuenta) del socio. No se puede pagar dos veces el mismo mes, el sistema avisa con un mensaje.

- **Eliminar Socio**: Con un socio seleccionado se puede eliminar del club, hay un pedido de confirmación previo.

- **Exportar Lista**: Exporta los datos del club en un archivo xml a modo de backup.

- **Leer Base de Datos**: Carga la base de datos (SQL) de socios para comenzar a gestionar al club, en un label a su derecha se indica el estado de carga de los datos.

