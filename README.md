# V.1.1 Gabriel Eduardo Duarte Vega - 2017/12/06
## EntityFramework 6
### IGDDemo Library DAL
> Descripción: Librería con la capa de acceso a datos para el producto de demostración IGDDemo
+ Se incrementa la versión de 1.0 a 1.1 donde el número de compilación y revisión se retiran.
+ En la versión los números de compilación y revisión se incrementan automáticamente.
+ Se modifica los archivio .csproj y AssemblyInfo.cs para que se incremente automáticamente la versión.
+ Se agrega en evento post-build código para generar paquete Nuget y publicarlo en NuGet IngenieriaGD.

# V.1.0.2.2 Gabriel Eduardo Duarte Vega - 2017/12/06
## EntityFramework 6
### IGDDemo Library DAL
> Descripción: Librería con la capa de acceso a datos para el producto de demostración IGDDemo
+ Se modifica método SelectAll para que no devuelva hijos null por cada registro padre ente tablas.

# V.1.0.2.1 Gabriel Eduardo Duarte Vega - 2017/11/29
## EntityFramework 6
### IGDDemo Library DAL
> Descripción: Librería con la capa de acceso a datos para el producto de demostración IGDDemo
+ Se completan pruebas unitarias para clientes (IGD_Clients)
+ Se modifica la librería después de pruebas unitarias.
+ Se carga nueva versión en NuGet Ingeniería GD®.

# V.1.0.1.1 Gabriel Eduardo Duarte Vega - 2017/11/29
## EntityFramework 6
### IGDDemo Library DAL
> Descripción: Librería con la capa de acceso a datos para el producto de demostración IGDDemo
+ Se cambia el nombre del ensamblado a IngenieriaGD.IGDDemo.Library.DAL
+ La solución tiene un proyecto de prueba DALTest y un proyecto de frontend DAL.View

# V.1.0.0.1 Gabriel Eduardo Duarte Vega - 2017/11/27
## EntityFramework 6
### EntityFramework usado en una librería portátil.
> Descripción: Se agrega archivo package.nuspec como plantilla para generar paquete NuGet.
+ Se agrega por primera vez la versión 1.0.0.1 al repositorio NuGet de Ingeniería GD®.

# V.1.0.0 Gabriel Eduardo Duarte Vega - 2017/11/24
## EntityFramework 6
### EntityFramework usado en una librería portátil.
> Descripción: Se utilizará EntityFramework 6 para mapear tablas, relaciones y procedimientos desde BD.
+ Las entidades y la lógica de la capa BL se estructurarán en una librería independiente.
