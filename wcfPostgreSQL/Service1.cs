using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace wcfPostgreSQL
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        public string GetTest()
        {
            return "Test is OK";
        }

        string IService1.GetCustomers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                StringBuilder sb = new StringBuilder();
                foreach (var user in db.Customers.Include(u => u.Company).ToList())
                {
                    sb.AppendLine($"{user.Name}; {user.Company?.Name}");
                }
                return sb.ToString();
            }
        }

        void IService1.PostCustInfo(string user, string Company)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                // Проверяем, существует ли компания с заданным именем
                Company existingCompany = db.Company.FirstOrDefault(c => c.Name == Company);

                if (existingCompany == null)
                {
                    // Если компания не существует, создаем новую
                    existingCompany = new Company(Company);
                    db.Company.Add(existingCompany);
                }

                // Создаем нового клиента и связываем его с компанией
                Customer newCustomer = new Customer(user);
                newCustomer.Company = existingCompany;

                // Добавляем клиента в контекст
                db.Customers.Add(newCustomer);

                // Сохраняем изменения в базе данных
                db.SaveChanges();
            }
        }

        string IService1.DeleteCustInfo(string user, string Company)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Проверяем, существует ли компания с заданным именем
                Company existingCompany = db.Company.FirstOrDefault(c => c.Name == Company);

                if (existingCompany != null)
                {
                    // Находим пользователя по имени и компании
                    Customer userToDelete = db.Customers.FirstOrDefault(u => u.Name == user && u.CompanyId == existingCompany.Id);

                    if (userToDelete != null)
                    {
                        db.Customers.Remove(userToDelete); // Удаляем пользователя из контекста
                        db.SaveChanges(); // Сохраняем изменения в базе данных
                        return "Успех.";
                    }
                    else
                    {
                        return "Пользователь не найден.";
                    }
                }
                else
                {
                   return "Компания не найдена.";
                }
            }
        }

    }
}
