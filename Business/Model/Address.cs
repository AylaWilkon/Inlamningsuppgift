namespace MainApp.Business.Model
{
    public class Address 
    {
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public string FullAddress => $"{StreetName} {PostalCode} {City}"; //Stränginterpolering
        //Egenskap som endast läses in, genereras endast när det begärs. Användbar vid strukturering.
    }
    
}
