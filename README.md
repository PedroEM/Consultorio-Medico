# Proyecto Registro de Pacientes - Mate con Burrito

## Descripción del Proyecto

El proyecto "Registro de Pacientes" tiene como objetivo crear un sistema de registro y gestión de pacientes en una clínica médica. Permite a los usuarios registrar nuevos pacientes, almacenar su información médica y administrativa, realizar búsquedas y generar informes.

## Funcionalidades Clave

1. **Registro de Pacientes:** Los usuarios pueden ingresar los detalles personales de los pacientes, como nombre, fecha de nacimiento, género, dirección, número de contacto, etc.

2. **Información Médica:** Se pueden agregar detalles médicos de los pacientes, como historial de enfermedades, alergias, medicamentos recetados, etc.

3. **Búsqueda de Pacientes:** Los usuarios pueden buscar pacientes por su nombre, número de identificación u otros criterios.

4. **Generación de Informes:** El sistema permite generar informes en formato PDF que contienen la información relevante de los pacientes, como su información personal y médica.

## Dependencias Utilizadas

El proyecto hace uso de varias bibliotecas y paquetes de terceros para su implementación. Las dependencias utilizadas son las siguientes:

- **BouncyCastle 1.8.9:** Librería de criptografía que proporciona implementaciones de algoritmos criptográficos.
- **Entity Framework 6.4.4:** ORM (Mapeo Objeto-Relacional) que facilita la interacción con la base de datos y simplifica las operaciones CRUD.
- **EPPlus 6.2.6:** Librería para la generación y manipulación de archivos Excel (xlsx).
- **iTextSharp 5.5.13.3:** Librería utilizada para la creación y manipulación de archivos PDF.
- **Microsoft.IO.RecyclableMemoryStream 1.4.1:** Implementación mejorada de MemoryStream para mejorar la eficiencia en la manipulación de datos en memoria.
- **System.Data.SQLite:** Librería para la integración de la base de datos SQLite en aplicaciones .NET.

## Estructura del Proyecto

El proyecto sigue una estructura típica de una aplicación de escritorio en C# .NET. A continuación, se describe brevemente la estructura de carpetas y archivos:

- **PacientesApp:** Carpeta principal del proyecto.
  - **Models:** Contiene las clases de modelos, como "Paciente" para representar la información del paciente.
  - **DataAccess:** Contiene las clases para interactuar con la base de datos, utilizando Entity Framework y SQLite.
  - **Services:** Contiene la lógica de negocio y servicios relacionados con la gestión de pacientes y generación de informes.
  - **UI:** Contiene las clases relacionadas con la interfaz de usuario, como formularios y vistas.
  - **Reports:** Almacena plantillas y archivos generados de informes en PDF y Excel.
  - **Program.cs:** Punto de entrada de la aplicación.

## Instrucciones de Ejecución

1. Clona o descarga el repositorio del proyecto desde [enlace al repositorio].
2. Abre el proyecto en tu entorno de desarrollo preferido (por ejemplo, Visual Studio).
3. Restaura las dependencias del proyecto utilizando NuGet Package Manager.
4. Asegúrate de que las referencias a las dependencias estén configuradas correctamente.
5. Compila y ejecuta la aplicación.
