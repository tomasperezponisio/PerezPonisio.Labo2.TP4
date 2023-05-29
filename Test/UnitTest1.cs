using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.Exceptions;

namespace Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(RegistroPagoCuotaException))]
        public void RegistrarPago_CuandoSeIntenteRegistrarUnPagoConIgualMesYAnioDeOtroExistente_DeberiaTirarUnaException()
        {
            //Arrange
            Socio socio = new Socio("Juan", "Perez", 123, new DateTime(2000, 01, 01), Socio.EActividad.Basquet, Socio.ECategoria.Joven);
            Cuota cuota1 = new Cuota(Cuota.EMetodoDePago.Efectivo, 1000, Socio.EActividad.Basquet, new DateTime(2010, 01, 01), 321443243);
            Cuota cuota2 = new Cuota(Cuota.EMetodoDePago.Debito, 2000, Socio.EActividad.Futbol, new DateTime(2010, 01, 01), 31443243);
            bool ingresoCuota1 = (socio + cuota1);
            bool evaluate;

            //Act
            evaluate = Socio.RegistrarPago(socio, cuota2);
        }
        [TestMethod]
        public void VerificarSiEstaAlDia_CuandoELSocioTieneUnaCuotaConIgualMesYAnioAlDiaDeHoy_DeberiaRetornarTrue()
        {
            //Arrange            
            Socio socio = new Socio("Juan", "Perez", 123, new DateTime(2000, 01, 01), Socio.EActividad.Basquet, Socio.ECategoria.Joven);
            Cuota cuota = new Cuota(Cuota.EMetodoDePago.Efectivo, 1000, Socio.EActividad.Basquet, new DateTime(2022, 06, 01), 31443243);
            bool ingresoCuota = (socio + cuota);
            bool expected = true;
            bool actual;

            //Act
            actual = socio.VerificarSiEstaAlDia();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SobreCargaOperadorIgualdadDeCuota_CuandoDosCuotasTienenIgualMesYAnio_DeberiaRetornarTrue()
        {
            //Arrange            
            Cuota cuota1 = new Cuota(Cuota.EMetodoDePago.Efectivo, 1000, Socio.EActividad.Basquet, new DateTime(2010, 01, 01), 31443243);
            Cuota cuota2 = new Cuota(Cuota.EMetodoDePago.Debito, 2000, Socio.EActividad.Futbol, new DateTime(2010, 01, 01), 31443243);
            bool expected = true;
            bool actual;

            //Act
            actual = (cuota1 == cuota2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EliminarSocio_CuandoSeQuieraEliminarDeUnClubUnSocioQueNoExiste_DeberiaRetornarUnStringDiciendoQueElSocioNoSeHaEncontrado()
        {
            //Arrange            
            Club club = new Club("Test Club");
            Socio socio = new Socio("Juan", "Perez", 123, new DateTime(2000, 01, 01), Socio.EActividad.Basquet, Socio.ECategoria.Joven);
            string expected = "El socio no se ha encontrado";
            string actual;

            //Act
            actual = club.EliminarSocio(socio);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
