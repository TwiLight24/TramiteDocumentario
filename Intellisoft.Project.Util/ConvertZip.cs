using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using CSharpCode = ICSharpCode.SharpZipLib.Zip;
using Ion = Ionic.Zip;

namespace Intellisoft.Project.Util
{
    public class ConvertZip
    {

        /// <summary>
        /// Método utilizado para comprimir los archivos de un zip file
        /// </summary>
        public static bool Zip(string SrcFile, string DstFile)
        {
            bool isCreated = false;

            try
            {
                FileStream fileStreamIn = new FileStream(SrcFile, FileMode.Open, FileAccess.Read);
                FileStream fileStreamOut = new FileStream(DstFile, FileMode.Create, FileAccess.Write);
                CSharpCode.ZipOutputStream zipOutStream = new CSharpCode.ZipOutputStream(fileStreamOut);

                byte[] buffer = new byte[fileStreamIn.Length];

                CSharpCode.ZipEntry entry = new CSharpCode.ZipEntry(Path.GetFileName(SrcFile));
                zipOutStream.PutNextEntry(entry);

                int size;
                do
                {
                    size = fileStreamIn.Read(buffer, 0, buffer.Length);
                    zipOutStream.Write(buffer, 0, size);
                } while (size > 0);

                zipOutStream.Close();
                fileStreamOut.Close();
                fileStreamIn.Close();
                
                isCreated = true;
            }
            catch (Exception ex)
            {
                Log.SaveLog(ex.Message);
            }

            return isCreated;
        }

        /// <summary>
        /// Método utilizado para adicionar un nuevo archivo a un archivo zip existente.
        /// </summary>
        public static void AddFileToZip(string sourceFile, string zipFolderPath)
        {
            CSharpCode.ZipFile zipFile = new CSharpCode.ZipFile(zipFolderPath);

            zipFile.BeginUpdate();
            zipFile.UseZip64 = CSharpCode.UseZip64.On;
            zipFile.Add(sourceFile, Path.GetFileName(sourceFile));

            zipFile.CommitUpdate();
            zipFile.IsStreamOwner = true;
            zipFile.Close();

        }

        /// <summary>
        /// Método utilizado para descomprimir los archivos de un zip file
        /// </summary>
        public static bool DescromprimirZip(string ArchivoZip, string RutaGuardar)
        {
            bool isConverted = false;

            try
            {
                using (Ion.ZipFile zip = Ion.ZipFile.Read(ArchivoZip))
                {

                    zip.ExtractAll(RutaGuardar);
                    zip.Dispose();

                }

                isConverted = true;
            }
            catch(Exception ex)
            {
                Log.SaveLog(ex.Message);
            }

            return isConverted;

        }

    }
}
