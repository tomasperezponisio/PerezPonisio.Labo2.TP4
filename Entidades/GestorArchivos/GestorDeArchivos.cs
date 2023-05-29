using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades.GestorArchivos
{
    public abstract class GestorDeArchivo
    {
        #region Anidados
        public enum ETipo { XML, TXT };
        #endregion

        #region Atributos
        protected string rutaBase;
        protected ETipo tipo;
        #endregion

        #region Constructor
        protected GestorDeArchivo(ETipo tipo)
        {
            DirectoryInfo path;
            if (tipo == ETipo.TXT)
            {
                //path = Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\EstadosDeCuenta\\");
                path = Directory.CreateDirectory($"{Environment.CurrentDirectory}\\EstadosDeCuenta\\");                
            }
            else
            {
                //path = Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\BackUpListaSocios\\");
                path = Directory.CreateDirectory($"{Environment.CurrentDirectory}\\BackUpListaSocios\\");
            }
            rutaBase = path.FullName;
            this.tipo = tipo;
        } 
        #endregion
    }
}
