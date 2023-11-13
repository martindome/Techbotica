# Software de Inscripción a Cursos de TECHBOTICA

## Informacion de usuarios

### Web Masters

| Nombre de Usuario               | Contraseña    | Nombre  | Apellido  |
|---------------------------------|---------------|---------|-----------|
| web.master@techbotica.ar        | Password1234! | Web     | Master    |

### Administradores

| Nombre de Usuario               | Contraseña    | Nombre  | Apellido  |
|---------------------------------|---------------|---------|-----------|
| marlon.ruiz@techbotica.ar       | Password1234! | Marlon  | Ruiz      |

### Tutores

| Nombre de Usuario               | Contraseña    | Nombre  | Apellido  |
|---------------------------------|---------------|---------|-----------|
| carlos.rodriguez@techbotica.ar  | Password1234! | Carlos  | Rodriguez |
| laura.martinez@techbotica.ar    | Password1234! | Laura   | Martinez  |
| jorge.hernandez@techbotica.ar   | Password1234! | Jorge   | Hernandez |
| ana.gomez@techbotica.ar         | Password1234! | Ana     | Gomez     |
| daniel.lopez@techbotica.ar      | Password1234! | Daniel  | Lopez     |
| carmen.sanchez@techbotica.ar    | Password1234! | Carmen  | Sanchez   |


### Estudiantes

| Nombre de Usuario             | Contraseña    | Nombre  | Apellido   |
|-------------------------------|---------------|---------|------------|
| maria.gonzalez@example.com    | Password1234! | Maria   | Gonzalez   |
| ana.martinez@example.com      | Password1234! | Ana     | Martinez   |
| luis.gonzalez@example.com     | Password1234! | Luis    | Gonzalez   |
| sofia.lopez@example.com       | Password1234! | Sofia   | Lopez      |
| carlos.diaz@example.com       | Password1234! | Carlos  | Diaz       |
| maria.fernandez@example.com   | Password1234! | Maria   | Fernandez  |
| juan.perez@example.com        | Password1234! | Juan    | Perez      |
| carmen.jimenez@example.com    | Password1234! | Carmen  | Jimenez    |
| jose.ruiz@example.com         | Password1234! | Jose    | Ruiz       |
| laura.garcia@example.com      | Password1234! | Laura   | Garcia     |
| david.alvarez@example.com     | Password1234! | David   | Alvarez    |

### Empresas

| Nombres             | Dominios    |
|-------------------------------|---------------|
| TECHBOTICA    | techbotica.ar / gmail.com |
| Metalurgica Argentina SA      | example.com / alumnos.uai.edu.ar |
| Aceros Buenos Aires SRL     | - |
| Universidad Abierta Interamericana       | alumnos.uai.edu.ar / gmail.com |

## Casos de uso

### Caso de uso 1: Creación de oferta académica

**Pasos a seguir:**

1. **Iniciar sesión:** 
   - Usuario: `carlos.rodriguez@techbotica.ar`
   - Contraseña: `Password1234!`
   
2. Ir a `Menu Tutores` > `Nuevo Curso`.

3. Llenar los datos y seleccionar `Crear Curso`
    - Nombre: Matematica-02
    - Descripcion: Este es un curso de Matematica
    - Carreras disponibles: Carrera en Matematica

4. Navegar a `Tutores` > `Nuevo Dictado`.

5. Buscar el curso creado, seleccionarlo y completar la primera pantalla con "Tipo de Dictado" > `Interactivo`. Luego, presionar `Siguiente`.
    - Curso seleccionado: Matematica -02
    - Enlace: https://google.meet.com
    - Cupo: 1
    - Tipo de dictado: Intaractivo
    - Fecha de Inicio: 4/12/2023
    - Fecha de Fin: 25/12/2023

6. **Asignar horarios a la cursada:**. Luego, presionar `Siguiente`.
   - Nota: El único tutor disponible "Carlos" está en dictados interactivos los días Lunes de 8 a 10 y los Martes de 10 a 12 desde el 2023-09-05 hasta 2023-12-12.
   - Dia Martes
   - Hora de Inicio: 19:00
   - Hora de Fin: 22:00

7. Agregar un `Tutor` teniendo en cuenta los horarios y, luego, seleccionar `Completar`.
    - Tutor: Carlos Rodriguez

8. Verificar el dictado creado en `Gestionar Dictado`.

---

### Caso de uso 2: Anotarse a oferta academica

**Pasos a seguir:**

1. **Iniciar sesión:** 
   - Usuario: `maria.gonzalez@example.com`
   - Contraseña: `Password1234!`
   
2. Ir a `Buscar...` > `Buscar Cursos`.

3. Seleccionar el curso a anotarse y selecionar `Ver Dictados`
    - Nombre: Matematica-02

4. Buscar dictado creado y seleccionar `Inscribir` 

5. Revisar los datos y seleccionar `Inscribirse`

6. Verificar la inscripcion en `Mis Inscripciones` o en Ir a `Estudiantes` > `Gestionar Inscripciones`.

---

### Caso de uso 3: Agregar materiales

**Pasos a seguir:**

1. **Iniciar sesión:** 
   - Usuario: `carlos.rodriguez@techbotica.ar`
   - Contraseña: `Password1234!`
   
2. Ir a `Tutores` > `Mis Dictados`.

3. Buscar el curso creado en el caso de uso 1 y seleccionar `Ingresar`
    - Nombre: Matematica-02

4. Seleccionar `Nuevo Material` 

5. Buscar un archivo pdf, ponerle un nombre y seleccionar `Subir`
    - Nombre: Material 1

4. Seleccionar `Nueva Actividad` 

6. Buscar un archivo pdf, ponerle un nombre y seleccionar `Subir`
    - Nombre: Actividad 1

---

### Caso de uso 4: Entregar resolucion

**Pasos a seguir:**

1. **Iniciar sesión:** 
   - Usuario: `maria.gonzalez@example.com`
   - Contraseña: `Password1234!`
   
2. Ir a `Estudiantes` > `Mis Cursadas`.

3. Buscar el dictado inscripto en el caso de uso 1 y seleccionar `Ingresar`
    - Nombre: Matematica-02

4. Seleccionar `Ver` en la Actividad 1 

5. Seleccionar `Nueva Entrega`

6. Buscar un archivo pdf y seleccionar `Subir`

---

## Soluciones Técnicas para Ejecutar en Laboratorio Universidad UAI

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

- **Migración de repositorio Git:**
  Si necesitas mover tu repositorio git existente a un nuevo origen remoto, aquí tienes los pasos a seguir:
  
  ```bash
  #!/bin/bash
  # Sometimes you need to move your existing git repository
  # to a new remote repository (/new remote origin).
  # Here are simple and quick steps that do exactly this.
  #
  # Let's assume we call "old repo" the repository you wish
  # to move, and "new repo" the one you wish to move to.
  #
  ### Step 1. Make sure you have a local copy of all "old repo"
  ### branches and tags.
  # Fetch all of the remote branches and tags:
  git fetch origin

  # View all "old repo" local and remote branches:
  git branch -a

  # If some of the remotes/ branches doesn't have a local copy,
  # checkout to create a local copy of the missing ones:
  git checkout -b <branch> origin/<branch>

  # Now we have to have all remote branches locally.

  ### Step 2. Add a "new repo" as a new remote origin:
  git remote add github https://github.com/martindome/techbotica.git

  ### Step 3. Push all local branches and tags to a "new repo".
  # Push all local branches (note we're pushing to new-origin):
  git push --all github

  # Push all tags:
  git push --tags github

  ### Step 4. Remove "old repo" origin and its dependencies.
  # View existing remotes (you'll see 2 remotes for both fetch and push)
  git remote -v

  # Remove "old repo" remote:
  git remote rm origin

  # Rename "new repo" remote into just 'origin':
  git remote rename new-origin origin

  ### Done! Now your local git repo is connected to "new repo" remote
  ### which has all the branches, tags, and commits history.


## Posibles mejoras

1. En gestion de usuarios
    - Poder cambiar la password desde el panel  (o actualizacion y envio por email)
    - Agregar un filtro para visualizar empleados por empresa
    - Chequear usuarios eliminados como en registrar
    - Refactoriong de la pagina, una para seleccion de usuarios y otra para las modificaciones de datos, empresa y familia
2. En inscripciones
  - Verificar que los dictados mostrados tengan fecha de inicio superior a la de hoy (Solucionado)
3. En Registrarse
  - Permitir realizar una busqueda de empresas y seleccionarla de esa busqueda en lugar de escribir el nombre (Solucionado)
4. En administracion
  - Armar una pagina de administracion para las inscripciones (solucionado)
  - Solucionar en GestionarInscripciones que cuando se selecciona un alumno no ay un textbox qu diga que aluno esta seleccionado (solucionado)
  - En administracion, crear una pagina que permita crear familias y modificar patentes (y borrar si no tiene ningun usuario asignado y no son Estudiantes, Web Master, Administrador ni Tutor) (solucionado)

