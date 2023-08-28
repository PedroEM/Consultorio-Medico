using System;
using System.Data;
using System.IO;
using OfficeOpenXml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SQLite;
using System.Xml.Linq;

namespace ConsultorioMedico
{
    internal class GenerarInformes
    {
        ConexionDB db = new ConexionDB(Path.Combine(Environment.CurrentDirectory, "ConsultorioMedico.db"));

        public void GenerarInformePDF(int pacienteId)
        {
            db.AbrirConexion();
            DataTable datosPaciente = db.BuscarPacientePorID(pacienteId);
            DataTable historiaClinica = db.GetHistoriaMedicaPorID(pacienteId);
            DataTable citas = db.GetCitaPorID(pacienteId);

            // Crear el documento PDF
            Document document = new Document();
            string folderPath = Path.Combine(Environment.CurrentDirectory, "Informes");
            Directory.CreateDirectory(folderPath);

            string fileName = $"Informe_{datosPaciente.Rows[0]["nombre"]}.pdf";
            string filePath = Path.Combine(folderPath, fileName);

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Agregar el resumen de datos del paciente
            PdfPTable pacienteTable = new PdfPTable(2);
            pacienteTable.WidthPercentage = 100;
            pacienteTable.HorizontalAlignment = Element.ALIGN_LEFT;

            pacienteTable.AddCell("Nombre:");
            pacienteTable.AddCell(datosPaciente.Rows[0]["nombre"].ToString());

            pacienteTable.AddCell("Fecha de Nacimiento:");
            pacienteTable.AddCell(datosPaciente.Rows[0]["fecha_nacimiento"].ToString());

            pacienteTable.AddCell("Género:");
            pacienteTable.AddCell(datosPaciente.Rows[0]["genero"].ToString());

            pacienteTable.AddCell("Dirección:");
            pacienteTable.AddCell(datosPaciente.Rows[0]["direccion"].ToString());

            pacienteTable.AddCell("Datos de Contacto:");
            pacienteTable.AddCell(datosPaciente.Rows[0]["datos_contacto"].ToString());

            document.Add(pacienteTable);

            // Agregar el resumen de historia clínica
            PdfPTable historiaClinicaTable = new PdfPTable(5);
            historiaClinicaTable.WidthPercentage = 100;
            historiaClinicaTable.HorizontalAlignment = Element.ALIGN_LEFT;

            historiaClinicaTable.AddCell("Fecha de Consulta");
            historiaClinicaTable.AddCell("Motivo de Consulta");
            historiaClinicaTable.AddCell("Detalles de la Visita");
            historiaClinicaTable.AddCell("Estudios Médicos");
            historiaClinicaTable.AddCell("Medicación Suministrada");

            foreach (DataRow row in historiaClinica.Rows)
            {
                historiaClinicaTable.AddCell(row["fecha_consulta"].ToString());
                historiaClinicaTable.AddCell(row["motivo_consulta"].ToString());
                historiaClinicaTable.AddCell(row["detalles_visita"].ToString());
                historiaClinicaTable.AddCell(row["estudios_medicos"].ToString());
                historiaClinicaTable.AddCell(row["medicacion_suministrada"].ToString());
            }

            document.Add(new Paragraph("Resumen de Historia Clínica"));
            document.Add(historiaClinicaTable);

            // Agregar el registro de citas para la fecha específica
            PdfPTable citasTable = new PdfPTable(citas.Columns.Count);
            citasTable.WidthPercentage = 100;
            citasTable.HorizontalAlignment = Element.ALIGN_LEFT;

            // Encabezados de columna
            for (int col = 0; col < citas.Columns.Count; col++)
            {
                citasTable.AddCell(citas.Columns[col].ColumnName);
            }

            // Datos de las citas
            foreach (DataRow row in citas.Rows)
            {
                for (int col = 0; col < citas.Columns.Count; col++)
                {
                    citasTable.AddCell(row[col].ToString());
                }
            }

            document.Add(new Paragraph("Registro de Citas"));
            document.Add(citasTable);

            // Cerrar el documento PDF
            document.Close();
            db.CerrarConexion();
        }

        public void GenerarInformeExcel(int pacienteId)
        {
            DataTable datosPaciente = db.BuscarPacientePorID(pacienteId);
            DataTable historiaClinica = db.GetHistoriaMedicaPorID(pacienteId);
            DataTable citas = db.GetCitaPorID(pacienteId);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Informe");

                // Agregar los datos del paciente
                worksheet.Cells["A1"].Value = "Nombre:";
                worksheet.Cells["B1"].Value = datosPaciente.Rows[0]["nombre"].ToString();

                worksheet.Cells["A2"].Value = "Fecha de Nacimiento:";
                worksheet.Cells["B2"].Value = datosPaciente.Rows[0]["fecha_nacimiento"].ToString();

                worksheet.Cells["A3"].Value = "Género:";
                worksheet.Cells["B3"].Value = datosPaciente.Rows[0]["genero"].ToString();

                worksheet.Cells["A4"].Value = "Dirección:";
                worksheet.Cells["B4"].Value = datosPaciente.Rows[0]["direccion"].ToString();

                worksheet.Cells["A5"].Value = "Datos de Contacto:";
                worksheet.Cells["B5"].Value = datosPaciente.Rows[0]["datos_contacto"].ToString();

                // Agregar el resumen de historia clínica
                int row = 7;
                worksheet.Cells[row, 1].Value = "Fecha de Consulta";
                worksheet.Cells[row, 2].Value = "Motivo de Consulta";
                worksheet.Cells[row, 3].Value = "Detalles de la Visita";
                worksheet.Cells[row, 4].Value = "Estudios Médicos";
                worksheet.Cells[row, 5].Value = "Medicación Suministrada";
                row++;

                foreach (DataRow dataRow in historiaClinica.Rows)
                {
                    worksheet.Cells[row, 1].Value = dataRow["fecha_consulta"].ToString();
                    worksheet.Cells[row, 2].Value = dataRow["motivo_consulta"].ToString();
                    worksheet.Cells[row, 3].Value = dataRow["detalles_visita"].ToString();
                    worksheet.Cells[row, 4].Value = dataRow["estudios_medicos"].ToString();
                    worksheet.Cells[row, 5].Value = dataRow["medicacion_suministrada"].ToString();
                    row++;
                }

                // Agregar el registro de citas para la fecha específica
                row += 2;
                worksheet.Cells[row, 1].Value = "Registro de Citas";
                row++;

                for (int col = 0; col < citas.Columns.Count; col++)
                {
                    worksheet.Cells[row, col + 1].Value = citas.Columns[col].ColumnName;
                }

                row++;

                foreach (DataRow dataRow in citas.Rows)
                {
                    for (int col = 0; col < citas.Columns.Count; col++)
                    {
                        worksheet.Cells[row, col + 1].Value = dataRow[col].ToString();
                    }
                    row++;
                }

                // Guardar el archivo Excel
                string folderPath = Path.Combine(Environment.CurrentDirectory, "Informes");
                Directory.CreateDirectory(folderPath);

                string fileName = $"Informe_{datosPaciente.Rows[0]["nombre"]}.xlsx";
                string filePath = Path.Combine(folderPath, fileName);

                FileInfo excelFile = new FileInfo(filePath); 
                excelPackage.SaveAs(excelFile);
            }
        }
    }
}
