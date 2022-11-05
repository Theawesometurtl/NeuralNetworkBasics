public class Network 
{
//the layout represents the weights per collumn of the network
int[] netLayout = {1, 4, 4, 1};
//the network string contains the values of all network weights
public String net = "1234567891011121314151617181920212223242526272829";

public void Run() {
    int charInString = 0;
    for (int column = 0; column < netLayout.Length; column++)
    {
        for (int i = 0; i < netLayout[column]; i++)
        {
            char c = net[charInString];
            charInString++;
            //Console.WriteLine(c);
            

        }
        if (netLayout.Length != column--)
        {
            //idk why; I'm kinda tired; this goes out of range bc I need to only multiply it at certain points
            int NumBias = netLayout[column] * netLayout[column++];
            Console.WriteLine(NumBias);
            for (int i = 0; i < NumBias; i++)
            {
                char c = net[charInString];
                charInString++;
                //Console.WriteLine(c);
            }
        }
        
    }
    
}

//mutates the network string
public void Mutate(int mutRate, int maxMutChange) {
    String newNet = "";
    Random rnd = new Random();
    for (int i = 0; i < net.Length; i++)
    {
        char c = net[i];
        if (rnd.Next(1, mutRate) == 1)
        {
            //adds value to char
            c += (char) rnd.Next(-maxMutChange, maxMutChange);
        }
        
        newNet += c;
        //Console.WriteLine(newNet);
    }
    net = newNet;
}
}