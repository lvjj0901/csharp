//Week week = new Week();
//Console.WriteLine(week[0]);
public class Week  
{ 
    private readonly string[] days = new string[] 
                                    { 
                                        "Monday", 
                                        "Tuesday", 
                                        "Wednesday", 
                                        "Thursday", 
                                        "Friday", 
                                        "Saturday", 
                                        "Sunday" 
                                    };


    public string this[int index] 
    {
        get
        {
            if (index < 0 || index >= this.days.Length)
            {
                throw new IndexOutOfRangeException($"Index must be between 0 and {this.days.Length - 1}.");
            }
            return this.days[index];
        }
    }
}
