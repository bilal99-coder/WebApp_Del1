using System.Diagnostics;
namespace WebApp_Del1
{
    public class ControllerTest
    {


        private readonly BillettContext _db;

        public BillettController(BillettContext db)
        {
            _db = db;
        }

        //Alle disse parameterene  får vi fra Javascript  Klienten 
        public void Bestill(Reiseinformasjon innReiseinformasjon, Lugarer innLugar, Person[] personerIBiletteten)
        {  //Jeg regner med at jeg får et array at av person objekter fra javascript, kanskje på 
            //Betaleren får jeg data om fra reiseinformasjon klasse, andre personer får jeg data om fra et array av personer 
            //Instansierer nå en ny billett 
            var nyBillett = new Billett();
            //Approach NR2
            //Fyller nå billetten med data og info om reisen som vi får fra hoved siden
            nyBillett.fra = innReiseinformasjon.fra;
            nyBillett.til = innReiseinformasjon.til;
            nyBillett.antallBarn = innReiseinformasjon.antallBarn;
            nyBillett.antallVoksne = innReiseinformasjon.antallVoksne;
            nyBillett.antallReisende = innReiseinformasjon.antallReisende;
            nyBillett.tidspunkt = innReiseinformasjon.utreise.ToString();
            nyBillett.type = innReiseinformasjon.reiseType;

            //Henter nå data om betaleren som er stored in ReiseInfromasjon KLasse
            //Lager nå en ny Betalere Objekt 
            Betalere enNyBetaler = new Betalere();
            //Før å fylle attributter til personen, skjekker vi foorst om personen finnes fra foor i databasen til personer 
            Personer funnetPerson = _db.personer.FirstOrDefault(k => k.personId == innReiseinformasjon.personId);
            //Hvis personen ikke finnes fra foor i databasen saa lager vi en ny person "enNyBetaler"
            if (funnetPerson == null)
            {
                enNyBetaler.kortholdersNavn = innReiseinformasjon.kortholdersNavn;
                enNyBetaler.cvc = innReiseinformasjon.cvc;
                enNyBetaler.kortNummer = innReiseinformasjon.kortNummer;
                enNyBetaler.fornavn = innReiseinformasjon.fornavn;
                enNyBetaler.etternavn = innReiseinformasjon.etternavn;
                enNyBetaler.addresse = innReiseinformasjon.addresse;
                enNyBetaler.personId = innReiseinformasjon.personId;
                //Adde personen som betalte til listen av personer i billetten 
                nyBillett.billettPersoner.Add(enNyBetaler);
                //Oppdatere databasen av personer med ny betaleren
                _db.personer.Add(enNyBetaler);
                _db.SaveChanges();
            }
            //Hvis personen finnes fra foor i databasen saa henter vi henne, og adder henne til listen av personer i billetten 
            else
            {
                nyBillett.billettPersoner.Add(funnetPerson);
            }

            //Nå etter at jeg hentet data om selve reisen og data om betaleren, nå vil jeg å hente data om andre passasjerer 

            for (foreach Person enPerson in personerIBiletteten)
                {
                    //skjekker først om vi har kunden på databasen fra før
                    Personer funnetKunde = _db.personer.FirstOrDefault(k => k.personId == enPerson.personId);
                    //Instansierer enNyPerson objekt som vi skal bruke om vi ikke har passasjereren i databasen 
                    Personer enNyPerson = new Personer();
                    if (funnetKunde == null)//Hvis kunden finnes ikke i databasen fra foor 
                    {
                        enNyPerson.personId = enPerson.personId;
                        enNyPerson.fornavn = enPerson.fornavn;
                        enNyPerson.etternavn = enPerson.etternavn;
                        enNyPerson.addresse = enPerson.addresse;
                        //Må nå adde en enNyPerson Listen billettPersoner
                        nyBillett.billettPersoner.Add(enNyPerson);
                        _db.personer.Add(enNyPerson);
                        _db.SaveChanges();
                    }
                    else  //Hvis personen finnes i databasen så har vi har allerede data om han/henne 
                    {
                        //Må nå adde personen i Listen billettPersoner
                        nyBillett.billettPersoner.Add(funnetKunde);
                    }

                }

            //Nå har vi lagret data om alle personer som skal være med i reisen, laget en objekt for hver person jeg får fra klienten, added den på billettPersoner listen, og added den til databasen av personer hvis den ikke finnes fra foor 
            //Jeg trenger nå å hente data om ønsket lugaren 

            //Starter med å lage en ny lugar objekt 

            Lugarer enNyLugar = new Lugarer();
            //Henter oonsket lugar fra dayabasen av alle lugarer 
            Lugarer funnetLugar = _db.lugarer.FirstOrDefault(k => k.LId == innReiseinformasjon.LugarId);

            //Adder Lugaren til listen av lugarer i billetten 
            if (funnetLugar != null)
            {
                nyBillett.billettLugarer.Add(funnetLugar);
            }


            //Bergner nå endelig prisen 
            //Må lage denne metoden som regner prisen 
            nyBillett.pris = beregnPris(innReiseinformasjon, innLugar);

        }

        public static void Main(string[] args)
        {
            Debug.WriteLine("Main Methode");
            // MessageBox.Show("Main method"); 
        }
    }
}