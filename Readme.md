# Software de Inscripción a Cursos de TECHBOTICA

## Casos de uso

### Caso de uso 1: Creación de oferta académica

**Pasos a seguir:**

1. **Iniciar sesión:** 
   - Usuario: `web.master@techbotica.ar`
   - Contraseña: `Password1234!`
   
2. Ir a `Menu Tutores` > `Nuevo Curso`.

3. Seleccionar `nuevo curso` y crearlo.

4. Navegar a `Menu Tutores` > `Nuevo Dictado`.

5. Buscar el curso creado, seleccionarlo y completar la primera pantalla con "Tipo de Dictado" > `Interactivo`. Luego, presionar `Siguiente`.

6. **Asignar horarios a la cursada:** 
   - Nota: El único tutor disponible "Carlos" está en dictados interactivos los días Lunes de 8 a 10 y los Martes de 10 a 12 desde el 2023-09-05 hasta 2023-12-12. Luego, presionar `Siguiente`.

7. Agregar un `Tutor` teniendo en cuenta los horarios y, luego, seleccionar `Completar`.

8. Verificar el dictado creado en `Gestionar Dictado`.

### Soluciones Técnicas para Ejecutar en Laboratorio Universidad UAI

- **Arreglar error de certificado:** 
  - Consulta [aquí](https://stackoverflow.com/questions/44066709/your-connection-is-not-private-neterr-cert-common-name-invalid).

- **Solucionar error Roslyn:** 
  - En la consola del administrador de paquetes, ejecutar: 
    ```
    Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
    ```

- **Problema con bootstrap:** 
  - En `BundleConfig.cs`, añadir/modificar:
    ```csharp
    <add name="DefaultConnection" providerName="System.Data.SqlClient" connectionString="Data Source=.;Initial Catalog=Techbotica;Integrated Security=True;"
    ScriptManager.ScriptResourceMapping.AddDefinition("bootstrap", new ScriptResourceDefinition
    {
        Path = "~/scripts/bootstrap.min.js",
        DebugPath = "~/scripts/bootstrap.js",
        LoadSuccessExpression = "bootstrap"
    });
    ```

## Posibles mejoras

1. En gestion de usuarios
    - Poder cambiar la password desde el panel
    - Poder cambiar la empresa desde el panel
    - Agregar un filtro para visualizar empleados por empresa
