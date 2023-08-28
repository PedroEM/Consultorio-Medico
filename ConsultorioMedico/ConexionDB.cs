// Importación de las librerías necesarias
using System;
using System.Data;
using System.Data.SQLite;

// Definición del espacio de nombres
namespace ConsultorioMedico
{
    // Definición de la clase ConexionDB que se encargará de manejar la conexión a la base de datos
    internal class ConexionDB
    {
        // Atributos de la clase
        private string connectionString; // Cadena de conexión a la base de datos
        private SQLiteConnection connection; // Objeto de conexión a la base de datos

        // Constructor de la clase
        public ConexionDB(string dbFilePath)
        {
            // Inicialización de la cadena de conexión
            connectionString = $"Data Source={dbFilePath};Version=3;";
            // Inicialización de la conexión
            connection = new SQLiteConnection(connectionString);
        }

        // Método para abrir la conexión a la base de datos
        public void AbrirConexion()
        {
            // Si la conexión no está abierta, la abrimos
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        // Método para cerrar la conexión a la base de datos
        public void CerrarConexion()
        {
            // Si la conexión no está cerrada, la cerramos
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        // Método para obtener todos los pacientes
        public DataTable GetPacientes()
        {
            string query = "SELECT * FROM Pacientes"; // Consulta SQL
            return EjecutarQuery(query); // Ejecutamos la consulta y devolvemos el resultado
        }

        // Método para buscar un paciente por su nombre
        public DataTable BuscarPaciente(string searchQuery)
        {
            // Consulta SQL con el parámetro de búsqueda
            string query = $"SELECT * FROM Pacientes WHERE nombre = \"{searchQuery}\"";
            return EjecutarQuery(query); // Ejecutamos la consulta y devolvemos el resultado
        }

        // Método para buscar un paciente por su ID
        public DataTable BuscarPacientePorID(int id)
        {
            // Consulta SQL con el ID del paciente
            string query = $"SELECT * FROM Pacientes WHERE id_paciente = {id}";
            return EjecutarQuery(query); // Ejecutamos la consulta y devolvemos el resultado
        }

        // Método para añadir un nuevo paciente
        public int AddPaciente(string name, DateTime birthDate, string gender, string address, string contact)
        {
            // Consulta SQL para insertar un nuevo paciente
            string query = $"INSERT INTO Pacientes (nombre, fecha_nacimiento, genero, direccion, datos_contacto) VALUES (\"{name}\", \"{birthDate.ToString("yyyy-MM-dd")}\", \"{gender}\", \"{address}\", \"{contact}\")";
            return EjecutarNonQuery(query); // Ejecutamos la consulta y devolvemos el número de filas afectadas
        }

        // Método para actualizar los datos de un paciente
        public int UpdatePaciente(int patientId, string name, DateTime birthDate, string gender, string address, string contact)
        {
            // Consulta SQL para actualizar un paciente
            string query = $"UPDATE Pacientes SET nombre = \"{name}\", fecha_nacimiento = \"{birthDate.ToString("yyyy-MM-dd")}\", genero = \"{gender}\", direccion = \"{address}\", datos_contacto = \"{contact}\" WHERE id_paciente = {patientId}";
            return EjecutarNonQuery(query); // Ejecutamos la consulta y devolvemos el número de filas afectadas
        }

        // Método para borrar un paciente
        public int BorrarPaciente(int patientId)
        {
            // Consulta SQL para borrar un paciente
            string query = $"DELETE FROM Pacientes WHERE id_paciente = {patientId}";
            return EjecutarNonQuery(query); // Ejecutamos la consulta y devolvemos el número de filas afectadas
        }

        // Método para obtener todas las citas
        public DataTable GetCita()
        {
            string query = "SELECT * FROM Citas"; // Consulta SQL
            return EjecutarQuery(query); // Ejecutamos la consulta y devolvemos el resultado
        }

        // Método para obtener las citas por fecha
        public DataTable GetCitaPorFecha(DateTime date)
        {
            // Consulta SQL con la fecha de la cita
            string query = $"SELECT * FROM Citas WHERE fecha_hora >= \"{date.ToString("yyyy-MM-dd 00:00:00")}\" AND fecha_hora <= \"{date.ToString("yyyy-MM-dd 23:59:59")}\"";
            return EjecutarQuery(query); // Ejecutamos la consulta y devolvemos el resultado
        }

        // Método para añadir una nueva cita
        public int AddCita(int patientId, DateTime appointmentDate, string reason)
        {
            // Consulta SQL para insertar una nueva cita
            string query = $"INSERT INTO Citas (fecha_hora, id_paciente, motivo_consulta) VALUES (\"{appointmentDate.ToString("yyyy-MM-dd HH:mm:ss")}\", {patientId}, \"{reason}\")";
            return EjecutarNonQuery(query); // Ejecutamos la consulta y devolvemos el número de filas afectadas
        }

        // Método para actualizar una cita
        public int UpdateCita(int appointmentId, DateTime appointmentDate, string reason)
        {
            // Consulta SQL para actualizar una cita
            string query = $"UPDATE Citas SET fecha_hora = \"{appointmentDate.ToString("yyyy-MM-dd HH:mm:ss")}\", motivo_consulta = \"{reason}\" WHERE id_cita = {appointmentId}";
            return EjecutarNonQuery(query); // Ejecutamos la consulta y devolvemos el número de filas afectadas
        }

        // Método para cancelar una cita
        public int CancelarCita(int appointmentId)
        {
            // Consulta SQL para borrar una cita
            string query = $"DELETE FROM Citas WHERE id_cita = {appointmentId}";
            return EjecutarNonQuery(query); // Ejecutamos la consulta y devolvemos el número de filas afectadas
        }

        // Método para obtener la historia médica de un paciente por su nombre
        public DataTable GetHistoriaMedica(string nombre)
        {
            // Consulta SQL para obtener la historia médica
            string query = $"SELECT * FROM HistoriaClinica WHERE id_paciente = (SELECT id_paciente FROM Pacientes WHERE nombre = \"{nombre}\")";
            return EjecutarQuery(query); // Ejecutamos la consulta y devolvemos el resultado
        }

        // Método para obtener la historia médica de un paciente por su ID
        public DataTable GetHistoriaMedicaPorID(int id)
        {
            // Consulta SQL para obtener la historia médica
            string query = $"SELECT * FROM HistoriaClinica WHERE id_paciente = {id}";
            return EjecutarQuery(query); // Ejecutamos la consulta y devolvemos el resultado
        }

        // Método para añadir un nuevo registro a la historia médica de un paciente
        public int AddHistoriaMedica(int patientId, DateTime visitDate, string reason, string details, string medicalTests, string medication)
        {
            // Consulta SQL para insertar un nuevo registro
            string query = $"INSERT INTO HistoriaClinica (id_paciente, fecha_consulta, motivo_consulta, detalles_visita, estudios_medicos, medicacion_suministrada) VALUES ({patientId}, \"{visitDate.ToString("yyyy-MM-dd")}\", \"{reason}\", \"{details}\", \"{medicalTests}\", \"{medication}\")";
            return EjecutarNonQuery(query); // Ejecutamos la consulta y devolvemos el número de filas afectadas
        }

        // Método para actualizar un registro de la historia médica de un paciente
        public int UpdateHistoriaMedica(int recordId, DateTime visitDate, string reason, string details, string medicalTests, string medication)
        {
            // Consulta SQL para actualizar un registro
            string query = $"UPDATE HistoriaClinica SET fecha_consulta = \"{visitDate.ToString("yyyy-MM-dd")}\", motivo_consulta = \"{reason}\", detalles_visita = \"{details}\", estudios_medicos = \"{medicalTests}\", medicacion_suministrada = \"{medication}\" WHERE id_consulta = {recordId}";
            return EjecutarNonQuery(query); // Ejecutamos la consulta y devolvemos el número de filas afectadas
        }

        // Método para borrar un registro de la historia médica de un paciente
        public int BorrarHistoriaMedica(int recordId)
        {
            // Consulta SQL para borrar un registro
            string query = $"DELETE FROM HistoriaClinica WHERE id_consulta = {recordId}";
            return EjecutarNonQuery(query); // Ejecutamos la consulta y devolvemos el número de filas afectadas
        }

        // Método para obtener una cita por el ID del paciente
        public DataTable GetCitaPorID(int patientId)
        {
            // Consulta SQL para obtener una cita
            string query = $"SELECT * FROM Citas WHERE id_paciente = {patientId}";
            return EjecutarQuery(query); // Ejecutamos la consulta y devolvemos el resultado
        }

        // Método privado para ejecutar una consulta SQL que devuelve un resultado
        private DataTable EjecutarQuery(string query)
        {
            AbrirConexion(); // Abrimos la conexión

            // Ejecutamos la consulta
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            CerrarConexion(); // Cerramos la conexión

            return dataTable; // Devolvemos el resultado
        }

        // Método privado para ejecutar una consulta SQL que no devuelve un resultado
        private int EjecutarNonQuery(string query)
        {
            AbrirConexion(); // Abrimos la conexión

            // Ejecutamos la consulta
            SQLiteCommand command = new SQLiteCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();

            CerrarConexion(); // Cerramos la conexión

            return rowsAffected; // Devolvemos el número de filas afectadas
        }
    }
}
