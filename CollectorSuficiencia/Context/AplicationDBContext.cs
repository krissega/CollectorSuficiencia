using CollectorSuficiencia.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectorSuficiencia.Context
{
    public class AplicationDBContext : DbContext
    {

        public AplicationDBContext(DbContextOptions<AplicationDBContext> options)
                : base(options) 
        {
        
        
        }
    
    public DbSet<CollectorSuficiencia.Entities.Usuario>Usuario{ get; set; }
    
    public DbSet<CollectorSuficiencia.Entities.Direccion> Direcciones { get; set; }
    
    public DbSet<CollectorSuficiencia.Entities.Interes> Intereses { get; set; }
    
    public DbSet<CollectorSuficiencia.Entities.Subasta> Subastas { get; set; }
    
    public DbSet<CollectorSuficiencia.Entities.OrdenCompra> OrdenCompras { get; set; }
    
    public DbSet<CollectorSuficiencia.Entities.Oferta> Ofertas { get; set; }
    
    //public DbSet<CollectorSuficiencia.Entities.Objeto> Objetos{ get; set; }
    
    public DbSet<CollectorSuficiencia.Entities.MetodoPago> MetodoPago { get; set; }
        public object Objeto { get; internal set; }
        public DbSet<CollectorSuficiencia.Entities.Producto> Producto { get; set; }
    }
}
