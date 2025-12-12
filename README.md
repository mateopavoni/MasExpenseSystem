# MasExpenseSystem - Sistema de Gestión de Gastos e Ingresos

Plataforma web desarrollada en ASP.NET Core MVC para el control integral de finanzas personales con arquitectura por capas.

## Descripción del Proyecto

Sistema web moderno para la gestión completa de ingresos y gastos personales, diseñado para usuarios que desean mantener un control detallado de sus finanzas. La plataforma permite administrar servicios (categorías), registrar transacciones y visualizar historial financiero con opciones de exportación.

**Características principales:**

- Registro y autenticación segura de usuarios
- Gestión de servicios/categorías (Ingresos y Gastos)
- Registro de transacciones con comentarios y fechas
- Historial de transacciones con filtros por rango de fechas
- Exportación de datos a múltiples formatos (Excel, PDF, CSV)
- Interfaz responsive con Bootstrap 5
- Panel de usuario personalizado

## Tecnologías y Arquitectura

### Stack Tecnológico

| Capa | Tecnología |
|------|------------|
| **Backend** | ASP.NET Core MVC (.NET 9.0) |
| **ORM** | Entity Framework Core 9.0 |
| **Base de datos** | SQL Server |
| **Frontend** | HTML5, CSS3, JavaScript ES6 |
| **Framework CSS** | Bootstrap 5 |
| **Librerías JS** | jQuery, DataTables, SweetAlert2, Select2 |
| **Autenticación** | Cookie Authentication |
| **Variables de entorno** | DotNetEnv |

### Arquitectura por Capas

El proyecto implementa una arquitectura organizada en capas:

- **Controllers** → Manejo de requests HTTP y coordinación
- **Managers** → Lógica de negocio y operaciones
- **Entities** → Modelos de dominio (User, Service, Transaction)
- **Models/DTOs** → ViewModels y objetos de transferencia de datos
- **Context** → Configuración de Entity Framework y DbContext
- **Views** → Presentación con Razor Pages

## Requisitos del Sistema

### Requisitos Mínimos

- .NET 9.0 SDK o superior
- SQL Server 2019+ (o SQL Server Express)
- Visual Studio 2022 / VS Code / Rider
- Git

### Herramientas Opcionales

- SQL Server Management Studio (SSMS)
- Azure Data Studio

## Guía de Instalación

### 1. Clonar el Repositorio

```bash
git clone https://github.com/mateooo07/MasExpenseSystem.git
cd MasExpenseSystem
```

### 2. Configurar Variables de Entorno

```bash
# Copiar archivo de configuración
cp MasExpenseSystem/.env.example MasExpenseSystem/.env

# Editar configuración según tu entorno
```

Configurar el archivo `.env` con tus credenciales:

```env
SQLSERVER=TuNombreDeServidor
DBNAME=MasExpenseDb
DBUSER=TuUsuarioSQL
DBPASSWORD=TuPasswordSegura
```

### 3. Restaurar Dependencias

```bash
cd MasExpenseSystem
dotnet restore
```

### 4. Aplicar Migraciones de Base de Datos

```bash
dotnet ef database update
```

### 5. Ejecutar la Aplicación

```bash
dotnet run
```

## Funcionalidades Principales

### Sistema de Autenticación

- **Registro de usuarios**: Creación de cuentas con validación de contraseñas
- **Login seguro**: Autenticación con cookies y hash SHA-256
- **Sesiones**: Expiración automática después de 1 hora
- **Logout**: Cierre de sesión seguro

### Gestión de Servicios

- **Crear servicio**: Agregar nuevas categorías de ingresos o gastos
- **Listar servicios**: Vista de todos los servicios del usuario
- **Editar servicio**: Modificar nombre y tipo
- **Eliminar servicio**: Eliminación con confirmación (SweetAlert2)

### Gestión de Transacciones

- **Nueva transacción**: Registro con servicio, comentario, fecha y monto
- **Filtro por tipo**: Selección dinámica de servicios según tipo (Ingreso/Gasto)
- **Historial**: Consulta de transacciones por rango de fechas
- **Exportación**: Descarga en Excel, PDF, CSV y opción de impresión

## Configuración de la Base de Datos

### Estructura Principal

| Tabla | Descripción |
|-------|-------------|
| `Users` | Información de usuarios registrados |
| `Services` | Categorías de ingresos y gastos |
| `Transactions` | Registro de movimientos financieros |

### Relaciones

```
Users (1) ──────< Services (N)
Users (1) ──────< Transactions (N)
Services (1) ───< Transactions (N)
```
## Seguridad

### Medidas Implementadas

- **Hash de contraseñas**: SHA-256 para almacenamiento seguro
- **Autenticación por cookies**: Sesiones seguras con expiración
- **Autorización**: Atributo `[Authorize]` en controladores protegidos
- **Validación de modelos**: Data Annotations en ViewModels
- **Prevención SQL Injection**: Entity Framework con consultas parametrizadas
  
### Librerías Frontend (CDN)

- Bootstrap 5
- jQuery 3.7.1
- DataTables 2.3.5
- SweetAlert2 11
- Select2 4.1.0
- Bootstrap Icons 1.13.1

## Flujo de Desarrollo

### Ramas de Trabajo

- `main` - Código estable en producción
- `develop` - Desarrollo activo
- `feature/*` - Nuevas funcionalidades
- `hotfix/*` - Correcciones urgentes

## Licencia

Este proyecto está bajo la Licencia MIT - consultar el archivo LICENSE para más detalles.

## Autor

- **Desarrollador**: Mateo Francisco Pavoni
