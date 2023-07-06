using MagicVilla.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.API.Data;

public class MagicVillaContext : DbContext
{
    public MagicVillaContext(DbContextOptions<MagicVillaContext> options) : base(options) { }

    public DbSet<Vila> Vilas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vila>().HasData(
            new Vila()
            {
                Id = 1,
                Nome = "Vista da Piscina",
                Detalhes = "Vila com vista para a piscina",
                Tarifa = 1000,
                MetrosQuadrados = 100,
                Ocupacao = 2,
                UrlDaImagem = "https://dotnetmastery.com/bluevillaimages/villa1.jpg",
                Comodidade = "Ar condicionado, TV, Frigobar, Cama King Size, Banheira de Hidromassagem",
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Vila()
            {
                Id = 2,
                Nome = "Vista do Lago",
                Detalhes = "Vila com vista para o lago",
                Tarifa = 2000,
                MetrosQuadrados = 200,
                Ocupacao = 4,
                UrlDaImagem = "https://dotnetmastery.com/bluevillaimages/villa2.jpg",
                Comodidade = "Ar condicionado, TV, Frigobar, Cama King Size, Banheira de Hidromassagem",
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Vila()
            {
                Id = 3,
                Nome = "Vista do Mar",
                Detalhes = "Vila com vista para o mar",
                Tarifa = 3000,
                MetrosQuadrados = 300,
                Ocupacao = 6,
                UrlDaImagem = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                Comodidade = "Ar condicionado, TV, Frigobar, Cama King Size, Banheira de Hidromassagem",
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Vila()
            {
                Id = 4,
                Nome = "Vista do Jardim",
                Detalhes = "Vila com vista para o jardim",
                Tarifa = 4000,
                MetrosQuadrados = 400,
                Ocupacao = 8,
                UrlDaImagem = "https://dotnetmastery.com/bluevillaimages/villa4.jpg",
                Comodidade = "Ar condicionado, TV, Frigobar, Cama King Size, Banheira de Hidromassagem",
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            },
            new Vila()
            {
                Id = 5,
                Nome = "Vista da Montanha",
                Detalhes = "Vila com vista para a montanha",
                Tarifa = 5000,
                MetrosQuadrados = 500,
                Ocupacao = 10,
                UrlDaImagem = "https://dotnetmastery.com/bluevillaimages/villa5.jpg",
                Comodidade = "Ar condicionado, TV, Frigobar, Cama King Size, Banheira de Hidromassagem",
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            }
        );
    }
}