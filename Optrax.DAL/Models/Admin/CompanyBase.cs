namespace OptraxDAL.Models.Admin
{
    public class Company
    {
        public Company() { }
        public int ID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int AddressID { get; set; }
        public required virtual Address Address { get; set; }
    }

    //public class Distributer : CompanyBase
    //{
    //    public Distributer() { }
    //    public string? TaxID { get; set; }
    //}
}
