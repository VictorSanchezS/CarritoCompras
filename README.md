Asegúrate de que la carpeta bin\roslyn\ se esté generando correctamente:
Si la carpeta roslyn o el archivo csc.exe no se genera, podría ser un problema de configuración de tu proyecto.
Asegúrate de que el proyecto esté configurado para utilizar Roslyn para la compilación de C#. Si no es así, intenta agregar el paquete de compilador de Roslyn de NuGet:
bash
Copiar código
Install-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform
