public class Payment
{
    public int PaymentID { get; set; }
    public int StudentID { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    // Task 5: Link to Student
    public Student Student { get; set; }
}
