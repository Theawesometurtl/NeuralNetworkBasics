public class Network 
{
//the layout represents the weights per collumn of the network
int[] netLayout = {1, 4, 4, 1};
//the network string contains the values of all network weights
public String net = "1234567891011121314151617181920212223242526272829";

public int[] Run(int[] inputs) {
    int charInString = 0;
    for (int column = 0; column < netLayout.Length; column++)
    {
        for (int i = 0; i < netLayout[column]; i++)
        {
            char c = net[charInString];
            charInString++;
            inputs[i] *= (int) c;
            Console.WriteLine(c);
        }

        if (netLayout.Length != column+1)
        {
            int[] newInputs = new int[netLayout[column+1]];
            for (int row = 0; row < netLayout[column]; row++)
            {
                //I know this nested loop layout isn't at all readable, but I'm lazy and don't want to split it into seperate functions
                for (int bias = 0; bias < netLayout[column+1]; bias++)
                {
                    newInputs[bias] = 0;
                    char c = net[charInString];
                    charInString++;
                    newInputs[bias] += (int) c; 
                    Console.WriteLine(c);
                }
            }
            inputs = newInputs;
        }
    }
    return inputs;
}

//mutates the network string
public void Mutate(int mutRate, int maxMutChange) {
    String newNet = "";
    Random rnd = new Random();
    for (int i = 0; i < net.Length; i++)
    {
        /* This mutates any char, other code mutates into int from 0-9
        char c = net[i];
        if (rnd.Next(1, mutRate) == 1)
        {
            //adds value to char
            c += (char) rnd.Next(-maxMutChange, maxMutChange);
        }
        newNet += c;
        */
        char c = net[i];
        if (rnd.Next(1, mutRate) == 1)
        {
            int cValue = (int) c + rnd.Next(-maxMutChange, maxMutChange);
            if (cValue >= 0 && cValue <= 9) {
                newNet += cValue;
            }
        }
        
        //Console.WriteLine(newNet);
    }
    net = newNet;
}


}