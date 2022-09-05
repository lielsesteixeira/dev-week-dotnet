namespace src.Models;
public class Contract
{
    public int Id { get; set; }
    public string DocId { get; set; }
    public double Price { get; set; }
    public DateTime CreateAt { get; set; }
    public bool StatusPayment { get; set; }
    
    public int PersonId { get; set; }
    
    public Contract()
    {
        this.DocId = "a1b1c1";
        this.Price = 1;
        this.CreateAt = DateTime.Now;
        this.StatusPayment = false;
    }

    public Contract(
        string TokenId,
        double Price
        )
    {
        this.DocId = TokenId;
        this.Price = Price;
        this.CreateAt = DateTime.Now;
        this.StatusPayment = false;
    }
}