Soluciones tecnicas para ejecutar en laboratorio universidad UAI:

Arreglar error certificado: https://stackoverflow.com/questions/44066709/your-connection-is-not-private-neterr-cert-common-name-invalid

Solucionar error Roslyn: Consola del administrador de paquetes ->  Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r

Problema bootstrap: En BundleConfig.cs 
<add name="DefaultConnection" providerName="System.Data.SqlClient" connectionString="Data Source=.;Initial Catalog=Techbotica;Integrated Security=True;"
ScriptManager.ScriptResourceMapping.AddDefinition("bootstrap", new ScriptResourceDefinition
            {
                Path = "~/scripts/bootstrap.min.js",
                DebugPath = "~/scripts/bootstrap.js",
                LoadSuccessExpression = "bootstrap"
            })