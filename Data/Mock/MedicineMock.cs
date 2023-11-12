using healthcare_system.Models;

namespace healthcare_system.Data.Mock
{
    public class MedicineMock
    {
        protected readonly ApplicationDbContext _db;

        public MedicineMock(ApplicationDbContext db) 
        {
            _db = db;
        }

        public void seedMedicine()
        {
            var mockMedicines = new List<Medicine>
            {
                new Medicine
                {
                    MedicineId = "425d9575-79d7-4950-81eb-a1384dd01e6e",
                    MedicineName = "Dasselta control 5 mg, filmsko obložene tablete (10 tablet)",
                    Category = "Alergije",
                    Description = "Zdravilo Dasselta control lajša simptome alergijskega rinitisa (vnetje nosnih poti zaradi alergije, npr. seneni nahod ali alergija na pršice) pri odraslih. Ti simptomi vključujejo kihanje, izcedek iz nosu ali srbenje nosu, srbenje ustnega neba, srbeče, rdeče ali solzne oči.\r\n\r\nZdravilo Dasselta control se pri odraslih uporablja tudi za lajšanje simptomov kronične idiopatske urtikarije (težave s kožo zaradi neznanega razloga), ki jo predhodno diagnosticira vaš zdravnik. Ti simptomi vključujejo srbenje in koprivnico. Ublažitev teh simptomov traja ves dan (24 ur) in vam bo pomagala, da boste lahko spet opravljali običajne vsakdanje dejavnosti in spali. Če se znaki vaše bolezni ne izboljšajo v 7 dneh ali se med zdravljenjem poslabšajo, se morate posvetovati z zdravnikom. Če opazite težave z dihanjem, otekanje ustnic, jezika ali grla (simptomi, ki kažejo na angiodem), morate nemudoma poiskati zdravniško pomoč.",

                },
                new Medicine
                {
                    MedicineId = "5b856fdb-e58e-4c16-a797-377bbbf8f618",
                    MedicineName = "Fenistil gel 1 mg/g (30 g)",
                    Category = "Alergije",
                    Description = "Kaj je zdravilo Fenistil. Zdravilo Fenistil vsebuje učinkovino, ki sodi v skupino antihistaminikov. Uporablja se ga lahko za lajšanje srbečice pri kožnih boleznih (dermatozah), kot sta kožni izpuščaj in koprivnica, ter pri pikih žuželk, pri sončnih opeklinah in pri površinskih opeklinah.\r\n\r\nKako deluje zdravilo Fenistil\r\nZdravilo Fenistil ustavi srbenje, tako da zavira delovanje histamina, ki ga telo sprošča pri alergijskih reakcijah. Gel dobro prodira v kožo. Srbenje in draženje mineta v nekaj minutah. Ima tudi lokalno anestetičen učinek."
                },
                new Medicine
                {
                    MedicineId = "2e172dbc-79b3-4cd2-bf61-6e0fe9f5d920",
                    MedicineName = "Flonidan S 10 mg, tablete (10 tablet)",
                    Category = "Alergije",
                    Description = "Zdravilo Flonidan S vsebuje učinkovino loratadin, ki spada v skupino zdravil imenovanih antihistaminiki. Pri alergijski reakciji se sproščajo različne snovi (mediatorji), zaradi katerih se pojavijo simptomi alergijske bolezni. Med najpomembnejšimi mediatorji pri alergijski reakciji je histamin, ki povzroči simptome, kot so: srbenje, pordečitev, oteklina in izcedek iz nosu. \r\n\r\nZdravilo Flonidan S zavre delovanje histamina in tako deluje izrazito protialergijsko, saj lajša simptome alergijske reakcije. Njegov učinek traja približno 24 ur."
                },
                new Medicine
                {
                    MedicineId = "8a0bdd01-39cf-49d4-9b6a-214c8c1f8761",
                    MedicineName = "Lekadol, 30 filmsko obloženih tablet",
                    Category = "Bolečine",
                    Description = "Zdravilo LEKADOL vsebuje učinkovino paracetamol. Deluje tako, da lajša bolečine in znižuje zvišano telesno temperaturo. Zdravilo LEKADOL ne draži želodčne sluznice, zato ga lahko jemljejo tudi bolniki z želodčnimi težavami in z rano na želodcu ali dvanajstniku. Tablete so ovalne, zato jih lažje pogoltnete. Zaradi filmske obloge nimajo neprijetnega okusa. "
                },
                new Medicine
                {
                    MedicineId = "37c43695-5f75-49da-afb3-2be4964b8468",
                    MedicineName = "Lekofusin 200 mg/500 mg, filmsko obložene tablete (16 tablet)",
                    Category = "Bolečine",
                    Description = "Lekofusin vsebuje 2 učinkovini, paracetamol in ibuprofen, v 1 tableti. Paracetamol in ibuprofen se razlikujeta glede na mesto in način delovanja. Njuna načina delovanja sta vzajemna, kar zagotavlja močnejši protibolečinski učinek. (2,3,4)"
                },
                new Medicine
                {
                    MedicineId = "f70ad957-5162-4613-a3a5-287fdbc717de",
                    MedicineName = "Nalgesin S (275 mg), 30 filmsko obloženih tablet",
                    Category = "Bolečine",
                    Description = "Nalgesin S je zdravilo, ki blaži bolečine in vnetje ter znižuje zvišano telesno temperaturo. Deluje tako, da zavira tvorbo prostaglandinov. Tablete so dobro topne, zato začne zdravilo hitro delovati. "
                },
                new Medicine
                {
                    MedicineId = "b5bb3002-2751-4c50-9eca-f534dc6297e4",
                    MedicineName = "Exolorfin lak za nohte, zdravilni 50 mg/ml (2,5 ml)",
                    Category = "Glivične okužbe",
                    Description = "Zdravilo Exolorfin se uporablja za zdravljenje glivičnih okužb nohtov pri odraslih. Uporablja se le, če je prizadeta zgornja polovica ali stranski del nohtov. Učinkovina amorolfin preprečuje rast gliv in jih uničuje. Zdravilo Exolorfin deluje proti številnim vrstam gliv, občutljivih na amorolfin, kot so kvasovke, kožne glive in plesni. Bakterije niso občutljive na amorolfin. Če se znaki vaše bolezni poslabšajo ali ne izboljšajo v 3 mesecih, se posvetujte z zdravnikom."
                },
                new Medicine
                {
                    MedicineId = "aa520984-f57b-4f31-9e5b-b48377022228",
                    MedicineName = "Canespor 10 mg/g, krema (15 g)",
                    Category = "Glivične okužbe",
                    Description = "Zdravilo Canespor je protiglivično zdravilo za lokalno zdravljenje. Vsebuje učinkovino bifonazol, ki deluje proti glivicam in tudi proti nekaterim drugim mikroorganizmom."
                }

            };
            
            var existingMedicineIds = _db.Medicines.Select(m => m.MedicineId).ToList();
               
            foreach (var mockMedicine in mockMedicines)
            {
                if (!existingMedicineIds.Contains(mockMedicine.MedicineId))
                {
                    _db.Medicines.Add(mockMedicine);
                }
            }

            _db.SaveChanges();
        }
    }
}
