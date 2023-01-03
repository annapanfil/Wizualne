using _145233.SweetBase.Models;

namespace _145233.SweetBase
{
    public class DataMock
    {
        private readonly DataContext dataContext;
        public DataMock(DataContext context)
        {
            this.dataContext = context;
        }

        public void InitDataContext()
        {
            if (!dataContext.Producents.Any())
            {
                var Producents = new List<Producent>()
                {
                     new Producent()
                    {
                        Name = "Wedel",
                        Address = "ul. Zamoyskiego 28/30 03-801 Warszawa",
                        Products = new List<Product> (){
                            new Product()
                            {
                                Name = "Ptasie mleczko",
                                Description = "Kultowe pianki stworzone jeszcze przed II wojną światową, dla których inspiracją była francuska legumina, do dziś zachwycają swoją lekkością i wyjątkową delikatnością smaku.",
                                Price = 15,
                                ProductCategory = ProductCategory.Sweets
                            },

                            new Product()
                            {
                                Name = "Pawełek",
                                Description = "Gęsty, wyśmienity krem toffi zamknięty w pięciu kostkach wedlowskiej czekolady mlecznej. Przepyszny batonik, idealny jako przekąska. ",
                                Price = 2,
                                ProductCategory = ProductCategory.ChocolateBars
                            }
                        }
                    },
                    new Producent()
                    {
                        Name = "Nestle",
                        Address = "Vevey, Szwajcaria ",
                        Products = new List<Product> (){
                            new Product()
                            {
                                Name = "Cheerios",
                                Description = "Wszystko co najlepsze, w każdym kółeczku! Nestlé CHEERIOS to pyszne i bogate w wartości odżywcze płatki śniadaniowe z pełnego ziarna. Każde chrupiące kółeczko Nestlé CHEERIOS jest bogate w błonnik i zawiera 7 witamin, wapń oraz żelazo.",
                                Price = 11,
                                ProductCategory = ProductCategory.Cereals
                            },
                             new Product()
                            {
                                Name = "Kangus",
                                Description = "Płatki śniadaniowe Nestlé KANGUS to chrupiące, puszyste ziarna pszenicy oblane złocistym miodem. Wspaniały smak i cenne składniki odżywcze.",
                                Price = 13,
                                ProductCategory = ProductCategory.Cereals
                            },
                            new Product()
                            {
                                Name = "Chocapic",
                                Description = "Delikatne muszelki z ziarna pszenicy o smaku czekoladowym sprawią, że każde śniadanie będzie wyjątkowe! Płatki Nestlé CHOCAPIC to również źródło pełnego ziarna oraz cennych składników odżywczych - witamin, żelaza oraz wapnia.",
                                Price = 14,
                                ProductCategory = ProductCategory.Cereals
                            }
                        }
                    }
                };
                dataContext.Producents.AddRange(Producents);
                dataContext.SaveChanges();
            }
        }
    }
}
