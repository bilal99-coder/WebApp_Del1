using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebApp_Del1.DAL
{
    




//public class Billett
public class Billetter
{
    [Key]
    public int BId { get; set; }
    public int Kid { get; set; }
    public string Reisetype { get; set; }
    public string Fra { get; set; }
    public string Til { get; set; }
    public string Utreise { get; set; }
    public string Hjemreise { get; set; }
    public string AntallVoksne { get; set; }
    public string AntallBarn { get; set; }

}




public class Kunde
{
    [Key]
    public int Kid { get; set; }
    public String Fornavn { get; set; }
    public String Etternavn { get; set; }
    public String Epost { get; set; }



    //Hver person kan ha flere billetter så hver person skal ha en liste av billetter som attributt
    public virtual List<Billetter> bestillinger { get; set; }



}



public class Havner
{
    [Key]
    public int HavnId { get; set; }
    public string HavnNavn { get; set; }



    public virtual List<ankomstHavner> AnkomstHavner { get; set; }



}



public class ankomstHavner
{
    [Key]
    public int HavnId { get; set; }
    public string HavnNavn { get; set; }
    public int pris { get; set; }



}




public class BillettContext : DbContext
{



        public BillettContext(DbContextOptions<BillettContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    
    public DbSet<Havner> Havner { get; set; }
    public DbSet<Kunde> Kunder { get; set; }
    public DbSet<Billetter> Bestillinger { get; set; }
    public DbSet<ankomstHavner> ankomstHavner { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }



}

}