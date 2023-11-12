using healthcare_system.Models;

namespace healthcare_system.Data.Mock
{
    public class HospitalMock
    {
        private readonly ApplicationDbContext _db;

        public HospitalMock(ApplicationDbContext db)
        {
            _db = db;
        }

        public void seedHospitals()
        {
            var mockHospitals = new List<Hospital>
            {
                new Hospital
                {
                    HospitalId = "A",
                    Address = "Zaloška cesta 7",
                    PostalCode = "1000",
                    City = "Ljubljana",
                    Name = "UKC Ljubljana",
                    Description = "Univerzitetni klinični center Ljubljana zajema veliko skupino klinik, oddelkov in drugih služb, namenjenih skrbi za zdravje naših kot tudi tujih državljanov. " +
                    "Zaradi tolikšnega števila različnih klinik se med posameznimi enotami razlikujejo tudi načini dela."

                },
                new Hospital
                {
                    HospitalId = "B",
                    Address = "Ljubljanska ulica 5",
                    PostalCode = "2000",
                    City = "Maribor",
                    Name = "UKC Maribor",
                    Description = "Univerzitetni klinični center Maribor je javni zdravstveni zavod in opravlja zdravstveno dejavnost na sekundarni in terciarni ravni za območje Maribora, Pesnice, Ruš, Ormoža, Lenarta, Ptuja in Slovenske Bistrice, z nekaterimi subspecialnimi dejavnostmi pa pokriva tudi potrebe severovzhodne Slovenije in Koroške. Ustanovitelj UKC Maribor je Republika Slovenija, ustanoviteljske pravice in obveznosti izvaja Vlada Republike Slovenije."

                },
                new Hospital
                {
                    HospitalId = "C",
                    Address = "Polje 40",
                    PostalCode = "6310",
                    City = "Izola",
                    Name = "Splošna bolnišnica Izola",
                    Description = "Splošna bolnišnica Izola (SBI) je ena izmed bolnišnic v Sloveniji, ki opravlja zdravstvene storitve na sekundarni ravni. Bolnišnica je organizirana tako, da so v njej zastopani štirje veliki medicinski oddelki in sicer: oddelek za kirurgijo, oddelek za interno medicino, oddelek za ginekologijo in porodništvo ter oddelek za pediatrijo, poleg omenjenih pa še oddelek medicinskih služb. Poslanstvo SBI kot javne zdravstvene ustanove je skrb za zdravje občanov za širše področje primorske. " +
                    "Poleg zdravljenja v ožjem pomenu besede, so v SBI organizirane tudi dejavnosti, ki delujejo na področju preventive, na področju osveščanja in svetovanja prebivalstvu za zdrav način življenja."
                }
            };

            var existingHospitalIds = _db.Hospitals.Select(p => p.HospitalId).ToList();

            foreach (var mockHospital in mockHospitals)
            {
                if (!existingHospitalIds.Contains(mockHospital.HospitalId))
                {
                    _db.Hospitals.Add(mockHospital);
                }
            }

            _db.SaveChanges();

        }
    }
}
