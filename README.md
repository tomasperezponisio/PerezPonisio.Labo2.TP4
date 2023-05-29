# Gestor de socios del club UGAB. ABM en C#.NET (POO) y SQL.

El proyecto es un programa para gestionar a los socios de un club. En el inicio se pueden ver listados los socios del club, la lista estará vacía si no hay ningún socio o si no se ha cargado la base datos.

![Anuncios](https://i.imgur.com/Roso4EY.png)

El menú tiene siete opciones con nombres descriptivos.
- **Cargar Socio**: aquí se puede cargar un nuevo socio al club ingresando todos los datos requeridos y en su correcto formato, por ejemplo, en el campo DNI solo se podrá ingresar números, que sean mayores a 0 y menores a 99999999, y que tengan 7 u 8 dígitos.

- <img src="https://i.imgur.com/0NQfcJ7.png" style=" width:200px ;  "  >

- **Modificar Socio**: Con un socio seleccionado de la lista, se pueden modificar sus datos menos el de DNI, si se quiere modificar un DNI, hay que eliminar el socio y crearlo de nuevo.

- **Estado de Cuenta**: Con un socio seleccionado se puede ver su estado de cuenta, esto es el historial de pagos de su cuota de socio y ver si debe o está al día. Un socio es deudor cuando no está paga la cuota correspondiente al último mes. Esta información se puede imprimir, se genera un archivo de texto con los datos del socio, el historial de pagos y el estado de la cuenta.

- **Pagar Cuota**: Aquí se puede pagar una cuota del socio seleccionado, se deberá ingresar el importe, fecha, la actividad y el método de pago y el registro se agregará automáticamente al historial de pagos (estado de cuenta) del socio. No se puede pagar dos veces el mismo mes, el sistema avisa con un mensaje.

- **Eliminar Socio**: Con un socio seleccionado se puede eliminar del club, hay un pedido de confirmación previo.

- **Exportar Lista**: Exporta los datos del club en un archivo xml a modo de backup.

- **Leer Base de Datos**: Carga la base de datos (SQL) de socios para comenzar a gestionar al club, en un label a su derecha se indica el estado de carga de los datos.

