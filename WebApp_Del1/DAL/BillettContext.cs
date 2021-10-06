using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApp_Del1.DAL
{
    /*
    // public class Lugar
    public class Lugarer
    {
        [Key]
        public int LId { get; set; }
        public string navn { get; set; }
        public int romNummer { get; set; }
        public string beskrivelse { get; set; }
        public int antallSoverom { get; set; }
        public int antallSenger { get; set; }
        public string harWc { get; set; }
        public String wciIconURL { get; set; }
        public string harDysj { get; set; }
        //rom senger 
        public string harWifi { get; set; }
        public String wifiIconURL { get; set; }
        public int antPlasser { get; set; }
        public String plassIconURL { get; set; }
        public String pris { get; set; }
        public String prisIconURL { get; set; }
        /*


         */
    }

//public class Billett
/*  public class Billett
  {
      [Key]
      public int billettId { get; set; }
      //************Ny felt***************
     // public Betalere betaleren { get; set; }
      //************Ny felt***************
      public string fra { get; set; }
      public string til { get; set; }
      public int antallBarn { get; set; }
      public int antallVoksne { get; set; }
      public int antallReisende { get; set; }
      public double pris { get; set; }
      public string tidspunkt { get; set; }
      public string type { get; set; }
      //Flere personer kan dele samme billetten, så en billett kan ha flere personer i seg. denne Listen har en oppgave å lagre alle personer som er med i billetten 
     // public virtual List<Personer> billettPersoner { get; set; }
    //  public virtual List<Lugarer> billettLugarer { get; set; }
  }


  public class Personer
  {
      [Key]
      public int personId { get; set; }

      public String fornavn { get; set; }//
      public String etternavn { get; set; }

      public String epost { get; set; }

      //Hver person kan ha flere billetter så hver person skal ha en liste av billetter som attributt
    //  public virtual List<Billett> personSinBilletter { get; set; }

  }
  /*
  public class Betalere : Personer
  {
      public string kortholdersNavn { get; set; }

      public string kortNummer { get; set; }

      public int cvc { get; set; }

  }
  */

/* public class PostSteder
 {
     [Key]
     public string Postnr { get; set; }
     public string Poststed { get; set; }
 }

 // Database Model for ruter 
 /*  */
/* public class Ruter
 {
     [Key]
     public int RuteId { get; set; }
     public Havner avgangHavnen { get; set; }
     public  List<Havner> ankomstHavner { get; set; }
     public int pris { get; set; }

 }
*/


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

}

  





public class BillettContext : DbContext
    {

        public BillettContext(DbContextOptions<BillettContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

       // public DbSet<Lugarer> lugarer { get; set; }
       // public DbSet<Billett> billetter { get; set; }
       // public DbSet<Personer> personer { get; set; }
       // public DbSet<Betalere> Betalere { get; set; }
        //  public DbSet<Ruter> Ruter { get; set; }
        public DbSet<Havner> Havner { get; set; }
         public DbSet<ankomstHavner> ankomstHavner { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
      

    }



