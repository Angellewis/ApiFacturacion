# ApiFacturacion
 Web Api de Facturacion desarrollada en .net core y SQL Server
 
 Recuerda cambiar en Startup.cs la conexion de la base de datos para poder trabajar de manera efectiva. 
 
 var connection = @"Server="TuServidor";Database=Facturacion2;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connection));
