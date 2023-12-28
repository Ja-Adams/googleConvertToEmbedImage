internal class Program
{
    private static void Main(string[] args)
    {
        string workingURL = "";
        string splicedURL = "0";
        string embedURL = "";

        var lineCount = File.ReadAllLines("test.txt");

        //Get the ID out of the google drive URL array and combine the base URL with the ID
        //Text file alternates every line with Title then the URL, so we only care about the even numbered lines
        int count = 1;
        foreach (string i in lineCount)
        {
            if(count % 2 == 0){
                splicedURL = i.Substring(i.IndexOf("d/")+2, i.Substring(i.IndexOf("d/")+2).IndexOf("/view"));
                embedURL += $"https://drive.google.com/uc?id={splicedURL}\n";
            }
            else{
                embedURL += i+" ";
            }
            count++;         
        }

        Console.WriteLine(embedURL);
        File.AppendAllText("output.txt", embedURL);
    }
}
