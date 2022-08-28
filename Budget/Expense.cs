namespace Budget
{
    public abstract class Expense
    // Abstract parent class declared,only the child classes may access it
    {
        private string name;
        private double amount;

        //Constructor created
       protected Expense(string name, double amount)
        {
            this.name = name;
            this.amount = amount;
        }
        // Getters and setters
        public double Amount { get => amount; set => amount = value; }
        public string Name { get => name; set => name = value; }

       
    

    //Overide ToString method in order to properly display expenses
    public override string ToString()
        {
          


            return this.Name + " - " +"R"+ this.Amount;


        }

        
      
        }
        
       
    }
   



    
