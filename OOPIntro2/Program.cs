

class Program
{
    static void Main(string[] args)
    {
        CustomerManager customerManager = new CustomerManager(new Customer(), new CarCreditManager());
        customerManager.GiveCredit();

        Customer person1 = new Person() { Id = 1,
        City = "İzmir",
        FirstName = "Ege Umut",
        LastName = "Tali",
        NationalIdentity = "123456789"};

        CustomerManager customerManager2 = new CustomerManager(person1, new CarCreditManager());
        customerManager.Save(person1);
        customerManager.Delete(person1);



    }
}

public class Customer
{
    public Customer()
    {
        Console.WriteLine("Müşteri nesnesi başlatıldı..");
    }
    public int Id { get; set; }
    public string City { get; set; }
}

public class Person : Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
}

public class Company : Customer
{
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
}

public interface ICreditManager
{
    void Calculate();
    void Save();
}

public abstract class BaseCreditManager : ICreditManager
{
    public abstract void Calculate();

    public virtual void Save()
    {
        Console.WriteLine("Kaydedildi");
    }
}

class CreditManager
{
    public void Calculate(int creditType)
    {
        //sonar qube
        if (creditType == 1) //esnaf kredisi
        {

        }
        if (creditType == 2) //ogretmen kredisi
        {

        }

        Console.WriteLine("Hesaplandı");
    }
    public void Save()
    {
        Console.WriteLine("Kredi verildi");
    }
}

public class CustomerManager
{
    private Customer _customer;
    private ICreditManager _creditManager;
    public CustomerManager(Customer customer, ICreditManager creditManager)
    {
        _customer = customer;
        _creditManager = creditManager;
    }
    public void Save(Customer customer)
    {
        Console.WriteLine("Müşteri kaydedildi.");
    }

    public void Delete(Customer customer)
    {
        Console.WriteLine("Müşteri silindi.");
    }

    public void GiveCredit()
    {
        _creditManager.Calculate();
        Console.WriteLine("Kredi verildi.");
    }
}

class MilitaryCreditManager : BaseCreditManager, ICreditManager
{
    public override void Calculate()
    {
        Console.WriteLine("Asker kredisi hesaplandı");
    }
}

class TeacherCreditManager : BaseCreditManager, ICreditManager
{
    public override void Calculate()
    {
        //Hesaplamalar
        Console.WriteLine("Öğretmen kredisi hesaplandı");
    }
    public override void Save()
    {
        Console.WriteLine("Öğretmen kredisi kaydedildi");
    }
}

class CarCreditManager : BaseCreditManager, ICreditManager
{
    public override void Calculate()
    {
        //Hesaplamalar
        Console.WriteLine("Araba kredisi hesaplandı");
    }
    public override void Save()
    {
        Console.WriteLine("Araba kredisi kaydedildi");
    }
}