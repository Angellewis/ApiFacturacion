using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Facturacion2.Models;

namespace Facturacion2.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<Vendedores> Vendedores { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Referencia> Referencia { get; set; }
    }

    public class Articulos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public Boolean Estado { get; set; }

    }

    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(20)]
        public string Identificador { get; set; }

        [StringLength(50)]
        public string Cuenta { get; set; }

        public Boolean Estado { get; set; }

    }

    public class Facturas
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string Fecha { get; set; }

        [StringLength(150)]
        public string Comentario { get; set; }

        public double Precio_Total { get; set; }

    }

    public class Vendedores
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public double Comision { get; set; }

        public Boolean Estado { get; set; }

    }

    public class Detalle
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("facturaid")]
        public Facturas factura { get; set; }

        public IList<Referencia> referencias { get; set; }
    }

    public class Referencia
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("articuloid")]
        public Articulos articulo { get; set; }

        [ForeignKey("clientesid")]
        public Clientes clientes { get; set; }

        [ForeignKey("vendedoresid")]
        public Vendedores vendedores { get; set; }
    }
}
