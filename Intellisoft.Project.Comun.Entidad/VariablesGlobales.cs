using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intellisoft.Project.Comun.Entidad
{
    public class VariablesGlobales
    {

        public class ParametroConst
        {
            /// <summary>
            /// Tipos de Documento
            /// </summary>
            public const short TipoDocumentos = 1;
            /// <summary>
            /// Tipos de Autenticacion
            /// </summary>
            public const short TipoAutenticacion = 2;
            /// <summary>
            /// Rutas de Aplicación
            /// </summary>
            public const short Rutas = 3;
            /// <summary>
            /// Prefijo para Personas (Tratamiento) 
            /// </summary>
            public const short Prefijos = 4;
            /// <summary>
            /// Tipos de Planificación
            /// </summary>
            public const short TiposPlanificacion = 5;
            /// <summary>
            /// Modalidad Contrato (Tipos y Total Horas Dia)
            /// </summary>
            public const short ModalidadContrato = 6;
            /// <summary>
            /// Actividades de Ausencia
            /// </summary>
            public const short ActividadesAusencia = 7;
            /// <summary>
            /// Entidades Solicitantes
            /// </summary>
            public const short EntidadesSolicitantes = 8;
            /// <summary>
            /// Tipo de Periodo
            /// </summary>
            public const short TipodePeriodo = 9;
            /// <summary>
            /// Estado Periodo Empleado
            /// </summary>
            public const short EstadoPeriodoEmpleado = 10;
            /// <summary>
            /// Estado Periodo
            /// </summary>
            public const short EstadoPeriodo = 11;
            /// <summary>
            /// Feriados Nacionales (Perú)
            /// </summary>
            public const short FeriadosNacionales = 12;
            /// <summary>
            /// Tipo de Feriado
            /// </summary>
            public const short TipoFeriado = 13;
            /// <summary>
            /// Extensiones de Archivos
            /// </summary>
            public const short ExtensionesArchivos = 14;
            /// <summary>
            /// Parámetros Servicio Correo
            /// </summary>
            public const short ParamServicioCorreo = 15;
            /// <summary>
            /// Rutas de Reportes
            /// </summary>
            public const short RutasReportes = 16;
            /// <summary>
            /// Áreas Organización
            /// </summary>
            public const short AreasOrganización = 17;
            /// <summary>
            /// Parámetros Sistema
            /// </summary>
            public const short Sistema = 18;
            /// <summary>
            /// Parámetros LDAP
            /// </summary>
            public const short ParaLDAP = 19;
            /// <summary>
            /// Validaciones de Archivos
            /// </summary>
            public const short ValidacionesArchivos = 20;
            /// <summary>
            /// Alertas Timesheet
            /// </summary>
            public const short AlertasTimesheet = 21;
        }

        public class Rutas
        {
            /// <summary>
            /// Ruta del Servidor
            /// </summary>
            public const int Servidor = 1;
            /// <summary>
            /// Ruta de la carpeta principal
            /// </summary>
            public const int Principal = 2;
            /// <summary>
            /// Ruta de los archivos
            /// </summary>
            public const int Datos = 3;
            /// <summary>
            /// Ruta de las imágenes
            /// </summary>
            public const int Imagenes = 4;
            /// <summary>
            /// Ruta de los archivos temporales
            /// </summary>
            public const int Temporales = 5;
            /// <summary>
            /// Ruta del Servidor de Archivos
            /// </summary>
            public const int ServidorArchivos = 6;
            /// <summary>
            /// Ruta de los logs de eventos del sistema
            /// </summary>
            public const int Logs = 7;
        }

        public class TimeAndConversionConst
        {
            /// <summary>
            /// Milisegundos por segundo
            /// </summary>
            public const int MillisecondsBySecond = 1000;
            /// <summary>
            /// Milisegundos por minuto
            /// </summary>
            public const int MillisecondsByMinute = MillisecondsBySecond * 60;
            /// <summary>
            /// Milisegundos por hora
            /// </summary>
            public const int MillisecondsByHour = MillisecondsByMinute * 60;
            /// <summary>
            /// Segundos por minuto
            /// </summary>
            public const int SecondsByMinute = 60;
            /// <summary>
            /// Segundos por hora
            /// </summary>
            public const int SecondsByHour = SecondsByMinute * 60;
            /// <summary>
            /// Minutos por hora
            /// </summary>
            public const int MinutesByHour = 60;
        }

        public class TipoAutenticacionConst
        {
            /// <summary>
            /// Tipo de Autenticacion TimeSheet
            /// </summary>
            public const string Documentario = "S";
            /// <summary>
            /// Tipo de Autenticacion TimeSheet
            /// </summary>
            public const string Utiles = "U";
            /// <summary>
            /// Tipo de Autenticacion Windows
            /// </summary>
            public const string Windows = "W";
            /// <summary>
            /// Ambos Tipos de Autenticacion
            /// </summary>
            public const string Ambas = "A";
        }

        public class TiposPlanificacionConst
        {
            /// <summary>
            /// Tipo de Autenticacion TimeSheet
            /// </summary>
            public const string Planificado = "P";
            /// <summary>
            /// Tipo de Autenticacion TimeSheet
            /// </summary>
            public const string NoPlanificado = "N";
        }

        public class TiposActividadesConst
        {
            /// <summary>
            /// Día Laborado
            /// </summary>
            public const string DiaLaborado = "DLB";
            /// <summary>
            /// Descanso Compensatorio
            /// </summary>
            public const string DesCompensatorio = "DCO";
            /// <summary>
            /// Descanso Médico
            /// </summary>
            public const string DesMedico = "DME";
            /// <summary>
            /// Feriado
            /// </summary>
            public const string Feriado = "FER";
            /// <summary>
            /// Licencia con Goce
            /// </summary>
            public const string LicenciaGoce = "LGC";
            /// <summary>
            /// Vacaciones
            /// </summary>
            public const string Vacaciones = "VAC";
        }

        public class TipoConsultaRegHoras
        {
            /// <summary>
            /// Consulta Empresas Seleccionadas de un Empleado
            /// </summary>
            public const string ConsultaEmpresa = "E";
            /// <summary>
            /// Consulta el total de Empresas (Seleccionadas y Asociadas) de un Empleado
            /// </summary>
            public const string TotalEmpresasEmpleado = "T";
            /// <summary>
            /// Consulta Proyectos asociadas a un Empleado
            /// </summary>
            public const string ConsultaProyecto = "P";
            /// <summary>
            /// Consulta las Empresas Asignadas de un Empleado
            /// </summary>
            public const string EmpresasAsignadas = "ASG";
            /// <summary>
            /// Consulta las Empresas Seleccionadas de un Empleado
            /// </summary>
            public const string EmpresasSeleccionadas = "SEL";
            /// <summary>
            /// Consulta las Empresas Pendientes de Aprobación
            /// </summary>
            public const string EmpresasPendientes = "PEN";
        }

        public class Indicadores
        {
            public const string Aprobado = "A";
            public const string NoAprobado = "N";
            public const string PendienteAprobacion = "P";
        }

        public class TipoSolicitantes
        {
            /// <summary>
            /// Tipo de Solicitante : Área
            /// </summary>
            public const string Area = "A";
            /// <summary>
            /// Tipo de Solicitante : Persona
            /// </summary>
            public const string Persona = "P";
        }

        public class TiposEstadosPeriodos
        {
            /// <summary>
            /// Periodo Aprobado
            /// </summary>
            public const string Aprobado = "APR";
            /// <summary>
            /// Periodo Aprobado
            /// </summary>
            public const string Ingresado = "INGRESADO";
            /// <summary>
            /// Periodo En Proceso
            /// </summary>
            public const string EnProceso = "EPR";    
            /// <summary>
            /// Periodo Pendiente de Aprobación
            /// </summary>
            public const string PendienteAprobación = "PAP";
            /// <summary>
            /// Periodo Rechazado
            /// </summary>
            public const string Rechazado = "REC";
        }

        public class TiposEstadosConsolidado
        {            
            /// <summary>
            /// Consolidado Aprobado (Final)
            /// </summary>
            public const string AprobadoFinal = "APR";
            /// <summary>
            /// Consolidado Aprobación Parcial
            /// </summary>
            public const string AprobacionParcial = "APP";
            /// <summary>
            /// Consolidado Pendiente de Aprobación (Estado Inicial)
            /// </summary>
            public const string PendienteAprobación = "PAP";
            /// <summary>
            /// Consolidado Rechazado
            /// </summary>
            public const string Rechazado = "REC";
            /// <summary>
            /// En Proceso
            /// </summary>
            public const string EnProceso = "EPR";
        }

        public class TiposEstadosConsolidadoEvento
        {
            /// <summary>
            /// Consolidado Aprobado
            /// </summary>
            public const string Aprobado = "APR";
            
            /// <summary>
            /// Consolidado Rechazado
            /// </summary>
            public const string Rechazado = "REC";
        }

        public class OpcionEmpleadoAdministrador
        {
            /// <summary>
            /// Consolidado Aprobado
            /// </summary>
            public const int AdmConsolidado = 1;

            /// <summary>
            /// Consolidado Rechazado
            /// </summary>
            public const int AdmAprobador = 2;
        }

        public class ValidacionesArchivos
        {
            public const string FileSize = "FileSize";
            public const string EXE = "EXE";
            public const string COM = "COM";
            public const string BAT = "BAT";
            public const string DLL = "DLL";
        }

        public class AlertasTimesheet
        {
            public const string SesionExpire = "SesionExpire";
        }

        public class Rol
        {
            public const int Administrador = 1;
            public const int Empleado = 2;
            public const int Supervisor = 3;
            public const int AdministradorConsolidado = 4;
            public const int AdministradorAprobador = 5;
        }

    }
}
