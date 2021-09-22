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

        //Alle disse parameterene  f�r vi fra Javascript  Klienten 
        public void Bestill(Reiseinformasjon innReiseinformasjon, Lugarer innLugar, Person[] personerIBiletteten)
        {  //Jeg regner med at jeg f�r et array at av person objekter fra javascript, kanskje p� 
            //Betaleren f�r jeg data om fra reiseinformasjon klasse, andre personer f�r jeg data om fra et array av personer 
            //Instansierer n� en ny billett 
            var nyBillett = new Billett();
            //Approach NR2
            //Fyller n� billetten med data og info om reisen som vi f�r fra hoved siden
            nyBillett.fra = innReiseinformasjon.fra;
            nyBillett.til = innReiseinformasjon.til;
            nyBillett.antallBarn = innReiseinformasjon.antallBarn;
            nyBillett.antallVoksne = innReiseinformasjon.antallVoksne;
            nyBillett.antallReisende = innReiseinformasjon.antallReisende;
            nyBillett.tidspunkt = innReiseinformasjon.utreise.ToString();
            nyBillett.type = innReiseinformasjon.reiseType;

            //Henter n� data om betaleren som er stored in ReiseInfromasjon KLasse
            //Lager n� en ny Betalere Objekt 
            Betalere enNyBetaler = new Betalere();
            //F�r � fylle attributter til personen, skjekker vi foorst om personen finnes fra foor i databasen til personer 
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

            //N� etter at jeg hentet data om selve reisen og data om betaleren, n� vil jeg � hente data om andre passasjerer 

            for (foreach Person enPerson in personerIBiletteten)
                {
                    //skjekker f�rst om vi har kunden p� databasen fra f�r
                    Personer funnetKunde = _db.personer.FirstOrDefault(k => k.personId == enPerson.personId);
                    //Instansierer enNyPerson objekt som vi skal bruke om vi ikke har passasjereren i databasen 
                    Personer enNyPerson = new Personer();
                    if (funnetKunde == null)//Hvis kunden finnes ikke i databasen fra foor 
                    {
                        enNyPerson.personId = enPerson.personId;
                        enNyPerson.fornavn = enPerson.fornavn;
                        enNyPerson.etternavn = enPerson.etternavn;
                        enNyPerson.addresse = enPerson.addresse;
                        //M� n� adde en enNyPerson Listen billettPersoner
                        nyBillett.billettPersoner.Add(enNyPerson);
                        _db.personer.Add(enNyPerson);
                        _db.SaveChanges();
                    }
                    else  //Hvis personen finnes i databasen s� har vi har allerede data om han/henne 
                    {
                        //M� n� adde personen i Listen billettPersoner
                        nyBillett.billettPersoner.Add(funnetKunde);
                    }

                }

            //N� har vi lagret data om alle personer som skal v�re med i reisen, laget en objekt for hver person jeg f�r fra klienten, added den p� billettPersoner listen, og added den til databasen av personer hvis den ikke finnes fra foor 
            //Jeg trenger n� � hente data om �nsket lugaren 

            //Starter med � lage en ny lugar objekt 

            Lugarer enNyLugar = new Lugarer();
            //Henter oonsket lugar fra dayabasen av alle lugarer 
            Lugarer funnetLugar = _db.lugarer.FirstOrDefault(k => k.LId == innReiseinformasjon.LugarId);

            //Adder Lugaren til listen av lugarer i billetten 
            if (funnetLugar != null)
            {
                nyBillett.billettLugarer.Add(funnetLugar);
            }


            //Bergner n� endelig prisen 
            //M� lage denne metoden som regner prisen 
            nyBillett.pris = beregnPris(innReiseinformasjon, innLugar);

        }

        public static void Main(string[] args)
        {
            Debug.WriteLine("Main Methode");
            // MessageBox.Show("Main method"); 
        }
    }
}