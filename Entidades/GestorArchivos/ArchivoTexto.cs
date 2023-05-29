using Entidades.Exceptions;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.GestorArchivos
{
    public class ArchivoTexto : GestorDeArchivo, IArchivos<string>
    {
        #region Constructor
        public ArchivoTexto() : base(ETipo.TXT)
        {

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Recibe un string con el contenido a guardar y utilizando un StreamWriter escribe un archivo .txt en la ruta que tiene definida en
        /// la clase madre y con el nombre que recibe como string. Si el parametro append es true, agrega el contenido recibido si borrar lo que haya en el documento.
        /// Si no se pudo escribir el archivo, arroja una exception. Y al final cierra el StreamWriter
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        /// <param name="append"></param>
        /// <exception cref="ArchivoInvalidoException"></exception>
        //public void Escribir(string nombreArchivo, string contenido, bool append)
        //{
        //    StreamWriter streamWriter = null;
        //    try
        //    {
        //        streamWriter = new StreamWriter($"{rutaBase}\\{nombreArchivo}", append);
        //        streamWriter.WriteLine(contenido);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArchivoInvalidoException("Error al escribir el archivo", ex);
        //    }
        //    finally
        //    {
        //        if (streamWriter != null)
        //        {
        //            streamWriter.Close();
        //        }
        //    }
        //}
        /// <summary>
        /// Recibe un string con el contenido a guardar y utilizando un StreamWriter escribe un archivo .txt en la ruta que tiene definida en
        /// la clase madre y con el nombre que recibe como string. 
        /// Si no se pudo escribir el archivo, arroja una exception. Y al final cierra el StreamWriter
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="contenido"></param>
        /// <exception cref="ArchivoInvalidoException"></exception>
        public void Escribir(string nombreArchivo, string contenido)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter($"{rutaBase}\\{nombreArchivo}"))
                {
                    streamWriter.WriteLine(contenido);
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoInvalidoException("Error al escribir el archivo", ex);
            }
        }
        /// <summary>
        /// Recibe un string con la ubicacion y nombre de un archivo y utilizando StreamReader intenta leer el contenido y
        /// de ser posible guardarlo en un string, si no se pudo arroja exception.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns>string</returns>
        /// <exception cref="ArchivoInvalidoException"></exception>
        public string Leer(string nombreArchivo)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader($"{rutaBase}\\{nombreArchivo}"))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoInvalidoException("Error al leer el archivo", ex);
            }
        }
        /// <summary>
        /// Retorna en un string la ruta donde se guardan los archivos
        /// </summary>
        /// <returns></returns>
        public string RutaDeEscritura()
        {
            return $"{rutaBase}";
        } 
        #endregion
    }
}
