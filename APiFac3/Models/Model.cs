using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APiFac3.Models
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
    }

    public class Articulos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int Stock { get; set; }

        public Boolean Estado { get; set; }

    }

    public class Clientes
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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

    public class Vendedores
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Cedula { get; set; }

        public double Comision { get; set; }

        public Boolean Estado { get; set; }

    }

    public class Facturas
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(10)]
        public string Fecha { get; set; }

        [StringLength(150)]
        public string Comentario { get; set; }

        [ForeignKey("vendedorid")]
        public Vendedores vendedores { get; set; }

        [Required]
        public int vendedorid { get; set; }

        [ForeignKey("clienteid")]
        public Clientes clientes { get; set; }

        [Required]
        public int clienteid { get; set; }

        public int Cant_Articulos { get; set; }

        public double Precio_Total { get; set; }

    }

    public class Detalle
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("facturaid")]
        public Facturas factura { get; set; }

        [Required]
        public int facturaid { get; set; }

        [ForeignKey("articuloid")]
        public Articulos articulos { get; set; }

        [Required]
        public int articuloid { get; set; }

        public int Cant_articulo { get; set; }

    }
}
