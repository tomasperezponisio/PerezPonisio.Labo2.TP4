using Entidades.Interfaces;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entidades.Exceptions;
using System.Text.Json;

namespace Entidades.GestorArchivos
{
    public class Serializer<T> : GestorDeArchivo, IArchivos<T> where T : class, new()
    {
        #region Constructor
        public Serializer(ETipo tipo) : base(tipo)
        {
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Recibe un objeto generico y utilizando un XmlTextWriter escribe un archivo xml en la ruta que tiene definida en
        /// la clase madre y con el nombre que recibe como string.
        /// Si el nombre del archivo no tiene la extension .xml arroja una exception.         
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="elemento"></param>
        /// <exception cref="ArchivoInvalidoException"></exception>
        public void Escribir(string nombreArchivo, T elemento)
        {
            try
            {
                if (Path.GetExtension(nombreArchivo) == ".xml")
                {
                    using (XmlTextWriter xmlTextWriter = new XmlTextWriter($"{rutaBase}\\{nombreArchivo}", Encoding.UTF8))
                    {
                        xmlTextWriter.Formatting = Formatting.Indented;
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        serializer.Serialize(xmlTextWriter, elemento);
                    }
                }
                else
                {
                    throw new ArchivoInvalidoException("Extension invalida, se esperaba XML");
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoInvalidoException("Error al Serializar", ex);
            }
        }
        /// <summary>
        /// Recibe un nombre de archivo y utilizando XmlTextReader intenta leerlo y convertirlo a un objeto.
        /// Si el nombre del archivo no tiene la extension .xml arroja una exception.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        /// <exception cref="ArchivoInvalidoException"></exception>
        public T Leer(string nombreArchivo)
        {
            try
            {
                if (Path.GetExtension(nombreArchivo) == ".xml")
                {
                    using (XmlTextReader xmlTextReader = new XmlTextReader($"{rutaBase}\\{nombreArchivo}"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        return serializer.Deserialize(xmlTextReader) as T;
                    }
                }
                else
                {
                    throw new ArchivoInvalidoException("Extension invalida, se esperaba XML");
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoInvalidoException("Error al DesSerializar", ex);
            }
        }
        /// <summary>
        /// Retorna en un string la ruta donde se guardan los archivos
        /// </summary>
        /// <returns>string</returns>
        public string RutaDeEscritura()
        {
            return $"{rutaBase}";
        }
        #endregion
    }
}
