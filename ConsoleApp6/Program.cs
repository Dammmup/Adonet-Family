using ConsoleApp6;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        var family = new Family
        {
            FamilyCode = "F123",
            NumberOfMembers = 4,
            HeadOfFamilyLastName = "Иванов",
            Address = "ул. Ленина, 123"
        };

      
        var familyRepository = new FamilyRepository();

        familyRepository.AddFamily(family);

    
        var families = familyRepository.GetFamilies();

    
        Console.WriteLine("Список семей:");
        foreach (var fam in families)
        {
            Console.WriteLine($"Семья {fam.FamilyCode}, Членов: {fam.NumberOfMembers}, Глава: {fam.HeadOfFamilyLastName}, Адрес: {fam.Address}");
        }

      
        family.NumberOfMembers = 5;
        familyRepository.UpdateFamily(family);

     
        families = familyRepository.GetFamilies();

     
        Console.WriteLine("\nОбновленный список семей:");
        foreach (var fam in families)
        {
            Console.WriteLine($"Семья {fam.FamilyCode}, Членов: {fam.NumberOfMembers}, Глава: {fam.HeadOfFamilyLastName}, Адрес: {fam.Address}");
        }

      
        familyRepository.DeleteFamily(family.FamilyId);

    
        families = familyRepository.GetFamilies();

        
        Console.WriteLine("\nОкончательный список семей:");
        foreach (var fam in families)
        {
            Console.WriteLine($"Семья {fam.FamilyCode}, Членов: {fam.NumberOfMembers}, Глава: {fam.HeadOfFamilyLastName}, Адрес: {fam.Address}");
        }
    }
}


public class FamilyRepository
{
    private readonly FamilyDbContext _context;

    public FamilyRepository()
    {
        _context = new FamilyDbContext();
        _context.Database.EnsureCreated(); // Создаем базу данных при запуске
    }

   
    public void AddFamily(Family family)
    {
        _context.Families.Add(family);
        _context.SaveChanges();
    }

   
    public void UpdateFamily(Family family)
    {
        _context.Families.Update(family);
        _context.SaveChanges();
    }


    public void DeleteFamily(int familyId)
    {
        var family = _context.Families.Find(familyId);
        if (family != null)
        {
            _context.Families.Remove(family);
            _context.SaveChanges();
        }
    }


    public List<Family> GetFamilies()
    {
        return _context.GetFamilies();
    }
}



