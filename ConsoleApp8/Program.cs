using System;
using System.Collections.Generic;

public class Program
{
    public static void mealsEventHandler(object source,MealsEventArgs e)
    {
        Console.WriteLine("{0} {1} is having {2}",e.customer.FirstName,e.customer.LastName,e.customer.Meal);
    }
 
    public static void Main()
    {
        Queue<Customer> CustList = new Queue<Customer>();
        Customer cust1 = new Customer();
        Customer cust2 = new Customer();
        Customer cust3 = new Customer();
        Customer cust4 = new Customer();
        Customer cust5 = new Customer();
        Customer cust6 = new Customer();

        cust2.FirstName = "Jane";
        cust2.LastName = "Jones";
        cust2.MealChangeEvent += mealsEventHandler;

        cust3.FirstName = "Jack";
        cust3.LastName = "Jump";
        cust3.MealChangeEvent += mealsEventHandler;

        cust4.FirstName = "Jeff";
        cust4.LastName = "Run";
        cust4.MealChangeEvent +=mealsEventHandler;

        cust5.FirstName = "Jill";
        cust5.LastName = "Hill";
        cust5.MealChangeEvent +=mealsEventHandler;

        cust6.FirstName = "John";
        cust6.LastName = "Winstone";
        cust6.MealChangeEvent +=mealsEventHandler;
        CustList.Enqueue(cust1);
        CustList.Enqueue(cust2);
        CustList.Enqueue(cust3);
        CustList.Enqueue(cust4);
        CustList.Enqueue(cust5);
        CustList.Enqueue(cust6);
 
        TableClass Tab = new TableClass();

        foreach (Customer value in CustList)
        {
            
            Tab.TableEvent += value.HandleTable;
            Tab.Open();
           /*while (value.Meal != Meals.done)
            {
                value.mealChanger(value.Meal);
            }*/
        }
        Console.WriteLine("Everyone is Full!!");
        Console.ReadLine();
    }
}
public enum Meals
{
    none,
    appetizer,
    main,
    desert,
    done
}


public class Customer
{
   
    public string LastName { get; set; }
    public string FirstName { get; set; }
   // public Meals Meal { get; set; }
    public string Meal { get; set; }
    public Customer() { }
    public event MealsEventHandler MealChangeEvent;


    public void HandleTable(object sender, TableEventArgs e)
    {
        Console.WriteLine("{0}{1} got a table",this.FirstName,this.LastName);
    }
    public void mealChanger(Meals m)
    {
        switch (m)
        {
            case Meals.none:
               
                this.Meal+= Meals.appetizer;
                if (this.MealChangeEvent != null)
                {
                    
                    MealChangeEvent(this, new MealsEventArgs(this));
                }
                break;
            case Meals.appetizer:
                this.Meal += Meals.appetizer;
                if (this.MealChangeEvent != null)
                {
                    
                    MealChangeEvent(this, new MealsEventArgs(this));
                }
                break;
            case Meals.main:
                this.Meal += Meals.appetizer;
                if (this.MealChangeEvent != null)
                {
                    
                    MealChangeEvent(this, new MealsEventArgs(this));
                }
                break;
            case Meals.desert:
                this.Meal += Meals.appetizer;
                if (this.MealChangeEvent != null)
                {
                    //fire the event.
                    MealChangeEvent(this, new MealsEventArgs(this));
                }
                break;
            
        }
    }

   
}


public class TableClass
{
    public event TableEventHandler TableEvent;
    
    public void Open()
    {
        Console.Write("Table is Open!");
        TableEventHandler table = TableEvent;
        if (TableEvent != null)
        {
            table(this, new TableEventArgs());
           
        }

    }
}


public delegate void TableEventHandler(object source, TableEventArgs e);
public delegate void MealsEventHandler(object source, MealsEventArgs e);

public class TableEventArgs : EventArgs
{
   /* public String Str { get; set; }
    public TableEventArgs(String str)
    {
        this.Str = Str;

    }*/
}
public class MealsEventArgs : EventArgs
{
    public Customer customer;
    public MealsEventArgs(Customer c)
    {
        this.customer = c;
    }
}
