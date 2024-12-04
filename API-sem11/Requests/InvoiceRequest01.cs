namespace API_sem11.Requests
{
    public class InvoiceRequest01
    {
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public double Total { get; set; }
    }
}
