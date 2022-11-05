public class Network 
{
//the layout represents the weights per column of the network
int[] netLayout = {1, 4, 4, 1};
//the network string contains the values of all network weights
public String net = "1234567891011121314151617181920212223242526272829";

//I'm using charInString as a shared counter when running the network. It tells the network which character in the string it's on
private int charInString = 0;
//same with column
private int column = 0;

public int[] Run(int[] inputs) {
    inputs = AddWeights(inputs, 0);
    
    if (netLayout.Length != column+1)
    {
        int[] newInputs = new int[netLayout[column+1]];
        inputs = AddBiases(inputs, newInputs, 0, 0);
    }
    //my first ever recursive program! (I had 4 nested for loops)
    column++;
    if (column >= netLayout.Length) {
        charInString = 0;
        column = 0;
        return inputs;
    }
    return Run(inputs);
}

private int[] AddWeights(int[] inputs, int weightNum) {
    char c = net[charInString];
    charInString++;
    inputs[weightNum] *= (int) c;
    Console.WriteLine(c);

    weightNum++;
    if (weightNum >= netLayout[column]) {
        return inputs;
    }
    return AddWeights(inputs, weightNum);
}


private int[] AddBiases(int[] inputs, int[] newInputs, int weightNum, int biasNum) {
    newInputs[biasNum] = 0;
    char c = net[charInString];
    charInString++;
    newInputs[biasNum] += (int) c + inputs[weightNum]; 
    Console.WriteLine(c);

    biasNum++;
    if (biasNum >= netLayout[column+1]) {
        weightNum++;
        biasNum = 0;
        if (weightNum >= netLayout[column]) {
            return newInputs;
        }
    }
    return AddBiases(inputs, newInputs, weightNum, biasNum);

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

public void CreateDiagram(int[] inputs) {
    int charInString = 0;
    for (int column = 0; column < netLayout.Length; column++)
    {
        for (int i = 0; i < netLayout[column]; i++)
        {
            char c = net[charInString];
            charInString++;
            inputs[i] *= (int) c;
            
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
}



}